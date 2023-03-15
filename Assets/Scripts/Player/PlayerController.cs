using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private UnityEngine.Transform mouseObject;

    private Gamepad gamepad;

    private IMoveVector iMoveVector;
    private IAim iAim;
    private IPerformAbility iPerformAbility;

    private PlayerInput playerInput;
    private InputAction movement;
    private InputAction aim;

    private Vector2 aimStickVector;
    private Vector3 mouseWorldPos;

    private void Awake()
    {
        gamepad = Gamepad.current;

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
        if (Gamepad.current == null) 
        {
            Debug.LogWarning("No gamepad detected");
        }

        movement = playerInput.Player.Movement;
        movement.Enable();

        aim = playerInput.Player.Aim;
        aim.Enable();
        aim.performed += obj => aimStickVector = obj.ReadValue<Vector2>(); // uses lamda for no reason

        playerInput.Player.Shoot.performed += PerformAbility;
        playerInput.Player.Shoot.Enable();
    }

    private void FixedUpdate()
    {
        iMoveVector.SetVector(movement.ReadValue<Vector2>());
        ///Mouse.current.WarpCursorPosition(ToWorldPosition(aimStickVector));
        //mouseObject.position += new Vector3(aimStickVector.x, aimStickVector.y, 0f);
        //Mouse.current.WarpCursorPosition(mouseWorldPos);
        //mouseObject.position += aim.ReadValue<Vector3>() * Time.deltaTime;
        mouseObject.position = ToWorldPosition(aimStickVector);
        iAim.Aim(mouseObject.position);
    }

    private Vector2 ToWorldPosition(Vector2 v2)
    {
       return Camera.main.ScreenToWorldPoint(new Vector3(v2.x, v2.y, -Camera.main.transform.position.z));
    }

    private void PerformAbility(InputAction.CallbackContext obj)
    {
        iPerformAbility.PerformAbility(mouseObject.position);
    }

    private void OnDisable()
    {
        movement.Disable();
        aim.Disable();
        playerInput.Player.Shoot.Disable();
    }

}
