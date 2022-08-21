using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardColor : MonoBehaviour
{
    public Sprite[] cardBacks;

    SpriteRenderer bgSprite;

    ObjectStatManager objStatManager;

    private void Start()
    {
        bgSprite = GetComponent<SpriteRenderer>();
        objStatManager = GetComponent<ObjectStatManager>();

        bgSprite.sprite = cardBacks[(int)objStatManager.price - 1];
    }
}
