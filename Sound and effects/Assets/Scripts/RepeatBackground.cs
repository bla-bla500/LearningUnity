using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    public GameObject background;
    private bool spawnedReplacement = false;
    private PlayerController playerControllerScript;
    void Start()
    {
        startPos = transform.position;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            if (gameObject.transform.position.x < startPos.x - 60 && spawnedReplacement == false)
            {
                Instantiate(background, startPos + new Vector3(52, 0, 0), transform.rotation);
                spawnedReplacement = true;
            }
            if (gameObject.transform.position.x < startPos.x - 111.1)
            {
                Destroy(gameObject);
            }
        }
       
    }
}
