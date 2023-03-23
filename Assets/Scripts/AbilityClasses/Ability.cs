using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Ability : MonoBehaviour, IPoolableObject
{
    [SerializeField]
    private bool usePooling;
    public bool UsePooling
    {
        get { return usePooling; }
        private set { usePooling = value; }
    }

    public float manaCost;

    [SerializeField] protected float lifespan = 2f;
    protected IObjectPool<IPoolableObject> objectPool;
    public IObjectPool<IPoolableObject> ObjectPool { set => objectPool = value; }

    public void SetObjectPool(IObjectPool<IPoolableObject> pool)
    {
        ObjectPool = pool;
    }

    public abstract void Setup(Vector3 direction);

    public virtual void DisplayInfo()
    {
        Debug.Log("Category: Ability");
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
