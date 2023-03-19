using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilitiesData", menuName = "ScriptableObjects/AbilitiesData", order = 1)]
public class AbilitiesData : ScriptableObject
{
    public List<GameObject> abilityPrefabs;
}
