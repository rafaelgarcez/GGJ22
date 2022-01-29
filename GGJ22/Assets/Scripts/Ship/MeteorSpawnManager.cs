using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MeteorSpawnManager : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] Meteor[] meteor;
    [SerializeField] Meteor[] meteorShower;
    [SerializeField] Transform[] spawnPositions;
    [SerializeField] Transform[] meteorShowerSpawnPositions;
    [SerializeField] GameObject swap;
    

    public void SpawnMeteor()
    {
        int index = Random.RandomRange(0, 2);
        switch (index)
        {
            case 0:
                SpawnSingleMeteor();
                break;

            case 1:
                SpawnMeteorShower();
                break;
            default:
                break;
        }

    }

    void SpawnSingleMeteor()
    {

        int index = Random.Range(0, spawnPositions.Length);

        Meteor tempMeteor = GameObject.Instantiate(meteor[0], spawnPositions[index].position, spawnPositions[index].rotation);
        MeteorSetup(tempMeteor);
    }

    void SpawnMeteorShower()
    {
        Meteor tempMeteor = new Meteor();
        int index = Random.Range(0, 3);
        
        if (index < 2)
            tempMeteor = GameObject.Instantiate(meteorShower[0], meteorShowerSpawnPositions[index].position, meteorShowerSpawnPositions[index].rotation);
        else
            tempMeteor = GameObject.Instantiate(meteorShower[1], meteorShowerSpawnPositions[2].position, meteorShowerSpawnPositions[2].rotation);

        MeteorSetup(tempMeteor);

    }

    void MeteorSetup(Meteor tempMeteor) => tempMeteor.Setup(1.5f, gameController);


    public void SpawnSwap()
    {
        GameObject tempSwap = GameObject.Instantiate(swap, spawnPositions[0].position, spawnPositions[0].rotation);

        tempSwap.transform.DOMoveY(-6.7f, 1.5f).SetEase(Ease.Linear).OnComplete(() => SpawnDestroy(tempSwap));
    }

    void SpawnDestroy(GameObject tempSwap)
    {
        Destroy(tempSwap);
        SpawnMeteor();
    }


}
