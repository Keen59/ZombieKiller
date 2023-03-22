using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Nest : MonoBehaviour,INest
{
    [SerializeField] private List<GameObject> ZombieGameObjectTypes;
                     private GameObject CurrentSpawnableZombie;
    [SerializeField] private ZombieTypes zombieType;
                     private IWaveManager GetWaveManager;
    [SerializeField] private GameObject WaveManager;
    private void Awake()
    {
        GetWaveManager=WaveManager.GetComponent<IWaveManager>();
        Debug.Log(GetWaveManager.GetCurrentWave());
        var CurrentZombie = zombieType;

        switch (CurrentZombie)
        {

            case ZombieTypes.Fat:
                CurrentSpawnableZombie = ZombieGameObjectTypes[0];
                break;
            case ZombieTypes.Injured:
                CurrentSpawnableZombie = ZombieGameObjectTypes[1];
                break;
            case ZombieTypes.Skinny:
                CurrentSpawnableZombie = ZombieGameObjectTypes[2];
                break;
            default:
                break;
        }

    }

    //private async void SpawnZombiesAsync()
    //{
    //    int currentWave=GetWaveManager.GetCurrentWave();
    //    var result = await Task.Run(() =>
    //        {
    //            List<GameObject> CurrentSpawnedWaveZombiesList = new List<GameObject>();
    //            for (int i = 0; i < currentWave; i++)
    //            {
    //                var newPosition = new Vector3(Random.Range(-5,5f),1, Random.Range(-5, 5f)) + transform.position;
    //                var SpawnedZombie = Instantiate(CurrentSpawnableZombie, newPosition, Quaternion.identity);
    //                CurrentSpawnedWaveZombiesList.Add(SpawnedZombie);
    //            }
    //                return CurrentSpawnedWaveZombiesList;

    //        });

    //    Debug.Log(result.Count);
    //}

    public void SpawnZombies()
    {  var zombieCount = GetWaveManager.GetCurrentWave()*2;
        for (int i = 0; i < zombieCount; i++)
        {
            var newPosition = new Vector3(Random.Range(-5, 5f), 1, Random.Range(-5, 5f)) + transform.position;
            Instantiate(CurrentSpawnableZombie, newPosition, Quaternion.Euler(0, 180, 0));
        }
    }


}
[System.Serializable]
public enum ZombieTypes
{
    None, Skinny, Fat, Injured,
}