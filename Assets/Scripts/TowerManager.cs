using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager instance;

    public List<TowerPiece> towerPiecesList = new List<TowerPiece>();

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);

        instance = this;
    }

    private void Start()
    {
        
    }


    private void Update()
    {
        towerPiecesList.Sort();
    }
}
