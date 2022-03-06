using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Summon : Card
{
    

    public override bool playCard(Cell pieceLocation) {
        //TODO Also check that the cell is not in the back 2 ranks once turnmanager is done
        if (pieceLocation.currentPiece == null) {
            return true;
        }
        return false;
    }

    public override abstract void useMana();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
