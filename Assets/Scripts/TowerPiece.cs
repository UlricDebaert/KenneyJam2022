using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPiece : MonoBehaviour, IComparable<TowerPiece>
{
    bool touchTower;

    private void Start()
    {
        touchTower = false;
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
}
