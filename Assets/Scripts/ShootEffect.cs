using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShootEffect : MonoBehaviour
{
    [SerializeField] private Shoot playerShoot;
    [SerializeField] private Material weaponTracerMaterial;
    [SerializeField] private GameObject prefabToShoot;
    private ParticleSystem ps;

    public enum TraceOption
    {
        Mesh, Particles, Prefab
    }
    public TraceOption traceOption;

    private CinemachineImpulseSource impulseSource;

    private void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void Start()
    {
        playerShoot.OnShoot += Player_OnShoot;
    }

    private void Player_OnShoot(object sender, Shoot.OnShootEventArgs e)
    {
        impulseSource.GenerateImpulse();

        //mesh or vfx
        if (traceOption == TraceOption.Mesh)
        {
            //Vector2 shootDirection = (e.shootPosition - e.shootEndPointPosition).normalized;
            //BulletRaycast.ShootRay(e.gunEndPointPosition, shootDirection);

            //WeaponTracer(e.gunEndPointPosition, BulletRaycast.rayEndPoint);

            //Debug.DrawLine(e.gunEndPointPosition, BulletRaycast.rayEndPoint, Color.white, 1);
        }
        else if (traceOption == TraceOption.Particles) 
        {
            playerShoot.bulletFX.Emit(1);

            //colision rendering problem workaround
            var psCollision = playerShoot.bulletFX.collision;
            psCollision.enabled = true;
        }
        else if (traceOption == TraceOption.Prefab)
        {
            GameObject projectile = Instantiate(prefabToShoot, e.shootEndPointPosition , Quaternion.identity);
            Vector3 shootDir = (e.shootPosition - e.shootEndPointPosition).normalized;
            projectile.GetComponent<Projectile>().Setup(shootDir);
        }
    }

    //private void WeaponTracer(Vector3 fromPosition, Vector3 targetPosition)
    //{
    //    float distanceOffset = 0.3f;

    //    Vector3 dir = (targetPosition - fromPosition).normalized;

    //    float eulerZ = Utilities.GetAngleFromVectorFloat(dir) - 90f;
    //    float distance = Vector3.Distance(fromPosition, targetPosition);
    //    distance = distance + distanceOffset;
    //    Vector3 tracerSpawnPosition = fromPosition + dir * distance * 0.5f;

    //    Material tmpWeaponTracerMaterial = new Material(weaponTracerMaterial);
    //    tmpWeaponTracerMaterial.SetTextureScale("_MainTex", new Vector2(1f, (distance / 190f)));

    //    World_Mesh worldMesh = World_Mesh.Create(tracerSpawnPosition, eulerZ, .2f, distance, weaponTracerMaterial, null, 10000);

    //    float timer = 0.1f;
    //    FunctionUpdater.Create(() =>
    //    {
    //        timer -= Time.deltaTime;
    //        if (timer <= 0)
    //        {
    //            worldMesh.DestroySelf();
    //            return true;
    //        }
    //        return false;
    //    });
    //}
}


