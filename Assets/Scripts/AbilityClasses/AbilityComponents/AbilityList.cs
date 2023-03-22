using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityList : MonoBehaviour
{
    [SerializeField] AbilitiesData abilitiesData;
    public Projectile selectedAbility;

    private void Awake()
    {
        selectedAbility = abilitiesData.abilityPrefabs[0];
    }
}
