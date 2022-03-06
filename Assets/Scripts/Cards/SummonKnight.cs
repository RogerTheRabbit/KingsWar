using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonKnight : Summon
{

    public override void init(TurnManager turnManager, PieceManager pieceManager, bool white)
    {
        base.init(turnManager, pieceManager, white);
        base.manaCost = 3;
    }
    public override bool playCard(Cell pieceLocation)
    {
        if (pieceLocation.currentPiece == null && base.canPlayCard(this))
        {
            if (this.turnManager.isWhiteTurn && pieceLocation.mBoardPosition.y > 1) {
                Piece knight = this.pieceManager.CreatePiece(typeof(Knight));
                knight.init(turnManager, white, this.pieceManager);
                knight.place(pieceLocation);
                this.useMana();
                return true;
            }
            else if (!this.turnManager.isWhiteTurn && pieceLocation.mBoardPosition.y < 6) {
                Piece knight = this.pieceManager.CreatePiece(typeof(Knight));
                knight.init(turnManager, white, this.pieceManager);
                knight.place(pieceLocation);
                this.useMana();
                return true;
            }
        }
        return false;
    }
    public override void useMana()
    {
        if(!this.turnManager.isWhiteTurn) {
            this.turnManager.whitePlayer.playerCurrentMana -= 3;
        } else {
            this.turnManager.blackPlayer.playerCurrentMana -= 3;
        }
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
