using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    static int maxMana = 12;
    static int maxHandSize = 5;
    public int playerCurrentMana;
    public int turnMaxMana;
    bool isWhite;
    TurnManager turnManager;
    public PieceManager pieceManager;
    public List<Card> cards;
    GameObject cardPrefab;

    private Text[] manaText;

    private Dictionary<string, Type> cardLibrary = new Dictionary<string, Type>()
    {
        {"SB",  typeof(SummonBishop)},
    };

    public void Setup(TurnManager turnManager, PieceManager pieceManager, GameObject cardPrefab, bool isWhite)
    {
        turnMaxMana = 0;
        playerCurrentMana = turnMaxMana;

        this.turnManager = turnManager;
        this.cardPrefab = cardPrefab;
        this.pieceManager = pieceManager;
        cards = new List<Card>();
        this.isWhite = isWhite;
        this.manaText = GetComponentsInChildren<Text>();
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
        newCardObject.transform.localPosition = new Vector3(cardXPosition, 250 - (150 * cards.Count)%900, 0);

        // Store new piece
        Card newCard = (Card)newCardObject.AddComponent(cardLibrary["SB"]);
        newCard.init(turnManager, pieceManager, isWhite);
        cards.Add(newCard);
        
    }

    public void resetAndIncrementMana()
    {
        if (turnMaxMana < maxMana)
        {
            turnMaxMana += 1;
        }
        playerCurrentMana = turnMaxMana;
        if (this.isWhite) {
            this.manaText[0].text = playerCurrentMana.ToString();
        } else {
            this.manaText[1].text = playerCurrentMana.ToString();
        }
    }
}
