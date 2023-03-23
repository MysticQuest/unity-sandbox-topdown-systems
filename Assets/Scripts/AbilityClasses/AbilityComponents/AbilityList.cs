using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityList : MonoBehaviour
{
    [SerializeField] AbilitiesData abilitiesData;
    public Ability selectedAbility;
    private int abilityIndex = 0;

    private void Awake()
    {
        selectedAbility = abilitiesData.abilityPrefabs[abilityIndex];
    }

    public void NextAbility()
    {
        abilityIndex = abilityIndex + 1 >= abilitiesData.abilityPrefabs.Count ? 0 : abilityIndex + 1;
        selectedAbility = abilitiesData.abilityPrefabs[abilityIndex];
    }
}
