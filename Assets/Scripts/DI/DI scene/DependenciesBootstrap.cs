using Cinemachine;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public abstract class DependenciesBootstrap : MonoBehaviour
{
    protected DependenciesCollection dependenciesCollection = new DependenciesCollection();
    private DependenciesProvider dependenciesProvider;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Setup();

        dependenciesProvider = new DependenciesProvider(dependenciesCollection);

        var children = GetComponentsInChildren<MonoBehaviour>(true);
        foreach (var child in children)
        {
            dependenciesProvider.Inject(child);
        }

        Configure();
    }

    protected abstract void Setup();

    protected abstract void Configure();


// OBSOLETE (old injection)

//    // Fetching an instance of this class
//    // (any class above Object on the mono inheritance tree cannot be instantiated)

//    DependenciesContext.Dependencies.Add(new Dependency
//        {
//            Type = typeof(DependencyTestClass),
//            Factory = () => new DependencyTestClass(),
//            IsSingleton = false
//        });

//// "Singleton" (not really in this case - it just exists in the scene already)
//// but in general this would be the case for fetching singletons)

//DependenciesContext.Dependencies.Add(new Dependency
//{
//    Type = typeof(CinemachineImpulseSource),
//    Factory = () => cineImpulse,
//    IsSingleton = true
//});

//        // Instantiation fetching for prefabs with dependencies

//        //DependenciesContext.Dependencies.Add(new Dependency
//        //{
//        //    Type = typeof(CinemachineImpulseSource),
//        //    Factory = () => Instantiate(cineImpulse).GetComponent<CinemachineImpulseSource>(),
//        //    IsSingleton = true
//        //});

}
