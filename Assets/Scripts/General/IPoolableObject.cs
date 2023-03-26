using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public interface IPoolableObject
{
    GameObject gameObject { get; }
    bool CheckPool { get; }
    int DefaultCapacity { get; }
    int MaxSize { get; }
    float Lifespan { get; }

    void SetObjectPool(IObjectPool<IPoolableObject> pool);
}
