using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class MoveVelocity : MonoBehaviour, IMoveVector
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rbody;
    internal Vector3 velocityVector;
    internal AnimationControl animControl;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        animControl = GetComponent<AnimationControl>();
    }

    public void SetVector(Vector3 direction)
    {
        this.velocityVector = direction.normalized;
    }

    private void FixedUpdate()
    {
        MovePhysics();
        AnimationOnMovement();
        //BehaviorExtensions.AnimationOnMovement(this);   
    }

    private void MovePhysics()
    {
        rbody.velocity = velocityVector * moveSpeed;
    }

    public Vector3 GetPosition()
    {
        return this.transform.position;
    }

    public Vector3 GetDirection()
    {
        return velocityVector;
    }

    private void AnimationOnMovement () 
    {
        if (animControl && velocityVector != Vector3.zero)
        { animControl.IsMoving(); }
        else { animControl.IsIdle(); }
    }
}
