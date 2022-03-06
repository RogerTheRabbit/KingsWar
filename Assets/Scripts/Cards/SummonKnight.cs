using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonKnight : Summon
{

    public override bool playCard(Cell pieceLocation)
    {
        //TODO Also check that the cell is not in the back 2 ranks once turnmanager is done
        if (pieceLocation.currentPiece == null && base.canPlayCard(this))
        {
            Piece knight = this.pieceManager.CreatePiece(typeof(Knight));
            knight.init(turnManager, white, this.pieceManager);
            knight.place(pieceLocation);
            return true;
        }
        return false;
    }
    public override void useMana()
    {
        // Tell turn manager to remove 3 mana 
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
