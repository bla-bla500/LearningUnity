using UnityEngine;

public class DestroyOnExit : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }
}
