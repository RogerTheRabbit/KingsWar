using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bishop : Piece
{

	public override void init(PieceManager pieceManager, bool white)
    {
        base.init(pieceManager, white);
    }

	public override bool hasMove(Cell start, Cell end) 
	{
		if (end.currentPiece.white == start.currentPiece.white)
        {
            return false;
        }

        if(start.mBoardPosition.x - end.mBoardPosition.x == 0 && start.mBoardPosition.y - end.mBoardPosition.y == 0) {
            return false;
        }

        int x = Mathf.Abs(start.mBoardPosition.x - end.mBoardPosition.x);
        int y = Mathf.Abs(start.mBoardPosition.y - end.mBoardPosition.y);

        // Not valid move if not diagonal move
        if(x != y) {
            return false;
        }

        Cell[,] matrixboard = start.mBoard.mAllCells;

        // Check diagonal
        int[] xCords = Utilities.getRangeExclusive(start.mBoardPosition.x, end.mBoardPosition.x);
        int[] yCords = Utilities.getRangeExclusive(start.mBoardPosition.y, end.mBoardPosition.y);
        for(int pos = 0; pos < x; pos++) {
            if(matrixboard[xCords[pos],yCords[pos]].currentPiece != null) {
                    return false;
            }
        }
        return true;
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
