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

    private ShootEffect shootE;

    private void Awake()
    {
        iMoveVector = GetComponent<IMoveVector>();
        iAim = GetComponent<IAim>();
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

        //playerInput.Player.Shoot.performed += PerformAbility();
        //playerInput.Player.Shoot.Enable();
    }

    private void FixedUpdate()
    {
        iMoveVector.SetVector(movement.ReadValue<Vector2>());

        mouseWorldPos = Camera.main.ScreenToWorldPoint(aim.ReadValue<Vector2>());
        mouseWorldPos.z = 0;
        mouseObject.position = mouseWorldPos;
        iAim.Aim(mouseWorldPos);
    }

    private Action<InputAction.CallbackContext> PerformAbility()
    {
        throw new NotImplementedException();
    }

    private void OnDisable()
    {
        movement.Disable();
        aim.Disable();
        playerInput.Player.Shoot.Disable();
    }

}
