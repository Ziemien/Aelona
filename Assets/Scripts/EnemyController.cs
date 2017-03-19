using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public CharacterController player;
    public float speed = 1;

    // Use this for initialization
    void Start()
    {
        if (player == null)
        {
            player = FindObjectOfType<CharacterController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }
}
