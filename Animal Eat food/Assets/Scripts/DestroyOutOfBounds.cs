using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > 50 || transform.position.z < -50)
        {
            Destroy(gameObject);
        }
    }
}
