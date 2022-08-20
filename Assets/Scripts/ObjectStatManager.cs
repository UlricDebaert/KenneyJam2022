using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStatManager : MonoBehaviour
{
    public float weight;
    public float gravity;
    public float price;
    public PhysicsMaterial2D phyMat;

    private Rigidbody2D objRb;

    private void Start()
    {
        objRb = GetComponent<Rigidbody2D>();
        objRb.mass = weight;
        objRb.gravityScale = gravity;
        objRb.sharedMaterial = phyMat;
    }
}
