using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{

    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;
    [SerializeField] private ItemType title;
    [SerializeField] protected float Durability;
   
}
[SerializeField]
public enum ItemType
{
    None, Weapon, Armor, Grenade, Ammo
}
[SerializeField]
public enum WeaponType
{
    None, Rifle, Pistol
}
[SerializeField]
public enum AmmoType
{
    None, FiveFiftySixCaliber, FiveSevenCaliber, SevenSixtyTwoCaliber
}

