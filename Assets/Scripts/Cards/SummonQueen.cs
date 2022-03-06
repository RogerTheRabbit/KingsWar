using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonQueen : Summon
{

    public override bool playCard(Cell pieceLocation)
    {
        if (pieceLocation.currentPiece == null && base.canPlayCard(this))
        {
            if (this.turnManager.isWhiteTurn && pieceLocation.mBoardPosition.y > 1) {
                Piece queen = this.pieceManager.CreatePiece(typeof(Queen));
                queen.init(turnManager, white, this.pieceManager);
                queen.place(pieceLocation);
                this.useMana();
                return true;
            }
            else if (!this.turnManager.isWhiteTurn && pieceLocation.mBoardPosition.y < 6) {
                Piece queen = this.pieceManager.CreatePiece(typeof(Queen));
                queen.init(turnManager, white, this.pieceManager);
                queen.place(pieceLocation);
                this.useMana();
                return true;
            }
        }
        return false;
    }
    public override void useMana()
    {
        if(!this.turnManager.isWhiteTurn) {
            this.turnManager.whitePlayer.playerCurrentMana -= 9;
        } else {
            this.turnManager.blackPlayer.playerCurrentMana -= 9;
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
