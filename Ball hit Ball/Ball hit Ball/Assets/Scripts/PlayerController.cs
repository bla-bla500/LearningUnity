using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float forwardInput;
    private Rigidbody playerRB;
    public GameObject center;
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        center = GameObject.Find("Center");
    }

    void Update()
    {

        forwardInput = Input.GetAxis("Vertical");
        playerRB.AddForce(center.transform.forward * forwardInput * speed);
    }
}
