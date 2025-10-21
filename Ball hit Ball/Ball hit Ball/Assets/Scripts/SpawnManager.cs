using System.Collections;
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
    public GameObject powerUp;
    private bool isWaiting = false;

    private void Start()
    {
        StartCoroutine(PowerUpWait());
    }
    public void SpawnWave()
    {
        if (loopStarted == false)
        {
            loopStarted = true;
            int i = 0;
            while (i < (roundCount + 1))
            {
                SpawnEnemy();
                i = i + 1;
            }
            roundCount = roundCount + 1;
            loopStarted = false;
        }
        
    }
    void Update()
     {
         if (GameObject.Find("Enemy") == null && GameObject.Find("Enemy(Clone)") == null)
         {
            SpawnWave();
         }
    }

    IEnumerator PowerUpWait()
    {
        yield return new WaitForSeconds(20);
        Instantiate(powerUp, randomPosition(), gameObject.transform.rotation);
        StartCoroutine(PowerUpWait());
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


