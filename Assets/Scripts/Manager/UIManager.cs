using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour, IUIManager
{
    [SerializeField] private TMP_Text WaveText;
    [SerializeField] private TMP_Text ZombieCountText;
    [SerializeField] private List<Sprite> DangerIcons;
    [SerializeField] private Image DangerIcon;

    public void SetDangerLevel(int index)
    {
        DangerIcon.sprite = DangerIcons[index];
    }

    public void SetWaveUI(int currentWave, int zombieCount)
    {
        WaveText.text = "Wave " + currentWave;
        ZombieCountText.text = zombieCount.ToString();
    }
}
