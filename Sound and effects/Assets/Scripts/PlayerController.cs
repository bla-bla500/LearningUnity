using System.Runtime.CompilerServices;
using System.Security;
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
    public ParticleSystem explosionPartical;
    public ParticleSystem dirtPartical;
    private AudioSource playerAudio;
    public AudioClip crashSound;
    public AudioClip jumpSound;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerRB.sleepThreshold = 0.0f;
        playerAudio = GetComponent<AudioSource>();
    }

    
     void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == ground && gameOver == false)
        {
            if (onGround == false)
            {
                dirtPartical.Play();
            }
            onGround = true;
        }
        else if (gameOver == false)
        {
            explosionPartical.Play();
            Debug.Log("should play");
            gameOver = true;
            Debug.Log("Game Over idiot");
            playerAudio.PlayOneShot(crashSound, 1.0f);
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
            dirtPartical.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        //Animation
        playerAnim.SetFloat("Speed_f",(worldMovement.speed/10));

    }

}
