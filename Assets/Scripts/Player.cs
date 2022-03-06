using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static int maxMana = 12;
    static int maxHandSize = 10;
    public int playerMana;
    bool isWhite;
    TurnManager turnManager;
    public PieceManager pieceManager;
    List<Card> cards;
    GameObject cardPrefab;

    private Dictionary<string, Type> cardLibrary = new Dictionary<string, Type>()
    {
        {"SB",  typeof(SummonBishop)},
    };

    public void Setup(TurnManager turnManager, PieceManager pieceManager, GameObject cardPrefab, bool isWhite)
    {
        playerMana = 0;
        this.turnManager = turnManager;
        this.cardPrefab = cardPrefab;
        this.pieceManager = pieceManager;
        cards = new List<Card>();
        this.isWhite = isWhite;
    }

    public void drawRandomCard()
    {
        // Create new card object
        GameObject newCardObject = Instantiate(cardPrefab);
        newCardObject.transform.SetParent(transform);

        int cardXPosition = -500;
        if (isWhite)
        {
            cardXPosition = 500;
        }

        // Set scale and position
        newCardObject.transform.localScale = new Vector3(25, 25, 25);
        newCardObject.transform.localRotation = Quaternion.identity;
        newCardObject.transform.localPosition = new Vector3(cardXPosition, 250 - 150 * cards.Count, 0);

        // Store new piece
        Card newCard = (Card)newCardObject.AddComponent(cardLibrary["SB"]);
        newCard.init(turnManager, pieceManager, isWhite);
        cards.Add(newCard);
        
    }
}
