using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private IMoveVector iMoveVector;
    private IAim iAim;
    private IPerformAbility iPerformAbility;

    private PlayerInput playerInput;
    private InputAction movement;
    private InputAction aim;

    private ShootEffect shootE;

    private void Awake()
    {
        iMoveVector = GetComponent<IMoveVector>();
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        movement = playerInput.Player.Movement;
        movement.Enable();

        aim = playerInput.Player.Aim;
        aim.Enable();

        playerInput.Player.Shoot.performed += PerformAbility();
        playerInput.Player.Shoot.Enable();
    }

    private void FixedUpdate()
    {
        iMoveVector.SetVector(movement.ReadValue<Vector2>());
        iAim.Aim(aim.ReadValue<Vector2>());
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
