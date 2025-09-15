using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private int animalIndex;
    private float animalPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animalIndex = Random.Range(0, 2);
        animalPosition = Random.Range(-19f, 19f);

        if (Input.GetKeyDown(KeyCode.S))
        { 
            Instantiate(animalPrefabs[animalIndex], new Vector3(animalPosition, -10, 0), animalPrefabs[animalIndex].transform.rotation);
        }
    }
}
