using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public interface IPoolableObject
{
    GameObject gameObject { get; }

    void SetObjectPool(IObjectPool<IPoolableObject> pool);
}
