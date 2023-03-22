using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "AbilitiesData", menuName = "ScriptableObjects/AbilitiesData", order = 1)]
public class AbilitiesData : ScriptableObject
{
    public List<Projectile> abilityPrefabs;
}
