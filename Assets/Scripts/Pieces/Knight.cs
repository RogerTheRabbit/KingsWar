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
        Sprite[] all = Resources.LoadAll<Sprite>("\\Pieces\\Black\\Black - Plastic 1 128x128.png");
        foreach (var s in all)
        {
            if (s.name == "Black - Plastic 1 128x128_2")
            {
                GetComponent<Image>().sprite = s;
            }
        }
    }

    public override bool hasMove(Cell start, Cell end)
    {
        if (end.currentPiece.white == start.currentPiece.white)
        {
            return false;
        }

        int x = Mathf.Abs(start.mBoardPosition.x - end.mBoardPosition.x);
        int y = Mathf.Abs(start.mBoardPosition.y - end.mBoardPosition.y);
        return x * y == 2;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
