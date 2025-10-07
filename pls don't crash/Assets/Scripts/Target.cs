using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody thisRB;
    public float spinSpeed = 5;
    void Start()
    {
        spinSpeed = Random.Range(-spinSpeed,spinSpeed);

        thisRB = GetComponent<Rigidbody>();
        thisRB.AddForce(Vector3.up * Random.Range(12, 16), ForceMode.Impulse);
        thisRB.AddTorque(spinSpeed, spinSpeed, spinSpeed, ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-4,4),transform.position.y);
    }

    private void OnMouseDown() 
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
