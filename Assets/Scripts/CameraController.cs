using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    public Vector3 localPositionToMove = new Vector3(0, 0, -10);

    public float movingSpeed = 0.02f;

    Vector3 wantedPosition;
    public Vector3 offset;

    private void Start()
    {
        wantedPosition = transform.position;
    }

    void Update()
    {
        if (TowerManager.instance.towerPiecesList.Count != 0)
        {
            target = TowerManager.instance.towerPiecesList[0].transform;

            //wantedPosition = target.TransformPoint(localPositionToMove);
            wantedPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
            wantedPosition.y = target.position.y + localPositionToMove.y + offset.y;
        }

        transform.position = Vector3.Lerp(transform.position, wantedPosition, movingSpeed);
    }
}
