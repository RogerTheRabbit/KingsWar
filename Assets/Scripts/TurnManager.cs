using UnityEngine;

public class TurnManager
{
    Player whitePlayer;
    Player blackPlayer;
    bool isWhiteTurn;
    public bool hasMoved {get; set;}

    public TurnManager()
    {
        whitePlayer = new Player();
        blackPlayer = new Player();
        isWhiteTurn = false;
        hasMoved = false;

        whitePlayer.drawRandomCard();
        whitePlayer.drawRandomCard();
        whitePlayer.drawRandomCard();

        blackPlayer.drawRandomCard();
        blackPlayer.drawRandomCard();
        blackPlayer.drawRandomCard();
    }

    void turnStart()
    {
        hasMoved = false;
        if (isWhiteTurn)
        {
            whitePlayer.drawRandomCard();
        }
        else
        {
            blackPlayer.drawRandomCard();
        }
    }

    void endTurn()
    {
        isWhiteTurn = !isWhiteTurn;
    }
}
