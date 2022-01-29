using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MeteorSpawnManager : MonoBehaviour
{

    [SerializeField] Meteor meteor;
    [SerializeField] Transform[] spawnPositions;

    public void SpawnMeteor()
    {
        Meteor tempMeteor = GameObject.Instantiate(meteor, spawnPositions[0].position, spawnPositions[0].rotation);
        tempMeteor.Setup(1.5f);

    }

}
