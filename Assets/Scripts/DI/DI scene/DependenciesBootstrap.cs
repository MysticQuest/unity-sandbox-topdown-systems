using UnityEngine;

public class DependenciesBootstrap : MonoBehaviour
{
    [SerializeField]
    private MoveVelocity movement = default;
    [SerializeField]
    private PlayerMouseAim aiming = default;
    [SerializeField]
    private CreateAbility performAbility = default;

    private void Awake()
    {

    }
}
