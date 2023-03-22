using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Projectile : Ability, IPoolableObject
{
    IMoveVector iMoveVector;
    Vector3 direction;

    [SerializeField] protected float lifespan = 2f;
    protected IObjectPool<Projectile> objectPool;
    public IObjectPool<Projectile> ObjectPool { set => objectPool = value; }

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
        //base.DisplayInfo();
        //Debug.Log("Type: Projectile");
    }

    public void Move()
    {
        iMoveVector.SetVector(direction);
    }

    public void SetMoveBehavior(IMoveVector iMoveVector)
    {
        this.iMoveVector = iMoveVector;
    }

    public void Deactivate()
    {
        StartCoroutine(DeactivateRoutine(lifespan));
    }

    IEnumerator DeactivateRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.position = Vector3.zero;
        objectPool.Release(this);
    }
}
