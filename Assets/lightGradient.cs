using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class lightGradient : MonoBehaviour
{
    float duration = 1.0f;
    Color color0 = Color.yellow;
    Color color1 = Color.cyan;

    Light lt;

    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        lt.color = Color.Lerp(color0, color1, t);
    }
}
