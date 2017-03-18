using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    float startFixedDeltaTime;
    float startTimeScale;

    float scale = 1;

    // Use this for initialization
    void Start()
    {
        startFixedDeltaTime = Time.fixedDeltaTime;
        startTimeScale = Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            scale = Mathf.Max(0.1f, scale - 0.05f);
        }
        else
        {
            scale = Mathf.Min(1, scale + 0.05f);
        }

        Time.timeScale = startTimeScale * scale;
        Time.fixedDeltaTime = startFixedDeltaTime * scale;
    }
}
