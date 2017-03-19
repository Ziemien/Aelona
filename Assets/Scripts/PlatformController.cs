using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private float xDelta;
    private Rigidbody2D body;
    private CharacterController characterOnBoard;
    private bool canMove = true;

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
        body.isKinematic = false;
    }

    private void OnMouseUp()
    {
        body.isKinematic = true;
    }

    private void OnMouseDrag()
    {
        if (canMove)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var vector3 = new Vector3(mousePosition.x + xDelta,
                transform.position.y,
                transform.position.z);
            body.MovePosition(vector3);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        var collisionWithGround =
            coll.collider.gameObject.layer == LayerMask.NameToLayer("Ground");

        if (collisionWithGround && characterOnBoard != null)
        {
            // Get the direction from the center of the platform to the point of collission
            Vector2 directionToCollision = coll.contacts[0].point - (Vector2)transform.position;
            
            if (Mathf.Sign(characterOnBoard.direction.x) == Mathf.Sign(directionToCollision.x))
            {
                characterOnBoard.SetState(CharacterController.MovingState.Moving);
                characterOnBoard.UnassignParrent();
                characterOnBoard = null;

                // Stop the platform from moving while the player steps off
                // Prevents the platform from nudging the player once their rigidbody is
                // set to simulate again
                canMove = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision");
            var characterController = other.GetComponent<CharacterController>();
            characterController.AssignParent(transform);
            characterController.SetTargetToZero();
            characterOnBoard = characterController;

            actionIndicator.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Allow platform to move again once the player has completely
        // left the platform
        if (other.CompareTag("Player"))
        {
            canMove = true;
        }
    }
}