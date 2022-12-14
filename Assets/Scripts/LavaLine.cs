using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaLine : MonoBehaviour
{
    public float fillingSpeed;

    public float startDelay;

    public static LavaLine instance;

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);

        instance = this;
    }

    private void Update()
    {
        if (startDelay > 0)
            startDelay -= Time.deltaTime;

        if(startDelay <= 0)
            transform.position = new Vector2(transform.position.x, transform.position.y + fillingSpeed * Time.deltaTime);
    }
}
