using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pawn : Piece
{
    public override void init(PieceManager pieceManager, bool white)
    {
        base.init(pieceManager, white);
        Sprite[] all = Resources.LoadAll<Sprite>("Pieces/Black/");
        foreach (var s in all)
        {
            if (s.name.Contains("Black - Plastic 1 128x128_4"))
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
        int x = Mathf.Abs(start.mBoardPosition.x - end.mBoardPosition.x);
        int y = Mathf.Abs(start.mBoardPosition.y - end.mBoardPosition.y);

        if (end.currentPiece.white == start.currentPiece.white)
        {
            return false;
        }

        if(start.mBoardPosition.x - end.mBoardPosition.x == 0 && start.mBoardPosition.y - end.mBoardPosition.y == 0) {
            return false;
        }

        Cell[,] matrixboard = start.mBoard.mAllCells;
        // Checks white pawn moves
        if(start.currentPiece.white) {
            // We are not attacking
            // Check a single forward move
            if (y == 1 && matrixboard[start.mBoardPosition.x, end.mBoardPosition.y].currentPiece == null) {
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
            else if (x == 1 && y == 1) {
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
            if (y == 1 && matrixboard[start.mBoardPosition.x, end.mBoardPosition.y].currentPiece == null) {
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
            else if (x == 1 && y == 1) {
                if (matrixboard[end.mBoardPosition.x, end.mBoardPosition.y].currentPiece != null && 
                !matrixboard[end.mBoardPosition.x, end.mBoardPosition.y].currentPiece.white) {
                    return true;
                }
            }
            else {
                return false;
            }
        }
        return false;
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
