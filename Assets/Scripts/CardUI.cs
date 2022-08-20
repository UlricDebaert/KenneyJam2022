using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{
    public TMP_Text cardName;
    public Image cardImage;
    public GameObject[] manaList;
    ObjectStatManager objStatManager;

    private void Start()
    {
        objStatManager = GetComponent<ObjectStatManager>();

        cardName.text = objStatManager.cardName;

        cardImage.sprite = objStatManager.cardImage;

        for(int i = 0; i < objStatManager.price; i++)
        {
            manaList[i].SetActive(true);
        }
    }
}
