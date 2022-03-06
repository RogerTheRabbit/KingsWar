using UnityEngine;
using UnityEngine.UI;

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

    public void spendMana(int mana)
    {
        if (isWhiteTurn)
        {
            whitePlayer.playerCurrentMana -= mana;
            whitePlayer.manaText[0].text = whitePlayer.playerCurrentMana.ToString();
        }
        else
        {
            blackPlayer.playerCurrentMana -= mana;
            blackPlayer.manaText[1].text = blackPlayer.playerCurrentMana.ToString();
        }

    }

    public bool canPlayCard(Card card)
    {
        if (isWhiteTurn != card.white)
        {
            return false;
        }

        Player currentPlayer = blackPlayer;

        if (isWhiteTurn)
        {
            currentPlayer = whitePlayer;
        }

        if (card.manaCost > currentPlayer.playerCurrentMana)
        {
            return false;
        }

        return true;
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
