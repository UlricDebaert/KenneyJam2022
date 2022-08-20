using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject previewGO;
    public GameObject objectToSpawn;

    public int spawnID;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log(hit.collider.gameObject.name);
                    InstantiatePreview();
                    Destroy(gameObject);
                }
            }
        }
    }

    void InstantiatePreview()
    {
        GameObject preview = Instantiate(previewGO, transform.position, Quaternion.identity);
        preview.GetComponent<Preview>().cardID = spawnID;
    }
}
