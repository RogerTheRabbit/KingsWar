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

        Cell[,] matrixboard = start.mBoard.mAllCells;

        int x = Mathf.Abs(start.mBoardPosition.x - end.mBoardPosition.x);
        int y = Mathf.Abs(start.mBoardPosition.y - end.mBoardPosition.y);

        int[] range = Utilities.findRange(start.mBoardPosition.x, end.mBoardPosition.x);
        foreach(int i in range) {
        	if(matrixboard[i,i].currentPiece != null) {
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
