using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class MoveToTargetVelocity : MonoBehaviour, IMoveVector
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rbody;
    internal Vector3 velocityVector;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    public void SetVector(Vector3 direction)
    {
        this.velocityVector = direction.normalized;
        MovePhysics();
    }

    private void MovePhysics()
    {
        rbody.MovePosition(velocityVector);
    }

    public Vector3 GetPosition()
    {
        return this.transform.position;
    }

    public Vector3 GetDirection()
    {
        return velocityVector;
    }
}
