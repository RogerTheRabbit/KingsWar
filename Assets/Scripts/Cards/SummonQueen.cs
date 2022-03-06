using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonQueen : Summon
{

    public override bool playCard(Cell pieceLocation)
    {
        //TODO Also check that the cell is not in the back 2 ranks once turnmanager is done
        if (pieceLocation.currentPiece == null && base.canPlayCard(this))
        {
            Piece queen = this.pieceManager.CreatePiece(typeof(Queen));
            queen.init(turnManager, white, this.pieceManager);
            queen.place(pieceLocation);
            return true;
        }
        return false;
    }
    public override void useMana()
    {
        // Tell turn manager to remove 9 mana 
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
