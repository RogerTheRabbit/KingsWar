using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public abstract bool playCard(TurnManager turnManager, Cell pieceLocation);
    public abstract void useMana(TurnManager turnManager);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
