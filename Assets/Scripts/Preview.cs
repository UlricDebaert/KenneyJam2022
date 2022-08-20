using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview : MonoBehaviour
{
    bool canBuild;
    bool obstacle;

    float horizontalInput;
    public float rotationSpeed = 10;

    public Color buildEnableColor;
    public Color buildDisableColor;

    SpriteRenderer sprite;

    Vector3 mousePos;

    //Card Data
    [HideInInspector] public GameObject objectToSpawn;
    public GameObject cardPrefab;
    [HideInInspector] public int cardID;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        canBuild = false;
    }


    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);

        if (Input.GetKeyUp(KeyCode.Mouse0) && (!canBuild || obstacle))
        {
            GameObject card = Instantiate(cardPrefab, CardManager.instance.deckPos[cardID].position, Quaternion.identity, CardManager.instance.deckPos[cardID]);
            card.GetComponent<Card>().spawnID = cardID;
            Destroy(gameObject);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && canBuild && !obstacle)
        {
            Instantiate(objectToSpawn, transform.position, transform.rotation);
            CardManager.instance.DrawNewCard(cardID);
            Destroy(gameObject);
        }

        horizontalInput = Input.GetAxisRaw("Horizontal");
        print(horizontalInput);
        transform.Rotate(0, 0, horizontalInput * rotationSpeed * Time.deltaTime * -10);

        if (canBuild) sprite.color = buildEnableColor;
        if (!canBuild || obstacle) sprite.color = buildDisableColor;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BuildArea"))
        {
            canBuild = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") || collision.CompareTag("TowerPiece"))
        {
            obstacle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BuildArea"))
        {
            canBuild = false;
        }
        if (collision.CompareTag("Obstacle") || collision.CompareTag("TowerPiece"))
        {
            obstacle = false;
        }
    }
}
