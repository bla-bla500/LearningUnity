using UnityEngine;

public class SpinPropeller : MonoBehaviour
{
    public Vector3 spinSpeed = new Vector3(0, 0, 5);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spinSpeed);
    }
}
