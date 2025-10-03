using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float forwardInput;
    private float horizontalInput;
    private Rigidbody playerRB;
    public GameObject center;
    public bool gameIsOver = false;
    public GameObject powerUpIndicator;
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

        powerUpIndicator.transform.position = transform.position + new Vector3(0,1,0);
    }

    public bool hasPowerup = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerUpIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdown());
        }
        else if (other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            other.gameObject.GetComponent<Rigidbody>().linearVelocity = (playerRB.linearVelocity * -1) * 5;
        }
    }

    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(10);
        hasPowerup = false;
        powerUpIndicator.gameObject.SetActive(false);
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
