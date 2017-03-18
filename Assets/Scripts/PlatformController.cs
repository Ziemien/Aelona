using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private float xDelta;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        xDelta = transform.position.x - mousePosition.x;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x + xDelta,
            transform.position.y,
            transform.position.z);
    }
}