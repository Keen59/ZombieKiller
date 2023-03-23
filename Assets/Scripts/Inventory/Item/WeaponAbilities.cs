using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine;

public class WeaponAbilities : MonoBehaviour,GunAbility
{

    private void Start()
    {
   
    }
    public void WeaponFire(Weapon weapon)
    {
    Instantiate(weapon.GetAmmo(), weapon.GetBarrel());
        EventManager.GunFireVFXEventCall();

      
    }

    public void WeaponReload()
    {
        throw new System.NotImplementedException();
    }
}
