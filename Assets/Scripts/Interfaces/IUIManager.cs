using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIManager 
{
    void SetWaveUI(int currentWave, int zombieCount);
    void SetDangerLevel(int index);
}
