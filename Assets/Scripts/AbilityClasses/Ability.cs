using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Ability : MonoBehaviour, IPoolableObject
{
    [Header ("Pooling Options")]

    [SerializeField] private bool usePooling;
    [SerializeField] private bool checkPool = true;
    [SerializeField] private int defaultCapacity = 3;
    [SerializeField] private int maxSize = 6;

    public bool UsePooling { get { return usePooling; } private set { usePooling = value; } }
    public bool CheckPool { get { return checkPool; } private set { checkPool = value; } }
    public int DefaultCapacity { get { return defaultCapacity; } private set { defaultCapacity = value; } }
    public int MaxSize { get { return maxSize; } private set { maxSize = value; } }

    protected IObjectPool<IPoolableObject> objectPool;
    public IObjectPool<IPoolableObject> ObjectPool { set => objectPool = value; }

    [Header("Ability Attributes")]

    public float manaCost;

    [SerializeField] protected float lifespan = 2f;

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
