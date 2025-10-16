using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    private float spawnTracker;
    [SerializeField] private float height;
    public GameObject spherePrefab;
    private Ray currentRay;
    public Camera cam;
    void Start()
    {
        
    }

    void Update()
    {
        //float randX = Random.Range(0f, 1f);
        //float randY = Random.Range(0f, 1f);
        //currentRay = cam.ViewportPointToRay(new Vector3(randX, randY, 0));
        currentRay = cam.ScreenPointToRay(Input.mousePosition);
        if (spawnTracker > spawnRate)
        {
            Physics.Raycast(currentRay.origin, currentRay.direction, out RaycastHit hitInfo);
            transform.position = hitInfo.point + new Vector3(0, height, 0);
            Instantiate(spherePrefab, gameObject.transform.position + new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f)), gameObject.transform.rotation);
            spawnTracker = 0;
        }
        else
        {
            spawnTracker += (Time.deltaTime * 100);
        }
        //Physics.Raycast(currentRay.origin, currentRay.direction, out RaycastHit hitInfoForDebug);
        //Debug.DrawLine(currentRay.origin, hitInfoForDebug.point, Color.white, 0.1f);
    }
}
