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

    AudioSource audioSource;
    public AudioClip spawnSound;

    SpriteRenderer sprite;

    Vector3 mousePos;

    //Card Data
    [HideInInspector] public GameObject objectToSpawn;
    public GameObject cardPrefab;
    [HideInInspector] public float weight;
    [HideInInspector] public float gravity;
    [HideInInspector] public float price;
    [HideInInspector] public PhysicsMaterial2D phyMat;

    [HideInInspector] public int cardID;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(spawnSound);
        canBuild = false;
    }


    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);

        //if (Input.GetKeyUp(KeyCode.Mouse0) && (!canBuild || obstacle))
        //{
        //    GameObject card = Instantiate(cardPrefab, CardManager.instance.deckPos[cardID].position, Quaternion.identity, CardManager.instance.deckPos[cardID]);
        //    card.GetComponent<Card>().spawnID = cardID;
        //    Destroy(gameObject);
        //}

        //if (Input.GetKeyUp(KeyCode.Mouse0) && canBuild && !obstacle)
        //{
        //    Instantiate(objectToSpawn, transform.position, transform.rotation);
        //    CardManager.instance.DrawNewCard(cardID);
        //    Destroy(gameObject);
        //}

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (!canBuild || obstacle || transform.position.y < LavaLine.instance.gameObject.transform.position.y)
            {
                Undo();
            }

            if (canBuild && !obstacle && transform.position.y > LavaLine.instance.gameObject.transform.position.y)
            {
                if (ManaGer.instance.SpendMana(price))
                {
                    Build();
                }
                else
                {
                    Undo();
                }
            }
        }

        horizontalInput = Input.GetAxisRaw("Horizontal");
        print(horizontalInput);
        transform.Rotate(0, 0, horizontalInput * rotationSpeed * Time.deltaTime * -10);

        if (canBuild) sprite.color = buildEnableColor;
        if (!canBuild || obstacle || price > ManaGer.instance.manaCounter || transform.position.y < LavaLine.instance.gameObject.transform.position.y) sprite.color = buildDisableColor;
    }

    void Build()
    {
        print("Build");
        GameObject objectInstantiated = Instantiate(objectToSpawn, transform.position, transform.rotation);
        objectInstantiated.GetComponent<Rigidbody2D>().mass = weight;
        objectInstantiated.GetComponent<Rigidbody2D>().gravityScale = gravity;
        objectInstantiated.GetComponent<Rigidbody2D>().sharedMaterial = phyMat;
        CardManager.instance.DrawNewCard(cardID);
        Destroy(gameObject);
    }

    void Undo()
    {
        print("Undo");
        GameObject card = Instantiate(cardPrefab, CardManager.instance.deckPos[cardID].position, Quaternion.identity, CardManager.instance.deckPos[cardID]);
        card.GetComponent<Card>().spawnID = cardID;
        Destroy(gameObject);
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
