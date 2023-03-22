using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public static class BehaviorExtensions
{
    public static void AnimationOnMovement<T>(this T movement) where T : IMoveVector
    {
        //if (movement.animControl && movement.velocityVector != Vector3.zero) 
        //{ movement.animControl.IsMoving(); }
        //else { movement.animControl.IsIdle(); }
    }
}
