using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class DependenciesCollection : IEnumerable<Dependency>
{
    private List<Dependency> dependencies = new List<Dependency>();

    public void Add(Dependency dependency) => dependencies.Add(dependency);

    public IEnumerator<Dependency> GetEnumerator() => dependencies.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => dependencies.GetEnumerator();
}