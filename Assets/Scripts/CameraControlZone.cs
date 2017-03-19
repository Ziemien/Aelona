using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CameraControlZone : MonoBehaviour
{
    private CameraFollow cameraFollow;
    public bool enableZone = true;

    void Start()
    {
        Collider2D collider = GetComponent<BoxCollider2D>();
        collider.isTrigger = true;

        cameraFollow = FindObjectOfType<CameraFollow>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        cameraFollow.following = enableZone;
    }
}
