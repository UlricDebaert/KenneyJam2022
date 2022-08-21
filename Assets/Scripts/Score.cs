using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreUI;
    public TMP_Text highScoreUI;

    public float score;
    public float highscore;

    private void Start()
    {
        score = 0;
        if (PlayerPrefs.GetFloat("Highscore") != 0)
        {
            highscore = PlayerPrefs.GetFloat("Highscore");
            highScoreUI.text = "Highscore : " + PlayerPrefs.GetFloat("Highscore").ToString();
        }
    }

    private void Update()
    {
        if (TowerManager.instance.towerPiecesList.Count != 0)
            if(TowerManager.instance.towerPiecesList[0].transform.position.y > LavaLine.instance.transform.position.y)
                score = Mathf.RoundToInt(TowerManager.instance.towerPiecesList[0].transform.position.y);

        if (Input.GetKeyDown(KeyCode.H))
        {
            highscore = 0;
            PlayerPrefs.SetFloat("Highscore", highscore);
            highScoreUI.text = "Highscore : " + PlayerPrefs.GetFloat("Highscore").ToString();
        }

        UpdateUI();

    }

    void UpdateUI()
    {
        scoreUI.text = "Height : " + score.ToString();

        if(score>=highscore)
        {
            highScoreUI.text = "Highscore : " + PlayerPrefs.GetFloat("Highscore").ToString();
            highscore = score;
        }
        print(PlayerPrefs.GetFloat("Highscore"));
        PlayerPrefs.SetFloat("Highscore", highscore);
    }
}
