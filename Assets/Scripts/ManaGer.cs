using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaGer : MonoBehaviour
{
    public float startingMana;
    public float maxMana;
    public float manaRegenPerSecond;
    public float manaCounter;

    private void Start()
    {
        manaCounter = startingMana;
    }

    private void Update()
    {
        if(manaCounter < maxMana)
            manaCounter += manaRegenPerSecond * Time.deltaTime;
    }

    public void SpendMana(float manaToSpend)
    {
        if (manaToSpend <= manaCounter)
        {
            manaCounter -= manaToSpend;
        }
        else
        {
            Debug.Log("Not Enough Mana!");
        }
    }
}
