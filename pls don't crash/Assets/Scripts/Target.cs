
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

        spinSpeed = Random.Range(-spinSpeed,spinSpeed);

        thisRB = GetComponent<Rigidbody>();
        thisRB.AddForce(Vector3.up * Random.Range(12, 16), ForceMode.Impulse);
        thisRB.AddTorque(spinSpeed, spinSpeed, spinSpeed, ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-4,4),transform.position.y);
    }

    private void OnMouseDown() 
    {
        Instantiate(particles, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
        gameManagerScript.UpdateScore(pointValue);
        if (gameObject.CompareTag("Bad"))
        {
            gameManagerScript.gameOver = true;
            gameManagerScript.score = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    
}
