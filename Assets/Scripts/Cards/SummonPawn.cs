using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonPawn : Summon
{
    public override bool playCard(Cell pieceLocation)
    {
        if (pieceLocation.currentPiece == null)
        {
            if (this.turnManager.isWhiteTurn && pieceLocation.mBoardPosition.y < 6) {
                new Pawn().place(pieceLocation);
                this.useMana();
                return true;
            }
            else if (!this.turnManager.isWhiteTurn && pieceLocation.mBoardPosition.y > 1) {
                new Pawn().place(pieceLocation);
                this.useMana();
                return true;
            }
        }
        return false;
    }
    public override void useMana()
    {
        if(this.turnManager.isWhiteTurn) {
            this.turnManager.whitePlayer.playerMana -= 1;
        } else {
            this.turnManager.blackPlayer.playerMana -= 1;
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
