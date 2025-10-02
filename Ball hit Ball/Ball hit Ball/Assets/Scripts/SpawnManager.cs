using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.PlayerLoop;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public int roundCount = 1;
    public GameObject ground;
    public bool hasSpawned = false;
    public bool loopStarted = false;

     void Update()
     {
         
         if (GameObject.Find("Enemy") == null && loopStarted == false)
         {
            loopStarted = true;
            int i = 0;
            while (i < (roundCount))
            {
                SpawnEnemy();
                i = i + 1;
            }
            roundCount = roundCount + 1;
            loopStarted = false;
        }
     } 


    Vector3 randomPosition()
    {
        hasSpawned = false;
        float x = Random.Range(-13f, 13f);
        float z = Random.Range(-11f, 11f);
        return new Vector3(x, 0, z);
    }

    void SpawnEnemy()
    {
        Instantiate(enemy, randomPosition(), gameObject.transform.rotation);
    }
}


