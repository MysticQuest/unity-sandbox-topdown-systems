﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Windows;

public class MoveToTargetVelocity : MoveVelocity, IMoveVector
{
    public override void SetVector(Vector3 direction)
    {
        this.velocityVector = direction;
        base.SetVector(direction);
    }

    protected override void MovePhysics()
    {
        rbody.velocity = (velocityVector - transform.position).normalized * moveSpeed;
    }
}
