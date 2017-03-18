using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private float xDelta;
    private Rigidbody2D _rigidbody2D;

    // Use this for initialization
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
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

        var vector3= new Vector3(mousePosition.x + xDelta,
            transform.position.y,
            transform.position.z);

        _rigidbody2D.MovePosition(vector3);

    }


}