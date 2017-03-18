using UnityEngine;

public class CharacterController : MonoBehaviour
{
    MovingState movingState = MovingState.Moving;
    private Rigidbody2D _rigidbody2D;

    public enum MovingState
    {
        Idle,
        Moving
    }

    public float speed = 1;
    public Vector2? target;
    private float distanceThreshold = 0.25f;

    // Use this for initialization
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
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

    private void Move()
    {
        if (target.HasValue)
        {
            var targetValue = target.Value;

            if (Vector2.Distance(targetValue, transform.position) < distanceThreshold)
            {
                target = null;
            }
            else
            {
                Vector2 direction = (targetValue - (Vector2)transform.position).normalized;
                Move(direction);
            }

        }
        else
        {
            Move(Vector2.right);
        }
    }

    private void Move(Vector3 direction)
    {
        transform.localPosition = transform.localPosition + direction * speed * Time.deltaTime;
    }

    public void SetTarget(Vector2 targetPoint)
    {
        this.target = targetPoint;
    }


    public void SetState(MovingState newState)
    {
        movingState = newState;
    }

    public void AssignParent(Transform parentTransform)
    {
        transform.SetParent(parentTransform);
        _rigidbody2D.simulated = false;
    }

    public void UnassignParrent()
    {
        transform.SetParent(null);
        _rigidbody2D.simulated = true;
    }
}