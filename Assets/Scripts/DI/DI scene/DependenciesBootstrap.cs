using Cinemachine;
using UnityEngine;

public class DependenciesBootstrap : MonoBehaviour
{
    //[SerializeField]
    //private MoveVelocity movement = default;
    [SerializeField]
    private PlayerMouseAim aiming = default;
    [SerializeField]
    private CreateAbility performAbility = default;
    [SerializeField]
    private CinemachineImpulseSource cineImpulse = default;

    private void Awake()
    {
        // Fetching instances of these classes
        // (any class above Object on the inheritance tree cannot be instantiated)

        //DependenciesContext.Dependencies.Add(new Dependency
        //{
        //    Type = typeof(MoveVelocity),
        //    Factory = () => new MoveVelocity(),
        //    IsSingleton = false
        //});

        //DependenciesContext.Dependencies.Add(new Dependency
        //{
        //    Type = typeof(PlayerMouseAim),
        //    Factory = () => new PlayerMouseAim(),
        //    IsSingleton = false
        //});

        //DependenciesContext.Dependencies.Add(new Dependency
        //{
        //    Type = typeof(CreateAbility),
        //    Factory = () => new CreateAbility(),
        //    IsSingleton = false
        //});

        // "Singleton" (not really in this case - it just exists in the scene already)
        // but in general this would be the case for fetching singletons)

        DependenciesContext.Dependencies.Add(new Dependency
        {
            Type = typeof(CinemachineImpulseSource),
            Factory = () => cineImpulse,
            IsSingleton = true
        });

        // Instantiation fetching

        //DependenciesContext.Dependencies.Add(new Dependency
        //{
        //    Type = typeof(CinemachineImpulseSource),
        //    Factory = () => Instantiate(cineImpulse).GetComponent<CinemachineImpulseSource>(),
        //    IsSingleton = true
        //});
    }
}
