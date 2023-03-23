using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour,CharacterDI
{
    [SerializeField] private CharacterStats statsComponent;
    [SerializeField]  private CharacterComponents componentsComponent;
    [SerializeField]  private CharacterHands CharacterHandsComponent;

    public CharacterComponentDI GetCharacterComponent()
    {
        return componentsComponent;
    }

    public CharacterStatsDI GetStatComponent()
    {
        return statsComponent;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Weapon weapon= CharacterHandsComponent.GetCurrentItem();
            weapon.Fire();
        }
    }
}
