using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameOver = false;
    public float force = 50;
    public GameObject ground;
    public Rigidbody playerRB;
    private bool onGround = false;
    private Animator playerAnim;
    public MoveLeft worldMovement;
  

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerRB.sleepThreshold = 0.0f;
    }

    
     void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == ground && gameOver == false)
        {
            onGround = true;
        }
        else
        {
            gameOver = true;
            Debug.Log("Game Over idiot");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
    

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            playerRB.AddForce(Vector3.up * 50 * force, ForceMode.Impulse);
            onGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }

        //Animation
        playerAnim.SetFloat("Speed_f",(worldMovement.speed/10));

    }
}
