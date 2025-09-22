using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float force = 50;
    public GameObject ground;
    public Rigidbody playerRB;
    private bool onGround = false;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    
     void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == ground)
        {
            onGround = true;
            
        }
    }
    

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            playerRB.AddForce(Vector3.up * 50 * force, ForceMode.Impulse);
            onGround = false;
        }
    }
}
