using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Runtime.CompilerServices;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public List<GameObject> targets;
    public float spawnRate = 1.0f;
    public bool gameOver = false;

    void Start()
    {
        StartCoroutine(SpawnTarget());
        scoreText.text = ("Score: " + score);
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = UnityEngine.Random.Range(0, targets.Count);
            Instantiate(targets[index]); 
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = ("Score: " + score);
    }

    void Update()
    {
        
    }
}
