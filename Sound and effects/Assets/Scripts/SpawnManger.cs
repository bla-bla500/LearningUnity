using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject player;
    void Start()
    {
        InvokeRepeating("SpawnObstical", 3, Random.Range(2,5));
    }

    void Update()
    {
        
    }

    void SpawnObstical()
    {
        Instantiate(prefabs[Random.Range(0, 3)], (new Vector3 (player.transform.position.x + 50, 0, player.transform.position.z)), gameObject.transform.rotation);
    }
}
