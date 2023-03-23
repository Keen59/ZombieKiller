using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHands : MonoBehaviour 
{
    [SerializeField] private Weapon CurrentItem;

    public Weapon GetCurrentItem()
    {

        return CurrentItem;
    }


}
