using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonRook : Summon
{
    public override bool playCard(Cell pieceLocation)
    {
        if (pieceLocation.currentPiece == null && base.canPlayCard(this))
        {
            if (this.turnManager.isWhiteTurn && pieceLocation.mBoardPosition.y > 1) {
                Piece rook = this.pieceManager.CreatePiece(typeof(Rook));
                rook.init(turnManager, white, this.pieceManager);
                rook.place(pieceLocation);
                base.spendMana();
                return true;
            }
            else if (!this.turnManager.isWhiteTurn && pieceLocation.mBoardPosition.y < 6) {
                Piece rook = this.pieceManager.CreatePiece(typeof(Rook));
                rook.init(turnManager, white, this.pieceManager);
                rook.place(pieceLocation);
                base.spendMana();
                return true;
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
