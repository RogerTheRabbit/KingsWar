using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public Player whitePlayer;
    public Player blackPlayer;
    public GameObject cardPrefab;
    public PieceManager pieceManager;
    public bool isWhiteTurn {get; set;}
    public bool hasMoved {get; set;}

    public Board board;

    void Start()
    {
        Debug.Log(whitePlayer);
        whitePlayer.Setup(this, pieceManager, cardPrefab, true);
        blackPlayer.Setup(this, pieceManager,cardPrefab, false);
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
            whitePlayer.resetAndIncrementMana();
        }
        else
        {
            blackPlayer.drawRandomCard();
            blackPlayer.resetAndIncrementMana();
        }
    }

    public void endTurn()
    {
        unFreeze();
        isWhiteTurn = !isWhiteTurn;
        turnStart();
    }

    public void unFreeze()
    {
        foreach (Cell cell in board.mAllCells)
        {
            if (isWhiteTurn && cell.currentPiece != null && cell.currentPiece.white)
            {
                cell.currentPiece.activeBuffs.RemoveAll(b => b.GetType().Equals(typeof(IceDeBuff)));
                cell.currentPiece.updateSprite();
            }

            if (!isWhiteTurn && cell.currentPiece != null && !cell.currentPiece.white)
            {
                cell.currentPiece.activeBuffs.RemoveAll(b => b.GetType().Equals(typeof(IceDeBuff)));
                cell.currentPiece.updateSprite();
            }
        }
    }
}
