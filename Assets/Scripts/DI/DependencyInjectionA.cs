using System;
using System.Collections.Generic;

public struct Dependency
{
    public Type Type { get; set; }
    public bool IsSingleton { get; set; }
}

public class DependenciesCollection
{
    private List<Dependency> dependencies = new List<Dependency>();

    public void Add(Dependency dependency) => dependencies.Add(dependency);
}
