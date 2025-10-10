using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Runtime.CompilerServices;
using System.Data;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public List<GameObject> targets;
    public List<GameObject> targetsActive;
    public float spawnRate = 1.0f;
    public bool gameOver = false;
    public TextMeshProUGUI gameOverText;
    public GameObject restartButton;

    void Start()
    {
        gameOverText = GameObject.Find("Game Over Text").GetComponent<TextMeshProUGUI>();
        restartButton = GameObject.Find("Restart Button");
        restartButton.SetActive(false);
        StartCoroutine(SpawnTarget());
        scoreText.text = ("Score: " + score);
    }

    IEnumerator SpawnTarget()
    {
        while (gameOver == false)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = UnityEngine.Random.Range(0, targets.Count);
            GameObject x = Instantiate(targets[index]);
            if (gameOver)
            {
                Destroy(x);
            }
            targetsActive.Add(x);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = ("Score: " + score);
    }

    public void Kill(GameObject whatObject)
    {
        Predicate<GameObject> inList = obj => obj.GetInstanceID() == whatObject.GetInstanceID();
        if (targetsActive.Exists(inList)) 
        {
            targetsActive.Remove(targetsActive[targetsActive.FindIndex(inList)]);
            targetsActive.TrimExcess();
        }
        Destroy(whatObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        gameOverText.enabled = true;
        restartButton.SetActive(true);
        gameOver = true;
        int i = 0;
        while (i < targetsActive.Count) 
        {
            Destroy(targetsActive[i]);
            i++;
        }
    }
}
