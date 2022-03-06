using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class King : Piece
{
    // Start is called before the first frame update

    public override void init(TurnManager turnManager, bool white)
    {
        base.init(turnManager, white);
        string resourcePath = null;
        string resourceName = null;
        if (white)
        {
            resourcePath = "Pieces/White/";
            resourceName = "Plastic 1 128x128_2";
        }
        else
        {
            resourcePath = "Pieces/Black/";
            resourceName = "Plastic 1 128x128_3";
        }
        Sprite[] all = Resources.LoadAll<Sprite>(resourcePath);
        foreach (var s in all)
        {
            if (s.name.Contains(resourceName))
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
        if (!base.hasMove(start, end)) {
            return false;
        }

        int xDelta = Mathf.Abs(start.mBoardPosition.x - end.mBoardPosition.x);
        int yDelta = Mathf.Abs(start.mBoardPosition.y - end.mBoardPosition.y);

        // Not valid move if moved more than 1 place
        if(xDelta > 1 || yDelta > 1) {
            return false;
        }

        Cell[,] matrixboard = start.mBoard.mAllCells;

        if(xDelta == yDelta) {
            // Check diagonal
            int[] xCords = Utilities.getRangeExclusive(start.mBoardPosition.x, end.mBoardPosition.x);
            int[] yCords = Utilities.getRangeExclusive(start.mBoardPosition.y, end.mBoardPosition.y);
            for(int pos = 0; pos < xDelta - 1; pos++) {
                if(matrixboard[xCords[pos],yCords[pos]].currentPiece != null) {
                        return false;
                }
            }
        } else {
            // Check straight
            if(xDelta != 0) {
                // Check x-direction move
                foreach(int i in Utilities.getRangeExclusive(start.mBoardPosition.x, end.mBoardPosition.x)){
                    if(matrixboard[i,start.mBoardPosition.y].currentPiece != null) {
                        return false;
                    }
                }
            } else {
                // Check y-direction move
                foreach(int i in Utilities.getRangeExclusive(start.mBoardPosition.y, end.mBoardPosition.y)){
                    if(matrixboard[start.mBoardPosition.x, i].currentPiece != null) {
                        return false;
                    }
                }
            }
        }

        bool x = xDelta == 0;
        bool y = yDelta == 0;
        return (x && !y) || (!x && y) || (xDelta == yDelta);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
