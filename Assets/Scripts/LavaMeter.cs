using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LavaIndicator : MonoBehaviour
{
    public float minimalLavaDist;
    public GameObject indicatorGO;
    public TMP_Text meterText;


    private void Start()
    {
        indicatorGO.SetActive(false);
    }

    void Update()
    {
        if(TowerManager.instance.towerPiecesList.Count != 0)
        {
            if (TowerManager.instance.towerPiecesList[0].transform.position.y - LavaLine.instance.transform.position.y > minimalLavaDist)
            {
                indicatorGO.SetActive(true);
                meterText.text = (Mathf.RoundToInt(TowerManager.instance.towerPiecesList[0].transform.position.y - LavaLine.instance.transform.position.y)).ToString() + "m";
            }
            else indicatorGO.SetActive(false);
        }
    }
}
