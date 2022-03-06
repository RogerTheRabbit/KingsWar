using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStatBuff : Buffs
{

    public int addHealth;
    public int addAttack;


    public void init(TurnManager turnManager, bool white, int manaCost, int addHealth, int addAttack) {
        base.init(turnManager, white);
        this.manaCost = manaCost;
        this.addHealth = addHealth;
        this.addAttack = addAttack;
    }
    public override bool playCard(Cell pieceLocation)
    {
        Piece piece = pieceLocation.currentPiece;
        if (piece == null)
        {
            return false;
        }
        piece.attack += addAttack;
        piece.health += addHealth;
        piece.updateHealth();
        piece.updateAttack();

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
