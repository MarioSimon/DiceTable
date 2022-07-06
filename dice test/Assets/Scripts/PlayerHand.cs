using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    // Start is called before the first frame update
    private float mZCoord;
    public int diceCount;
    public Transform[] holdPositions;

    private void Start()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        holdPositions = GetComponentsInChildren<Transform>();
        diceCount = 0;

    }

    private void Update()
    {
        UpdateHandPos();
    }

    private void UpdateHandPos()
    {
        Vector3 newPosition = GetMouseWorldPos();
        transform.position = newPosition;
    }

    private Vector3 GetMouseWorldPos()
    {
        // 2d coordinates
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
