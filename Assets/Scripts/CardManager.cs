using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;

    public Transform[] deckPos;

    public GameObject[] cardPrefabs;

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);

        instance = this;
    }

    private void Start()
    {
        DrawCards();
    }

    public void DrawCards()
    {
        for (int i = 0; i < deckPos.Length; i++)
        {
            int cardID = Random.Range(0, cardPrefabs.Length);
            GameObject card = Instantiate(cardPrefabs[cardID], deckPos[i].position, Quaternion.identity, deckPos[i]);
            card.GetComponent<Card>().spawnID = i;
        }
    }

    public void DrawNewCard(int Index)
    {
        int cardID = Random.Range(0, cardPrefabs.Length);
        GameObject card = Instantiate(cardPrefabs[cardID], deckPos[Index].position, Quaternion.identity, deckPos[cardID]);
        card.GetComponent<Card>().spawnID = Index;
    }
}
