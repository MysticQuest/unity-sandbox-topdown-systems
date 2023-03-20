using Cinemachine;
using System;
using Unity.Burst.Intrinsics;
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
    private InputAction aimM;
    private InputAction aimG;

    private Vector2 inputAimM;
    private Vector2 aimVectorG;
    private Vector2 cursorVector;

    [InjectField]
    private DependencyTestClass depTest = null;
    [InjectField]
    private CinemachineImpulseSource cineImpulse = null;

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
        if (Gamepad.current == null) { Debug.LogWarning("No gamepad detected"); }

        movement = playerInput.Player.Movement;
        movement.Enable();

        playerInput.Player.Shoot.Enable();
        playerInput.Player.Shoot.performed += PerformAbility;

        aimM = playerInput.Player.AimMouse;
        aimG = playerInput.Player.AimGamepad;
        aimM.Enable();
        aimG.Enable();
        aimM.performed += AimingMouse;
        aimG.performed += AimingGamepad;
    }

    private void FixedUpdate()
    {
        iMoveVector.SetVector(movement.ReadValue<Vector2>());

        mouseObject.position = ToWorldPosition(inputAimM);
        iAim.Aim(ToWorldPosition(inputAimM));
    }

    private void AimingMouse(InputAction.CallbackContext obj)
    {
        inputAimM = obj.ReadValue<Vector2>();
    }
    private void AimingGamepad (InputAction.CallbackContext obj)
    {
        Debug.Log("Gamepad Input");

        aimVectorG = obj.ReadValue<Vector2>().normalized;
        aimVectorG.x = aimVectorG.x * 10 * Time.deltaTime;
        aimVectorG.y = aimVectorG.y * 10 * Time.deltaTime;

        cursorVector = (Vector2)mouseObject.position;
        cursorVector.x += aimVectorG.x;
        cursorVector.y += aimVectorG.y;

        MousePositioning();
    }

    private void MousePositioning()
    {
        Vector3 mousepos = Camera.main.WorldToScreenPoint(cursorVector); // 3D worldpos into 2D
        // 'feature' workaround: https://forum.unity.com/threads/inputsystem-reporting-wrong-mouse-position-after-warpcursorposition.929019/
        //InputSystem.QueueDeltaStateEvent(Mouse.current.position, (Vector2)mousepos);   // required 8 bytes, not 12!
        //InputState.Change(Mouse.current.position, (Vector2)mousepos);
#if !UNITY_EDITOR
        // bug workaround : https://forum.unity.com/threads/mouse-y-position-inverted-in-build-using-mouse-current-warpcursorposition.682627/#post-5387577
        // mousepos.Set(mousepos.x, Screen.height - mousepos.y, mousepos.z);
#endif
        Mouse.current.WarpCursorPosition(mousepos);
    }

    private Vector2 ToWorldPosition(Vector2 v2)
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(v2.x, v2.y, 0));
    }

    private void PerformAbility(InputAction.CallbackContext obj)
    {
        iPerformAbility.PerformAbility(mouseObject.position);
        cineImpulse.GenerateImpulse();
        depTest.Yell();
    }

    private void OnDisable()
    {
        movement.Disable();
        playerInput.Player.Shoot.Disable();
        aimM.Disable();
        aimG.Disable();
    }

}
