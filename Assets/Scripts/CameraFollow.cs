using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    private Vector2 delta;
    public bool following = true;

    // Use this for initialization
    void Start()
    {
        if (target != null)
        {
            delta = transform.position - target.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (following)
        {
            Vector3 targetPosition = (Vector2)target.transform.position + delta;
            targetPosition.z = transform.position.z;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);            
        }
        else
        {

        }
    }
}
