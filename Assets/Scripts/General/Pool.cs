using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PoolItem
{
    public GameObject prefab;
    public int amount;
}

public class Pool : MonoBehaviour
{
    public static Pool singleton;
    public List<PoolItem> poolItems = new();
    public List<GameObject> gameObjects = new();
}
