using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Board board = start.mBoardPosition;

        int x = Mathf.Abs(start.mBoardPosition.x - end.mBoardPosition.x);
        int y = Mathf.Abs(start.mBoardPosition.y - end.mBoardPosition.y);
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
