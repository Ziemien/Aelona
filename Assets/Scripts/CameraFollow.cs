using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    private float xDelta;

    // Use this for initialization
    void Start()
    {
        if (target != null)
        {
            xDelta = transform.position.x - target.transform.position.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x + xDelta,
                                         transform.position.y,
                                         transform.position.z);
    }
}
