using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class WaveManager : MonoBehaviour, IWaveManager
{
    [SerializeField] private int CurrentWave;
    [SerializeField] private List<GameObject> Nests;
    [SerializeField] private GameObject UIManager;
    [SerializeField] private int ZombieCount;
    private Entity WaveManagerEntity;
    private EntityManager entityManager;
    private INest INests;
    private IUIManager UIManagerInstance;
    private void Start()
    {
        for (int i = 0; i < Nests.Count; i++)
        {
            var Inest = Nests[i].GetComponent<INest>();
            INests = Inest;
        }
        INests.SpawnZombies();
        UIManagerInstance = UIManager.GetComponent<IUIManager>();
        UIManagerInstance.SetWaveUI(CurrentWave, CurrentWave * 2);
        ZombieCount = CurrentWave * 2;
        SpawnEntityWaveManager();
        SetEntityWaveManagerValue();
        CheckDanger(ZombieCount);
    }
    public int GetCurrentWave()
    {
        return CurrentWave;
    }
    private void CheckDanger(int currentWaveZombieCount)
    {
        if (currentWaveZombieCount < 20)
        {
            UIManagerInstance.SetDangerLevel(0);
        }
        else if (currentWaveZombieCount >= 20 && currentWaveZombieCount < 50)
        {
            UIManagerInstance.SetDangerLevel(1);
        }
        else if (currentWaveZombieCount >= 100)
        {
            UIManagerInstance.SetDangerLevel(2);
        }
    }
    public void NextWave()
    {
        CurrentWave++;
        ZombieCount = CurrentWave * 2;

        INests.SpawnZombies();
        UIManagerInstance.SetWaveUI(CurrentWave, ZombieCount);
        CheckDanger(ZombieCount);
    }

    public void CheckZombies()
    {
        if (ZombieCount == 0)
        {
            NextWave();
        }
    }

    public int GetZombieCount()
    {
        return ZombieCount;
    }

    public void SetZombieCount(int newZombieCount)
    {
        ZombieCount = newZombieCount;
    }
    private void SpawnEntityWaveManager()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        EntityArchetype entityArchetype = entityManager.CreateArchetype(
                    typeof(WaveManagerData)

      );
        WaveManagerEntity = entityManager.CreateEntity(entityArchetype);

    }
    private void SetEntityWaveManagerValue()
    {
        entityManager.SetComponentData(WaveManagerEntity, new WaveManagerData { ZombieCount = ZombieCount });

    }
}
