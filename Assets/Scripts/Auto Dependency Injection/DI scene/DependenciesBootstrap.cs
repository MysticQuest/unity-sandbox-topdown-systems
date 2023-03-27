using Cinemachine;
using UnityEngine;

public class DependenciesBootstrap : DependenciesContext
{
    [SerializeField]
    private CinemachineImpulseSource cineImpulse;

    [SerializeField]
    private Transform playerTransform;

    protected override void Setup()
    {

        // Fetching an instance of this class
        // (any class above Object on the mono inheritance tree cannot be instantiated)

        dependenciesCollection.Add(new Dependency
        {
            Type = typeof(DependencyTestClass),
            Factory = DependencyFactory.FromClass<DependencyTestClass>(),
            IsSingleton = false
        });

        // Fetching the already existing instance from gameobjects

        dependenciesCollection.Add(new Dependency
        {
            Type = typeof(CinemachineImpulseSource),
            Factory = DependencyFactory.FromGameObject(cineImpulse),
            IsSingleton = true
        });

        dependenciesCollection.Add(new Dependency
        {
            Type = typeof(Transform),
            Factory = DependencyFactory.FromGameObject(playerTransform),
            IsSingleton = true
        });

        // Instantiation fetching for prefabs with dependencies

        //dependenciesCollection.Add(new Dependency { 
        //    Type = typeof(ExampleDependencyNested), 
        //    Factory = DependencyFactory.FromPrefab(exampleDependencyNested), 
        //    IsSingleton = true });
    }

    protected override void Configure()
    {

    }
}

