using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody2D body;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.right * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(Vector3.up * 300);
        }
    }
}
