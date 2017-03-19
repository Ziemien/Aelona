using UnityEngine;

public class CharacterController : MonoBehaviour
{
    MovingState movingState = MovingState.Moving;
    private Rigidbody2D body;

    public enum MovingState
    {
        Idle,
        Moving
    }

    public float speed = 1;
    public Vector2? target;
    private float distanceThreshold = 0.1f;


    // Use this for initialization
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        switch (movingState)
        {
            case MovingState.Moving:
                Move();
                break;
        }
    }

    public Vector2 direction = Vector2.left;

    private void Move()
    {
        if (target.HasValue)
            {
            var targetValue = target.Value;

            if (Vector2.Distance(targetValue, transform.localPosition) < distanceThreshold)
            {
                target = null;
                movingState = MovingState.Idle;
            }
            else
            {
                direction = (targetValue - (Vector2)transform.localPosition).normalized;
                Move(direction);
            }

        }
        else
        {
            Move(direction);
        }
    }

    private void Move(Vector3 direction)
    {
        transform.localPosition = transform.localPosition + direction * speed * Time.deltaTime;
    }

    public void SetTargetToZero()
    {
        this.target = new Vector2(0, transform.localPosition.y);
    }


    public void SetState(MovingState newState)
    {
        movingState = newState;
    }

    public void AssignParent(Transform parentTransform)
    {
        transform.SetParent(parentTransform);
        body.simulated = false;
        body.velocity = Vector2.zero;
    }

    public void UnassignParrent()
    {
        transform.SetParent(null);
        body.simulated = true;
    }
}