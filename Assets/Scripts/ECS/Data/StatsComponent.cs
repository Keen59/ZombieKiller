using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
[GenerateAuthoringComponent]
public struct StatsComponent : IComponentData
{
    public bool IsAmmo;
    public bool IsZombie;
    public float HP;
    public float Speed;
    public float DeltaTime;
    public float Damage;
}
