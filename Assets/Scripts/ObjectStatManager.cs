using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStatManager : MonoBehaviour
{
    public string cardName;
    public Sprite cardImage;
    public float weight;
    public float gravity;
    public float price;
    public PhysicsMaterial2D phyMat;

    //private Rigidbody2D objRb;

    private void Start()
    {
        //objRb = GetComponent<Rigidbody2D>();
        //objRb.mass = weight;
        //objRb.gravityScale = gravity;
        //objRb.sharedMaterial = phyMat;
    }
}
