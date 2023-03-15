using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : Ability
{
    IMoveVector iMoveVector;

    Vector3 direction;


    private void Awake()
    {
        iMoveVector = GetComponent<IMoveVector>();
    }

    public void Setup(Vector3 direction)
    {
        this.direction = direction;
    }

    private void Update()
    {
        Move();
    }

    public override void  DisplayInfo()
    {
        base.DisplayInfo();
        Debug.Log("Type: Projectile");
    }

    public void Move()
    {
        iMoveVector.SetVector(direction);
    }

    public void SetMoveBehavior(IMoveVector iMoveVector)
    {
        this.iMoveVector = iMoveVector;
    }
}
