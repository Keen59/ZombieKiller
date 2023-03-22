using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;
using Unity.Physics.Systems;
using Unity.Rendering;
using UnityEngine;
[UpdateAfter(typeof(EndFramePhysicsSystem))]

public partial class TriggerSystem : SystemBase
{

    private BuildPhysicsWorld buildPhysicsWorld;

    private StepPhysicsWorld stepPhysicsWorld;
    protected override void OnCreate()

    {

        buildPhysicsWorld = World.GetOrCreateSystem<BuildPhysicsWorld>();

        stepPhysicsWorld = World.GetOrCreateSystem<StepPhysicsWorld>();
    }

    // [BurstCompile]

    struct PickupOnTriggerSystemJob : ITriggerEventsJob

    {
        public float dt;
        [ReadOnly] public ComponentDataFromEntity<ZombieTag> ZombieTag;

        [ReadOnly] public ComponentDataFromEntity<AmmoTag> AmmoTag;

        [ReadOnly] public ComponentDataFromEntity<BarrackTag> BarrackTag;
        private EntityManager entityManager;

        public void Execute(TriggerEvent triggerEvent)

        {

            Entity entityA = triggerEvent.Entities.EntityA;

            Entity entityB = triggerEvent.Entities.EntityB;

            entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            if (ZombieTag.HasComponent(entityA) && ZombieTag.HasComponent(entityB))

            {

                UnityEngine.Debug.Log("This:" + entityA + " Other:" + entityB);

                return;

            }

            if (ZombieTag.HasComponent(entityA) && AmmoTag.HasComponent(entityB))
            {
                AmmoData Ammodata = entityManager.GetComponentData<AmmoData>(entityB);
                if (Ammodata.Usable)
                {
                    StatsComponent statsEntityB = entityManager.GetComponentData<StatsComponent>(entityB);
                    StatsComponent statsEntityA = entityManager.GetComponentData<StatsComponent>(entityA);
                    if (statsEntityA.HP > 0)
                    {

                        statsEntityA.HP -= statsEntityB.Damage;
                    }
                    statsEntityB.HP = 0;
                    Ammodata.Usable = false;
                    entityManager.SetComponentData(entityA, statsEntityA);
                    entityManager.SetComponentData(entityB, statsEntityB);
                    entityManager.SetComponentData(entityB, Ammodata);
                }

            }

            if (BarrackTag.HasComponent(entityA) && ZombieTag.HasComponent(entityB))
            {

                var BehaveEntity = entityManager.GetComponentData<ZombieBehavior>(entityB);
                if (BehaveEntity.behave != Enums.ZombieBehave.Attacking)
                {
                    entityManager.SetComponentData(entityB,new TargettedData { targettedEnemy=entityA});
                    entityManager.SetComponentData(entityB,new ZombieBehavior { behave=Enums.ZombieBehave.Attacking});


                }
            }

            //if (AmmoTag.HasComponent(entityA) && ZombieTag.HasComponent(entityB))
            //{
            //    Debug.Log("Ammo Reaced to zombie");

            //    StatsComponent statsEntityA = entityManager.GetComponentData<StatsComponent>(entityA);
            //    StatsComponent statsEntityB = entityManager.GetComponentData<StatsComponent>(entityB);
            //    if (statsEntityA.HP > 0)
            //    {
            //        statsEntityA.HP -= statsEntityB.Damage;

            //    }
            //    statsEntityB.HP = 0;
            //    entityManager.SetComponentData(entityA, statsEntityA);
            //    entityManager.SetComponentData(entityB, statsEntityB);



            //}
            //else if (ZombieTag.HasComponent(entityA) && BarrackTag.HasComponent(entityB))
            //{
            //    Debug.Log("Attacking to the wall");

            //    var BehaveEntityA = entityManager.GetComponentData<ZombieBehavior>(entityA);
            //    if (BehaveEntityA.behave != Enums.ZombieBehave.Attacking)
            //    {
            //        var TargettedData = entityManager.GetComponentData<TargettedData>(entityA);
            //        TargettedData.targettedEnemy = entityB;
            //        BehaveEntityA.behave = Enums.ZombieBehave.Attacking;
            //    }
            //}
        }

    }
    protected override void OnUpdate()

    {

        PickupOnTriggerSystemJob triggerJob = new PickupOnTriggerSystemJob()

        {

            AmmoTag = GetComponentDataFromEntity<AmmoTag>(true),

            ZombieTag = GetComponentDataFromEntity<ZombieTag>(true),
            BarrackTag = GetComponentDataFromEntity<BarrackTag>(true),
            dt = Time.DeltaTime
        };

        Dependency = triggerJob.Schedule(stepPhysicsWorld.Simulation, ref buildPhysicsWorld.PhysicsWorld, Dependency);

    }

}