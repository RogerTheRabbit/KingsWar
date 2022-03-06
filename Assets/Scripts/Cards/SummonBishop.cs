using UnityEngine;

public class SummonBishop : Summon
{
    public override void init(TurnManager turnManager, bool white)
    {
        base.init(turnManager, white);
        base.manaCost = 3;

    }

    public override bool playCard(Cell pieceLocation)
    {
        //TODO Also check that the cell is not in the back 2 ranks once turnmanager is done
        if (pieceLocation.currentPiece == null)
        {
            new Bishop().place(pieceLocation);
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
