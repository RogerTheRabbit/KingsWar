using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonRook : Summon
{

    public override bool playCard(Cell pieceLocation)
    {
        //TODO Also check that the cell is not in the back 2 ranks once turnmanager is done
        if (pieceLocation.currentPiece == null)
        {
            Piece rook = this.pieceManager.CreatePiece(typeof(Rook));
            rook.init(turnManager, white, this.pieceManager);
            rook.place(pieceLocation);
            return true;
        }
        return false;
    }
    public override void useMana()
    {
        // Tell turn manager to remove 5 mana 
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
