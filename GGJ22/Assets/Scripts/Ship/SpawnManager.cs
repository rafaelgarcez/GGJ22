using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] Meteor[] meteor;
    [SerializeField] Transform spawnPosition;
    [SerializeField] GameObject swap;

    public float TimeToSpawn;
    public bool CanSpawn = true;
    public float MeteorSpeed;

    public void SpawnMeteor()
    {
        /*
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
        */
    }

    public void StartTimer()
    {
        StartCoroutine(MeteorTimer());
    }

    IEnumerator MeteorTimer()
    {
        while (CanSpawn && gameController.IsGameRunning)
        {
            SpawnSingleMeteor();
            yield return new WaitForSeconds(TimeToSpawn);
        }
        
    }

    IEnumerator MeteorWaitForSeconds()
    {
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(MeteorTimer());
    }

    void SpawnSingleMeteor()
    {

        int index = Random.Range(0, 3);

        Meteor tempMeteor = GameObject.Instantiate(meteor[index], spawnPosition.position, spawnPosition.rotation);
        MeteorSetup(tempMeteor);
    }
/*
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
*/
    void MeteorSetup(Meteor tempMeteor) => tempMeteor.Setup(MeteorSpeed, gameController);


    public void SpawnSwap()
    {
        CanSpawn = false;
        GameObject tempSwap = GameObject.Instantiate(swap, spawnPosition.position, spawnPosition.rotation);
        tempSwap.transform.DOMoveY(-6.7f, 1f).SetEase(Ease.Linear).OnComplete(() => SpawnDestroy(tempSwap));
    }

    void SpawnDestroy(GameObject tempSwap)
    {
        Destroy(tempSwap);
        CanSpawn = true;
        //StartCoroutine(MeteorTimer());
        StartCoroutine(MeteorWaitForSeconds());
    }
    /*
    public void SpawnRedCrate()
    {
        RedCrate tempRedCrate = GameObject.Instantiate(redCrate, crateTestSpawnpoint.position, crateTestSpawnpoint.rotation);
        tempRedCrate.Setup(1.5f, gameController);
         
    }
    */
}
