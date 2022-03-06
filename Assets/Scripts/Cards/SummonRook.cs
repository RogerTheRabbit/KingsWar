using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonRook : Summon
{

    public override bool playCard(Cell pieceLocation)
    {
        if (pieceLocation.currentPiece == null)
        {
            if (this.turnManager.isWhiteTurn && pieceLocation.mBoardPosition.y > 1) {
                Piece rook = this.pieceManager.CreatePiece(typeof(Rook));
                rook.init(turnManager, white, this.pieceManager);
                rook.place(pieceLocation);
                this.useMana();
                return true;
            }
            else if (!this.turnManager.isWhiteTurn && pieceLocation.mBoardPosition.y < 6) {
                Piece rook = this.pieceManager.CreatePiece(typeof(Rook));
                rook.init(turnManager, white, this.pieceManager);
                rook.place(pieceLocation);
                this.useMana();
                return true;
            }
        }
        return false;
    }
    public override void useMana()
    {
        if(!this.turnManager.isWhiteTurn) {
            this.turnManager.whitePlayer.playerCurrentMana -= 5;
        } else {
            this.turnManager.blackPlayer.playerCurrentMana -= 5;
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
