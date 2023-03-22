using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Jobs;
using UnityEngine;

public class DestroySystem : JobComponentSystem
{
    private EndSimulationEntityCommandBufferSystem endSimCommandBufferSystem;
    [BurstCompile]
    public struct DestroyJob : IJobForEachWithEntity<StatsComponent>
    {
        public float dt;
        public EntityCommandBuffer.Concurrent CommandBuffer;
        public void Execute(Entity entity, int index, ref StatsComponent stats)
        {

            if (stats.IsAmmo)
            {

                if (stats.HP < 0f)
                {

                    CommandBuffer.DestroyEntity(index, entity);
                }
                else
                {
                    stats.HP -= dt;
                }
            }
            else if (stats.HP <= 0f)
            {
              
                CommandBuffer.DestroyEntity(index, entity);
            }

        }


    }
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new DestroyJob()
        {
            dt = Time.DeltaTime,
            CommandBuffer = endSimCommandBufferSystem.CreateCommandBuffer().ToConcurrent()
        };

        var jobHandle = job.Schedule(this, inputDeps);
        endSimCommandBufferSystem.AddJobHandleForProducer(jobHandle);
        return jobHandle;
    }

    protected override void OnCreate()
    {
        endSimCommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        base.OnCreate();
    }
}
