using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAbility : MonoBehaviour, IPerformAbility
{
    private AbilityList abilityList;
    [SerializeField] private Transform spawnPoint;

    private void Awake()
    {
        abilityList = GetComponent<AbilityList>();    
    }

    public void PerformAbility(Vector3 target)
    {
        //    if (traceOption == TraceOption.Particles)
        //    {
        //        playerShoot.bulletFX.Emit(1);

        //        //colision rendering problem workaround
        //        var psCollision = playerShoot.bulletFX.collision;
        //        psCollision.enabled = true;
        //    }
        //    else if (traceOption == TraceOption.Prefab)
        //    {
        //        GameObject projectile = Instantiate(prefabToShoot, e.shootEndPointPosition, Quaternion.identity);
        //        Vector3 shootDir = (e.shootPosition - e.shootEndPointPosition).normalized;
        //        projectile.GetComponent<Projectile>().Setup(shootDir);
        //    }

        GameObject projectile = Instantiate(abilityList.selectedAbility, spawnPoint.position, Quaternion.identity);
        Vector3 shootDir = (target - spawnPoint.position).normalized;
        projectile.GetComponent<Projectile>().Setup(shootDir);
    }
}
