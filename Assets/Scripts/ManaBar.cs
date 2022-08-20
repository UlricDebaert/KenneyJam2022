using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Image manaBar;
    ManaGer manaManager;

    private void Start()
    {
        manaManager = GetComponent<ManaGer>();
    }

    private void Update()
    {
        manaBar.fillAmount = manaManager.manaCounter / manaManager.maxMana;
    }
}
