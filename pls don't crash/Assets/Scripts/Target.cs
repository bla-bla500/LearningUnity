
using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue;
    private Rigidbody thisRB;
    public float spinSpeed = 5;
    private GameManager gameManagerScript;
    public ParticleSystem particles;
    void Start()
    {
            gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

            spinSpeed = Random.Range(-spinSpeed, spinSpeed);

            thisRB = GetComponent<Rigidbody>();
            thisRB.AddForce(Vector3.up * Random.Range(12, 16), ForceMode.Impulse);
            thisRB.AddTorque(spinSpeed, spinSpeed, spinSpeed, ForceMode.Impulse);
            transform.position = new Vector3(Random.Range(-4, 4), transform.position.y);
    }


    private void OnMouseDown() 
    {
        if (gameManagerScript.gameOver == false)
        {
            Instantiate(particles, gameObject.transform.position, gameObject.transform.rotation);
            gameManagerScript.Kill(gameObject);
            gameManagerScript.UpdateScore(pointValue);
            if (gameObject.CompareTag("Bad"))
            {
                gameManagerScript.GameOver();
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManagerScript.Kill(gameObject);
        if (other.name == "Sensor" && CompareTag("Bad") == false)
        {
            gameManagerScript.GameOver();
        }
    }

    
}
