using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public override void init(PieceManager pieceManager, bool white)
    {
        base.init(pieceManager, white);
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
