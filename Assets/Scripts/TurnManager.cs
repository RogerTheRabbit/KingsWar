using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public Player whitePlayer;
    public Player blackPlayer;
    public GameObject cardPrefab;
    public bool isWhiteTurn {get; set;}
    public bool hasMoved {get; set;}

    void Start()
    {
        Debug.Log(whitePlayer);
        whitePlayer.Setup(this, cardPrefab);
        blackPlayer.Setup(this, cardPrefab);
        isWhiteTurn = false;
        hasMoved = false;

        whitePlayer.drawRandomCard();
        whitePlayer.drawRandomCard();
        whitePlayer.drawRandomCard();

        blackPlayer.drawRandomCard();
        blackPlayer.drawRandomCard();
        blackPlayer.drawRandomCard();
    }

    public void turnStart()
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

    public void endTurn()
    {
        isWhiteTurn = !isWhiteTurn;
    }
}
