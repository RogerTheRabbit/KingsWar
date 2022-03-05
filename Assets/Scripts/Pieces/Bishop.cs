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

        Cell[] matrixboard = start.mBoard.mAllCells;

        int x = Mathf.Abs(start.mBoardPosition.x - end.mBoardPosition.x);
        int y = Mathf.Abs(start.mBoardPosition.y - end.mBoardPosition.y);
        for (int i = Mathf.Abs(start.mBoardPosition.x) + 1; i < x; i ++) {
        	if(matrixboard[i][i].currentPiece != Null) {
        		return false;
        	} 
        }
        return x == y;
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
