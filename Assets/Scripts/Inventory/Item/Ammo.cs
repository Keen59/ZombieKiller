using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Ammo : Item
{
    [SerializeField] private AmmoType Type;
    [SerializeField] private float Damage;
    [SerializeField] private float Speed;


    public void SetValues(float damage, float speed)
    {
        Damage = damage;
        Speed = speed;
        StartECSystem();
    }
    private void StartECSystem()
    {
     // var entity=Instantiate(ammoEntity.g,transform.localPosition,transform.rotation);
      //  Destroy(entity);
        //Destroy(gameObject);
    }

  
    public void Update()
    {
      
    }
}
