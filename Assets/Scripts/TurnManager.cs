using UnityEngine;

public class TurnManager : MonoBehaviour
{

    PieceManager pieceManager;
    Player whitePlayer;
    Player blackPlayer;
    bool isWhiteTurn;
    public bool hasMoved {get; set;}

    void Create(PieceManager pieceManager)
    {
        this.pieceManager = pieceManager;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
