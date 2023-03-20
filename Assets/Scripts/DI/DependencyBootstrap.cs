using UnityEngine;

public class DependenciesBootstrap : MonoBehaviour
{
    [SerializeField]
    private ExampleDependencyMonoBehaviour exampleDependency = default;

    private void Awake()
    {
        DependenciesContext.Dependencies.Add(new Dependency
        {
            Type = typeof(ExampleDependencyMonoBehaviour),
            Factory = () => Instantiate(exampleDependency).GetComponent<ExampleDependencyMonoBehaviour>(),
            IsSingleton = true
        });
    }
}
