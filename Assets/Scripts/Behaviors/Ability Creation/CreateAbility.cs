using UnityEngine;
using UnityEngine.Pool;

public class CreateAbility : MonoBehaviour, IPerformAbility
{
    private AbilityList abilityList;
    [SerializeField] private Transform spawnPoint;

    [Header("Pool Options")]
    private IObjectPool<Projectile> objectPool;
    [SerializeField] private bool checkPool = true;
    [SerializeField] private int defaultCapacity = 3;
    [SerializeField] private int maxSize = 6;

    private void Awake()
    {
        abilityList = GetComponent<AbilityList>();

        objectPool = new ObjectPool<Projectile>(CreateProjectile,
            OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject,
            checkPool, defaultCapacity, maxSize);
    }

    private Projectile CreateProjectile()
    {
        Projectile projectileInstance = Instantiate(abilityList.selectedAbility);
        projectileInstance.ObjectPool = objectPool;
        return projectileInstance;
    }

    // invoked when returning an item to the object pool
    private void OnReleaseToPool(Projectile pooledObject)
    {
       pooledObject.gameObject.SetActive(false);
    }

    // invoked when retrieving the next item from the object pool
    private void OnGetFromPool(Projectile pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }

    // invoked when we exceed the maximum number of pooled items (i.e. destroy the pooled object)
    private void OnDestroyPooledObject(Projectile pooledObject)
    {
        Destroy(pooledObject.gameObject);
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

        //GameObject projectile = Instantiate(abilityList.selectedAbility, spawnPoint.position, Quaternion.identity);
        //Vector3 shootDir = (target - spawnPoint.position).normalized;
        //projectile.GetComponent<Projectile>().Setup(shootDir);

        // Expand for any type
        //CreateProjectile();
        IPoolableObject pooledObject = objectPool.Get();
        Component component = pooledObject.gameObject.GetComponent(typeof(Projectile));
        if (component != null)
        {
            Projectile projectile = (Projectile)pooledObject;
            projectile.gameObject.transform.position = spawnPoint.position;
            Vector3 shootDir = (target - spawnPoint.position).normalized;
            projectile.Setup(shootDir);
            projectile.Deactivate();
        }
        else
        {
            Debug.LogError("Failed to get Projectile component from pooled object");
        }
    }
}
