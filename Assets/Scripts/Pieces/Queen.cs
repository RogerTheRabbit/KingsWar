using UnityEngine;

public class Queen : Piece
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

        bool x = start.mBoardPosition.x - end.mBoardPosition.x == 0;
        bool y = start.mBoardPosition.y - end.mBoardPosition.y == 0;
        return (x && !y) || (!x && y) || (x == y);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
