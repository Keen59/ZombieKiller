using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{

    public override void Fire()
    {
        Weapon weapon=this;
        gunAbility.WeaponFire(weapon);
    }

    public override void Reload()
    {
        Weapon weapon = new Rifle(); 
        //weaponAbilities.WeaponReload(weapon);

    }
}
