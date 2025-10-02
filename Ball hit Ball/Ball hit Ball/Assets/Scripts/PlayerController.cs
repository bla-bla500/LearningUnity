using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float forwardInput;
    private float horizontalInput;
    private Rigidbody playerRB;
    public GameObject center;
    public bool gameIsOver = false;
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        center = GameObject.Find("Center");
    }

    void Update()
    {
        forwardInput = Input.GetAxisRaw("Vertical");
        playerRB.AddForce(center.transform.forward * forwardInput * speed);

        horizontalInput = Input.GetAxisRaw("Horizontal");
        playerRB.AddForce(center.transform.right * horizontalInput * speed);

        if (Fell(gameObject))
        {
            Debug.Log("You Lose");
            gameIsOver = true;
            Destroy(gameObject);
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
