using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Variables
    [SerializeField] PlayerHand hand;
    [Header("In-GameHUD")]
    [SerializeField] Button buttonD20;

    [Header("Dice prefabs")]
    public GameObject prefabD20;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        buttonD20.onClick.AddListener(() => SpawnD20());
    }

    private void SpawnD20()
    {
        Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // z coordinate of game object on screen
        if (hand.diceCount < hand.holdPositions.Length)
        {
            hand.diceCount += 1;
            Instantiate(prefabD20, hand.holdPositions[hand.diceCount].position, Quaternion.identity, hand.holdPositions[hand.diceCount]);
        }
        else
        {
            Debug.Log("Max dice number reached");
        }
    }

}
