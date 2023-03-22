using UnityEngine;

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
