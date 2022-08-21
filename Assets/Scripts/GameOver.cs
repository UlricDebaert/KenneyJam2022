using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPannel;

    public float lavaDistGameOver;

    void Start()
    {
        gameOverPannel.SetActive(false);
    }


    void Update()
    {
        if(TowerManager.instance.towerPiecesList.Count != 0)
        {
            if (TowerManager.instance.towerPiecesList[0].transform.position.y < LavaLine.instance.gameObject.transform.position.y - lavaDistGameOver)
            {
                gameOverPannel.SetActive(true);
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
