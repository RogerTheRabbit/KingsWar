using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDeBuff : Buffs
{
    public void init(TurnManager turnManager, PieceManager pieceManager, bool white, int manaCost)
    {
        base.init(turnManager, pieceManager, white);
        this.manaCost = manaCost;
    }
    public override bool playCard(Cell pieceLocation)
    {
        Piece piece = pieceLocation.currentPiece;
        if (piece == null)
        {
            return false;
        }

        piece.activeBuffs.Add(this);
        piece.updateSprite();

        return true;
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
