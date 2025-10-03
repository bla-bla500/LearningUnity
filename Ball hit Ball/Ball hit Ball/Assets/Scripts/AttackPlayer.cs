using System.Collections;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Rendering;

public class AttackPlayer : MonoBehaviour
{
    public float speed = 3.0f;
    private GameObject player;
    private Rigidbody RB;
    private Vector3 lookDirection;
    private PlayerController playerControllerScript;

    void Start()
    {
        player = GameObject.Find("Player");
        playerControllerScript = player.GetComponent<PlayerController>();
        RB = gameObject.GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (playerControllerScript.gameIsOver == false)
        {
            lookDirection = (player.transform.position - gameObject.transform.position).normalized;
            if (transform.position.y > 0)
            {
                RB.AddForce(lookDirection * speed);
            }
            if (Fell(gameObject))
            {
                Destroy(gameObject);
            }
        }
    }
    
    public bool Fell(GameObject thisObject)
    {
        if (thisObject.transform.position.y <= -10)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
