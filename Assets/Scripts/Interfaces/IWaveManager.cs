using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWaveManager 
{
    void NextWave();
    void CheckZombies();
    int GetZombieCount();
    void SetZombieCount(int newZombieValue);
    int GetCurrentWave();
}
