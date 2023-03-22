using UnityEngine;

public abstract class MoveVelocity : MonoBehaviour, IMoveVector
{
    [SerializeField] protected float moveSpeed = 5f;

    protected Rigidbody2D rbody;
    protected Vector3 velocityVector;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    public virtual void SetVector(Vector3 direction)
    {
        MovePhysics();
    }

    protected abstract void MovePhysics();

    public Vector3 GetPosition()
    {
        return this.transform.position;
    }

    public Vector3 GetDirection()
    {
        return velocityVector;
    }
}
