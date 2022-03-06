using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knight : Piece
{
    // Start is called before the first frame update

    public override void init(PieceManager pieceManager, bool white)
    {
        base.init(pieceManager, white);
        Sprite[] all = Resources.LoadAll<Sprite>("Pieces/Black/");
        foreach (var s in all)
        {
            if (s.name.Contains("Black - Plastic 1 128x128_2"))
            {
                GetComponent<Image>().sprite = s;
                GetComponent<Image>().color = new Color(255, 255, 255, 255);
                GetComponent<Image>().GetComponent<SpriteRenderer>().sortingOrder = 1;
                break;
            }
        }
    }

    public override bool hasMove(Cell start, Cell end)
    {
        return true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
