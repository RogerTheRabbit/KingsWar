using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static int maxMana = 12;
    static int maxHandSize = 10;
    int playerMana = 0;
    Board gameBoard;
    Card[] cards;

    // Start is called before the first frame update
    void Start()
    {
        cards = new Card[maxHandSize];
        gameBoard = 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
