using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public abstract class DependenciesContext : MonoBehaviour
{
    protected DependenciesCollection dependenciesCollection = new DependenciesCollection();
    private DependenciesProvider dependenciesProvider;


    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        Setup();

        dependenciesProvider = new DependenciesProvider(dependenciesCollection);

        var children = GetComponentsInChildren<Component>(true);
        foreach (var child in children)
        {
            dependenciesProvider.Inject(child);
        }

        Configure();
    }

    protected abstract void Setup();

    protected abstract void Configure();

}
