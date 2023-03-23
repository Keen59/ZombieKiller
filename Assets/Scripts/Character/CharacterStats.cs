using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour, CharacterStatsDI
{
    [SerializeField]private Stats stats;
   
    public Stats GetStatsComponent()
    {
        return stats;
    }
}
