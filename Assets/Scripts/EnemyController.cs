using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public CharacterController player;
    public float speed = 1;
    public float turnSpeed = 90;

    private ParticleSystem explosionParticles;
    private SpriteRenderer spriteRenderer;
    public bool isDead;

    // Use this for initialization
    void Start()
    {
        explosionParticles = GetComponentInChildren<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (player == null)
        {
            player = FindObjectOfType<CharacterController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }

        Vector2 direction = player.transform.position - transform.position;
        float targetRotationZ = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) + 90;

        float difference = targetRotationZ - transform.rotation.eulerAngles.z;
        float rotationThisFrame = turnSpeed * Time.deltaTime;
        if (difference > rotationThisFrame)
        {
            transform.Rotate(0, 0, rotationThisFrame);
        }
        else
        {
            transform.Rotate(0, 0, difference);
        }

        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            spriteRenderer.enabled = false;
            explosionParticles.Play();
            isDead = true;
        }
    }
}
