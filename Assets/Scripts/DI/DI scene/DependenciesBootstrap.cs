using Cinemachine;
using UnityEngine;

public class DependenciesBootstrap : MonoBehaviour
{
    [SerializeField]
    private CinemachineImpulseSource cineImpulse = default;

    private void Awake()
    {
        // Fetching an instance of this class
        // (any class above Object on the mono inheritance tree cannot be instantiated)

        DependenciesContext.Dependencies.Add(new Dependency
        {
            Type = typeof(DependencyTestClass),
            Factory = () => new DependencyTestClass(),
            IsSingleton = false
        });

        // "Singleton" (not really in this case - it just exists in the scene already)
        // but in general this would be the case for fetching singletons)

        DependenciesContext.Dependencies.Add(new Dependency
        {
            Type = typeof(CinemachineImpulseSource),
            Factory = () => cineImpulse,
            IsSingleton = true
        });

        // Instantiation fetching for prefabs with dependencies

        //DependenciesContext.Dependencies.Add(new Dependency
        //{
        //    Type = typeof(CinemachineImpulseSource),
        //    Factory = () => Instantiate(cineImpulse).GetComponent<CinemachineImpulseSource>(),
        //    IsSingleton = true
        //});
    }
}
