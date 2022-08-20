using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPiece : MonoBehaviour, IComparable<TowerPiece>
{
    bool touchTower;

    Rigidbody2D rb;
    Camera cam;
    public float freezeDistPercentBonus = 20;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        touchTower = false;
    }

    private void Update()
    {
        if (touchTower)
        {
            if (transform.position.y < cam.transform.position.y - cam.orthographicSize - cam.orthographicSize * freezeDistPercentBonus / 100)
            {
                rb.isKinematic = true;
                rb.velocity = Vector3.zero;
            }
            else
            {
                rb.isKinematic = false;
            }
        }
    }

    public int CompareTo(TowerPiece other)
    {
        if (transform.position.y < other.transform.position.y)
        {
            return 1;
        }
        if (transform.position.y > other.transform.position.y)
        {
            return -1;
        }
        return 0;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!touchTower) TowerManager.instance.towerPiecesList.Add(this);
        touchTower = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (touchTower) TowerManager.instance.towerPiecesList.Remove(this);
        touchTower = false;
    }
}
