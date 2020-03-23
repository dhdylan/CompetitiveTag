using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "abilitiesContainer", menuName = "Abilities Container", order = 51)]
public class AbilitiesContainer : ScriptableObject
{
    public List<GameObject> abilityPrefabs = new List<GameObject>();
}
