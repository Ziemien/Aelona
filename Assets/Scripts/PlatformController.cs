using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private float xDelta;
    private Rigidbody2D body;
    private CharacterController characterOnBoard;

    public GameObject actionIndicator;


    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        actionIndicator.SetActive(false);
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

        var vector3 = new Vector3(mousePosition.x + xDelta,
            transform.position.y,
            transform.position.z);

        body.MovePosition(vector3);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        var collisionWithGround =
            coll.collider.gameObject.layer == LayerMask.NameToLayer("Ground");

        if (collisionWithGround && characterOnBoard != null)
        {
            characterOnBoard.SetState(CharacterController.MovingState.Moving);
            characterOnBoard.UnassignParrent();
            characterOnBoard = null;
        }
    }

//    private void OnTriggerExit2D(Collider2D other)
//    {
//        Debug.Log("Hello");
//        triggered = false;
//    }

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            var characterController = other.GetComponent<CharacterController>();
            characterController.AssignParent(transform);
            characterController.SetTargetToZero();
            characterOnBoard = characterController;

            actionIndicator.SetActive(true);

            //terible hack
            triggered = true;
        }
    }
}