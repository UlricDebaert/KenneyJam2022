using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecapsScore : MonoBehaviour
{
    public TMP_Text highScoreTextRecaps;
    public TMP_Text scoreTextRecaps;

    public Score score;


    void Update()
    {
        highScoreTextRecaps.text = "Highscore : "+ score.highscore.ToString();
        scoreTextRecaps.text = "Height : " + score.score.ToString();
    }
}
