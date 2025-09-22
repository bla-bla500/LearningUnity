using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 5;
    private PlayerController playerControllerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
        }

    }
}
