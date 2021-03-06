using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonPawn : Summon
{
    public override void init(TurnManager turnManager, PieceManager pieceManager, bool white)
    {
        text = "Summon a 1-1 Pawn";
        base.init(turnManager, pieceManager, white);
        base.manaCost = 1;
    }
    public override bool playCard(Cell pieceLocation)
    {
        if (pieceLocation.currentPiece == null && base.canPlayCard(this))
        {
            if (this.turnManager.isWhiteTurn && pieceLocation.mBoardPosition.y > 1) {
                Piece pawn = this.pieceManager.CreatePiece(typeof(Pawn));
                pawn.init(turnManager, white, this.pieceManager);
                pawn.place(pieceLocation);
                base.spendMana();
                return true;
            }
            else if (!this.turnManager.isWhiteTurn && pieceLocation.mBoardPosition.y < 6) {
                Piece pawn = this.pieceManager.CreatePiece(typeof(Pawn));
                pawn.init(turnManager, white, this.pieceManager);
                pawn.place(pieceLocation);
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
