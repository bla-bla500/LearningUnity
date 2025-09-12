using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 23f;
    public float rangex = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        //Keeps Player Inbounds
        if (transform.position.x < rangex & transform.position.x > (rangex * -1))
        {
            //Moves player based on input and speed
            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        }
        else if (transform.position.x >= rangex & horizontalInput == 1)
        {
            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        }
        else if (transform.position.x <= (rangex * -1) & horizontalInput == -1)
        {
            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        }
        

    }
}
