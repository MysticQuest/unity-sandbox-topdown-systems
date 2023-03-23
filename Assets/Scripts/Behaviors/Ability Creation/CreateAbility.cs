using UnityEngine;
using UnityEngine.Pool;

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
        // Need to store pool or check if it exists so the a new pool isn't made when switching back

        pool = new Pool<Ability>(abilityList.selectedAbility.gameObject);
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
