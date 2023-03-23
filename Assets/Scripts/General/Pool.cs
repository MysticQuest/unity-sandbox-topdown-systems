using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Pool<T> : UnityEngine.Object
{
    public IObjectPool<IPoolableObject> objectPool { get; private set; }
    [SerializeField] private bool checkPool = true;
    [SerializeField] private int defaultCapacity = 3;
    [SerializeField] private int maxSize = 6;

    private GameObject blueprint;

    public Pool(GameObject blueprint)
    {
        this.blueprint = blueprint;

        objectPool = new ObjectPool<IPoolableObject>(CreateIPoolableObject,
            OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject,
            checkPool, defaultCapacity, maxSize);
    }

    private IPoolableObject CreateIPoolableObject()
    {
        T objectInstance = Instantiate(blueprint).GetComponent<T>();
        //objectInstance.ObjectPool = objectPool;
        IPoolableObject poolableObject = (IPoolableObject)objectInstance;
        poolableObject.SetObjectPool(objectPool);
        //PropertyInfo propInfo = blueprint.GetType().GetProperty("ObjectPool");
        //propInfo.SetValue(objectInstance, objectPool, null);
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
    }

    // invoked when we exceed the maximum number of pooled items (i.e. destroy the pooled object)
    private void OnDestroyPooledObject(IPoolableObject pooledObject)
    {
        Destroy(pooledObject.gameObject);
    }
}
