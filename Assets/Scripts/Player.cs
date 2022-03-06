using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    static int maxMana = 12;
    static int maxHandSize = 10;
    int playerMana;
    PieceManager pieceManager;
    TurnManager turnManager;
    Card[] cards;

    void Create(PieceManager pieceManager, TurnManager turnManager)
    {
        playerMana = 0;
        this.pieceManager = pieceManager;
        cards = new Card[maxHandSize];
    }

    public void drawRandomCard()
    {

    }
}
