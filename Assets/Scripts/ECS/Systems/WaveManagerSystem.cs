using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class WaveManagerSystem : ComponentSystem
{
    //public WaveManager WaveManagerObj;
    protected override void OnUpdate()
    {
        Entities.ForEach((ref WaveManagerData waveManagerData) =>
        {
            //if (waveManagerData.ZombieCount<=0)
            //{
            //    WaveManagerObj.GetComponent<IWaveManager>().NextWave();
            //}
        });
    }
}
