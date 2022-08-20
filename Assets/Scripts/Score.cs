using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreUI;

    float score;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        if (TowerManager.instance.towerPiecesList.Count != 0)
            score = Mathf.RoundToInt(TowerManager.instance.towerPiecesList[0].transform.position.y);

        UpdateUI();
    }

    void UpdateUI()
    {
        scoreUI.text = "Score : " + score.ToString();
    }
}
