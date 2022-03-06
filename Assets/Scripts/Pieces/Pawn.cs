using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pawn : Piece
{
    public override void init(TurnManager turnManager, bool white, PieceManager pieceManager)
    {
        base.init(turnManager, white, pieceManager);
        string resourcePath = null;
        string resourceName = null;
        if (white)
        {
            resourcePath = "Pieces/White/";
            resourceName = "Plastic 1 128x128_3";
        }
        else
        {
            resourcePath = "Pieces/Black/";
            resourceName = "Plastic 1 128x128_4";
        }
        Sprite[] all = Resources.LoadAll<Sprite>(resourcePath);
        foreach (var s in all)
        {
            if (s.name.Contains(resourceName))
            {
                GetComponent<Image>().sprite = s;
                GetComponent<Image>().color = new Color(255, 255, 255, 255);
                GetComponent<Image>().GetComponent<SpriteRenderer>().sortingOrder = 1;
                break;
            }
        }
    }

	public override bool hasMove(Cell start, Cell end) 
	{   
        if (!base.hasMove(start, end)) {
            return false;
        }

        int x = start.mBoardPosition.x - end.mBoardPosition.x;
        int y = start.mBoardPosition.y - end.mBoardPosition.y;

        Cell[,] matrixboard = start.mBoard.mAllCells;
        // Checks white pawn moves
        if(start.currentPiece.white) {
            // We are not attacking
            // Check a single forward move
            if (y == - 1 && x == 0 && matrixboard[start.mBoardPosition.x, end.mBoardPosition.y].currentPiece == null) {
                if (end.mBoardPosition.y == 7) {
                    this.promote(start, end, matrixboard);
                }
                return true;
            }
            else if (x == 0) {
                // Two space move
                if (start.mBoardPosition.y == 1 && end.mBoardPosition.y == 3 &&
                 matrixboard[start.mBoardPosition.x, end.mBoardPosition.y].currentPiece == null && 
                 matrixboard[start.mBoardPosition.x, end.mBoardPosition.y - 1].currentPiece == null) {
                    return true;
                }
            } 
            // Attack move
            else if (Mathf.Abs(x) == 1 && y == -1) {
                if (matrixboard[end.mBoardPosition.x, end.mBoardPosition.y].currentPiece != null && 
                !matrixboard[end.mBoardPosition.x, end.mBoardPosition.y].currentPiece.white) {
                    return true;
                }
            }
            else {
                return false;
            }
        }
        // Checks black pawn moves
        else if(!start.currentPiece.white) {
            // We are not attacking
            // Check a single forward move
            if (y == 1 && x == 0 && matrixboard[start.mBoardPosition.x, end.mBoardPosition.y].currentPiece == null) {
                if (end.mBoardPosition.y == 0) {
                    this.promote(start, end, matrixboard);
                }
                return true;
            }
            else if (x == 0) {
                // Two space move
                if (start.mBoardPosition.y == 6 && end.mBoardPosition.y == 4 &&
                 matrixboard[start.mBoardPosition.x, end.mBoardPosition.y].currentPiece == null && 
                 matrixboard[start.mBoardPosition.x, end.mBoardPosition.y + 1].currentPiece == null) {
                    return true;
                }
            } 
            // Attack move
            else if (Mathf.Abs(x) == 1 && y == 1) {
                if (matrixboard[end.mBoardPosition.x, end.mBoardPosition.y].currentPiece != null && 
                matrixboard[end.mBoardPosition.x, end.mBoardPosition.y].currentPiece.white) {
                    return true;
                }
            }
            else {
                return false;
            }
        }
        return false;
    }

    public void promote(Cell startCell, Cell endCell, Cell[,] matrixboard) {
        matrixboard[startCell.mBoardPosition.x, startCell.mBoardPosition.y].currentPiece.Kill();
        Piece queen = this.pieceManager.CreatePiece(typeof(Queen));
        queen.init(turnManager, white, this.pieceManager);
        queen.place(endCell);
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
