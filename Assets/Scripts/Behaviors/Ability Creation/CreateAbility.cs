using UnityEngine;
using UnityEngine.Pool;
using System.Runtime.InteropServices;

public class CreateAbility : MonoBehaviour, IPerformAbility
{
    private AbilityList abilityList;
    [SerializeField] private Transform spawnPoint;

    private Pool<Ability> pool;

    private void Awake()
    {
        abilityList = GetComponent<AbilityList>();
    }

    private void Start()
    {
        CheckIfUsesPool();
    }

    private void CheckIfUsesPool()
    {
        if (abilityList.selectedAbility.UsePooling)
        {
            InitializePool();
        }
    }

    private void InitializePool()
    {
        pool = FindOrCreatePool();
        Pool<Ability>.poolList.Add(pool);
    }

    private Pool<Ability> FindOrCreatePool()
    {
        foreach (Pool<Ability> poolInstance in Pool<Ability>.poolList)
        {
            if ((Object)poolInstance.GetBlueprint() == abilityList.selectedAbility)
            {
                return poolInstance;  
            }
        }
        return new Pool<Ability>(abilityList.selectedAbility);
    }

    public void SwitchAbility()
    {
        abilityList.NextAbility();
        CheckIfUsesPool();
    }

    public void PerformAbility(Vector3 target)
    {

        if (abilityList.selectedAbility.UsePooling)
        {
            IPoolableObject pooledObject = pool.objectPool.Get();
            Component component = pooledObject.gameObject.GetComponent(typeof(Projectile));
            if (component != null)
            {
                Ability ability = (Ability)pooledObject;
                ability.gameObject.transform.position = spawnPoint.position;
                Vector3 shootDir = (target - spawnPoint.position).normalized;
                ability.Setup(shootDir);
                ability.Deactivate();
            }
            else
            {
                Debug.LogError("Failed to get Ability component from pooled object");
            }
        }
        else
        {
            GameObject ability = Instantiate(abilityList.selectedAbility.gameObject, spawnPoint.position, Quaternion.identity);
            Vector3 shootDir = (target - spawnPoint.position).normalized;
            ability.GetComponent<Ability>().Setup(shootDir);
        }
    }
}
