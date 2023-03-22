using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class MoveTowardsVelocity : MoveVelocity, IMoveVector
{
    public override void SetVector(Vector3 direction)
    {
        this.velocityVector = direction.normalized;
        base.SetVector(direction);
    }

    protected override void MovePhysics()
    {
        rbody.velocity = velocityVector * moveSpeed;
    }
}
