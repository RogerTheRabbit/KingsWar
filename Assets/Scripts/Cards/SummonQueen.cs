using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonQueen : Summon
{

    public override void init(TurnManager turnManager, PieceManager pieceManager, bool white)
    {
        text = "Summon a 9-9 Queen";
        base.init(turnManager, pieceManager, white);
        base.manaCost = 9;
    }
    public override bool playCard(Cell pieceLocation)
    {
        if (pieceLocation.currentPiece == null && base.canPlayCard(this))
        {
            if (this.turnManager.isWhiteTurn && pieceLocation.mBoardPosition.y > 1) {
                Piece queen = this.pieceManager.CreatePiece(typeof(Queen));
                queen.init(turnManager, white, this.pieceManager);
                queen.place(pieceLocation);
                base.spendMana();
                return true;
            }
            else if (!this.turnManager.isWhiteTurn && pieceLocation.mBoardPosition.y < 6) {
                Piece queen = this.pieceManager.CreatePiece(typeof(Queen));
                queen.init(turnManager, white, this.pieceManager);
                queen.place(pieceLocation);
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
