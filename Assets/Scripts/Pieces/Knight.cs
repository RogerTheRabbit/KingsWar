using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    // Start is called before the first frame update

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

        int x = Mathf.Abs(start.mBoardPosition.x- end.mBoardPosition.x);
        int y = Mathf.Abs(start.mBoardPosition.y - end.mBoardPosition.y);
        return x * y == 2;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
