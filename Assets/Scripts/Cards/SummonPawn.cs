using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonPawn : Summon
{

    public override void playCard() {
        // Tell turn manager that a pawn was summoned
    }

    public override void useMana()
    {
        // Tell turn manager to remove 1 mana 
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
