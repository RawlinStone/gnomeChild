using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class lightGradient : MonoBehaviour
{
    // Interpolate light color between two colors back and forth
    float duration = 1.0f;
    Color color0 = Color.yellow;
    Color color1 = Color.cyan;

    Light2D lt;

    void Start()
    {
        lt = GetComponent<Light2D>();
    }

    void Update()
    {
        // set light color
        float t = Mathf.PingPong(Time.time, duration) / duration;
        lt.color = Color.Lerp(color0, color1, t);
    }
}
