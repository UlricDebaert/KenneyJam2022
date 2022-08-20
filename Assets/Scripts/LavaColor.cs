using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaColor : MonoBehaviour
{
    public Color ColorA;
    public Color ColorB;

    SpriteRenderer sr;

    public float colorSpeed = 1;
    float timer; 

    void Start()
    {
        timer = 0.0f;
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        timer += Time.deltaTime * colorSpeed;

        sr.color = Color.Lerp(ColorA, ColorB, Mathf.Sin(timer) / 2 + 0.5f);
    }
}
