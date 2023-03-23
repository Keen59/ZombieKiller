using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Physics.Systems;
using Unity.Transforms;
using UnityEngine;

public class AttackSystem : ComponentSystem
{
    float time;
    EntityManager manager;
    protected override void OnCreate()
    {

        manager = World.DefaultGameObjectInjectionWorld.EntityManager;

    }
    protected override void OnUpdate()
    {
        Entities.ForEach((ref ZombieBehavior behavior, ref StatsComponent ZombieStats, ref TargettedData enemyData) =>
        {
            if (behavior.behave == Enums.ZombieBehave.Attacking)
            {
                time += Time.DeltaTime;
                if (time >= 3)
                {
                    Debug.Log("times up attack");
                    var enemy = enemyData.targettedEnemy;
                    Attack(enemy, ZombieStats.Damage);
                    behavior.behave = Enums.ZombieBehave.Attacked;
                    time = 0;
                }
            }
        });
    }
    private void Attack(Entity AttackedObject, float ZombieDamage)
    {
        StatsComponent stats = manager.GetComponentData<StatsComponent>(AttackedObject);
        stats.HP -= ZombieDamage;
        EventManager.ZombieAttackVFXEventCall();
        manager.SetComponentData(AttackedObject, stats);
    }
}
