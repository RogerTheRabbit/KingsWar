using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static int maxMana = 12;
    static int maxHandSize = 10;
    public int playerMana;
    TurnManager turnManager;
    List<Card> cards;
    GameObject cardPrefab;

    private Dictionary<string, Type> pieceLibrary = new Dictionary<string, Type>()
    {
        {"SB",  typeof(SummonBishop)},
    };

    public void Setup(TurnManager turnManager, GameObject cardPrefab)
    {
        playerMana = 0;
        this.turnManager = turnManager;
        this.cardPrefab = cardPrefab;
        cards = new List<Card>();
    }

    public void drawRandomCard()
    {
        // Create new card object
        GameObject newCardObject = Instantiate(cardPrefab);
        newCardObject.transform.SetParent(transform);

        // Set scale and position
        newCardObject.transform.localScale = new Vector3(1, 1, 1);
        newCardObject.transform.localRotation = Quaternion.identity;

        // Store new piece
        Card newCard = (Card)newCardObject.AddComponent(pieceLibrary["SB"]);
        cards.Add(newCard);
        
    }
}
