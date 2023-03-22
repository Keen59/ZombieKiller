using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class MovementSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation, ref StatsComponent stats, ref LocalToWorld localToWorld) =>
        {
            if (stats.IsAmmo)
            {
                translation.Value += (-localToWorld.Up) * stats.Speed * Time.DeltaTime;
            }
            else
            {
                if (translation.Value.z > -5f)
                {
                    translation.Value.z -= stats.Speed * Time.DeltaTime;
                }
            }
        });
    }
}
