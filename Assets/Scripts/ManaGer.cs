using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaGer : MonoBehaviour
{
    public float startingMana;
    public float maxMana;
    public float manaRegenPerSecond;
    public float manaCounter;

    public static ManaGer instance;

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);

        instance = this;
    }

    private void Start()
    {
        manaCounter = startingMana;
    }

    private void Update()
    {
        if(manaCounter < maxMana)
            manaCounter += manaRegenPerSecond * Time.deltaTime;
    }

    public bool SpendMana(float manaToSpend)
    {
        if (manaToSpend <= manaCounter)
        {
            manaCounter -= manaToSpend;
            return true;
        }
        else
        {
            Debug.Log("Not Enough Mana!");
            return false;
        }
    }
}
