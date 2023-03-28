using UnityEngine;

[DisallowMultipleComponent]
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
