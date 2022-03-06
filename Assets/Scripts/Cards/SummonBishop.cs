using UnityEngine;

public class SummonBishop : Summon
{
    public override void init(TurnManager turnManager, PieceManager pieceManager, bool white)
    {
        base.init(turnManager, pieceManager, white);
        base.manaCost = 3;

    }

    public override bool playCard(Cell pieceLocation)
    {
        //TODO Also check that the cell is not in the back 2 ranks once turnmanager is done
        if (pieceLocation.currentPiece == null && base.canPlayCard(this))
        {
            if (this.turnManager.isWhiteTurn && pieceLocation.mBoardPosition.y > 1) {
                Piece bishop = this.pieceManager.CreatePiece(typeof(Bishop));
                bishop.init(turnManager, white, this.pieceManager);
                bishop.place(pieceLocation);
                this.useMana();
                return true;
            }
            else if (!this.turnManager.isWhiteTurn && pieceLocation.mBoardPosition.y < 6) {
                Piece bishop = this.pieceManager.CreatePiece(typeof(Bishop));
                bishop.init(turnManager, white, this.pieceManager);
                bishop.place(pieceLocation);
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
