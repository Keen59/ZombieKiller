using UnityEngine;
using Unity.Entities;
using Unity.Rendering;
using Unity.Mathematics;
using Unity.Transforms;
using System;


public abstract class Weapon : Item
{

    [SerializeField] private WeaponType Type;
    [SerializeField] private GameObject Ammo;
    [SerializeField] private Transform Barrel;
    [SerializeField] private float Damage;
    [SerializeField] private float FireRate;
    [SerializeField] private float GunPower;
    protected GunAbility gunAbility;
    [SerializeField] private GameObject WeaponAbilities;
    private void Start()
    {
        gunAbility=WeaponAbilities.GetComponent<GunAbility>();
    }



    public abstract void Fire();
    public abstract void Reload();
    public GameObject GetAmmo() { return Ammo; }
    public Transform GetBarrel() { return Barrel; }

    public float GetDamage() { return Damage; }
    public float GetGunPower() { return GunPower; }
    public float GetFireRate() { return FireRate; }
}
