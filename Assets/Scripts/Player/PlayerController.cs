using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform mouseObject;

    private IMoveVector iMoveVector;
    private IAim iAim;
    private IPerformAbility iPerformAbility;

    private PlayerInput playerInput;
    private InputAction movement;
    private InputAction aim;

    private Vector3 mouseWorldPos;

    private void Awake()
    {
        iMoveVector = GetComponent<IMoveVector>();
        iAim = GetComponent<IAim>();
        iPerformAbility = GetComponent<IPerformAbility>();
        playerInput = new PlayerInput();

        if (!mouseObject)
        {
            mouseObject = transform.Find("MouseObject");
        }
    }

    private void OnEnable()
    {
        movement = playerInput.Player.Movement;
        movement.Enable();

        aim = playerInput.Player.Aim;
        aim.Enable();

        playerInput.Player.Shoot.performed += PerformAbility;
        playerInput.Player.Shoot.Enable();
    }

    private void FixedUpdate()
    {
        iMoveVector.SetVector(movement.ReadValue<Vector2>());
        MouseToWorldPosition();
        iAim.Aim(mouseWorldPos);
        mouseObject.position = mouseWorldPos;
    }

    private void MouseToWorldPosition()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(aim.ReadValue<Vector2>());
        mouseWorldPos.z = 0;
    }

    private void PerformAbility(InputAction.CallbackContext context)
    {
        iPerformAbility.PerformAbility(mouseWorldPos);
    }

    private void OnDisable()
    {
        movement.Disable();
        aim.Disable();
        playerInput.Player.Shoot.Disable();
    }

}
