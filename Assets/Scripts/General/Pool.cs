using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Pool<T> : UnityEngine.Object
{
    public static List<Pool<T>> poolList = new();
    public IObjectPool<IPoolableObject> objectPool { get; private set; }

    private IPoolableObject blueprintClass;
    public IPoolableObject GetBlueprint() { return blueprintClass; }

    public Pool(IPoolableObject blueprintClass)
    {
        this.blueprintClass = blueprintClass;

        objectPool = new ObjectPool<IPoolableObject>(CreateIPoolableObject,
            OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject,
            blueprintClass.CheckPool, blueprintClass.DefaultCapacity, blueprintClass.MaxSize);
    }

    private IPoolableObject CreateIPoolableObject()
    {
        IPoolableObject objectInstance = (IPoolableObject)Instantiate(blueprintClass.gameObject).GetComponent<T>();
        objectInstance.SetObjectPool(objectPool);
        return (IPoolableObject)objectInstance;
    }

    // invoked when returning an item to the object pool
    private void OnReleaseToPool(IPoolableObject pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }

    // invoked when retrieving the next item from the object pool
    private void OnGetFromPool(IPoolableObject pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
        if (blueprintClass.Lifespan != 0) { DeactivatePooledObject((MonoBehaviour)pooledObject); }
    }

    // invoked when we exceed the maximum number of pooled items (i.e. destroy the pooled object)
    private void OnDestroyPooledObject(IPoolableObject pooledObject)
    {
        Destroy(pooledObject.gameObject);
    }

    // Invoked on acquisition for pool, if there is a set lifespan
    public void DeactivatePooledObject(MonoBehaviour pooledObject)
    {
        pooledObject.StartCoroutine(DeactivateRoutine((IPoolableObject)pooledObject));
    }

    IEnumerator DeactivateRoutine(IPoolableObject pooledObject)
    {
        yield return new WaitForSeconds(pooledObject.Lifespan);
        pooledObject.gameObject.transform.position = Vector3.zero;
        objectPool.Release(pooledObject);
    }
}
