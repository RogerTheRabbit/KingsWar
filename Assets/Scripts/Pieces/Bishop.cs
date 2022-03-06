using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bishop : Piece
{

	public override void init(TurnManager turnManager, bool white)
    {
        base.init(turnManager, white);
        string resourcePath = null;
        string resourceName = null;
        if (white)
        {
            resourcePath = "Pieces/White/";
            resourceName = "Plastic 1 128x128_0";
        }
        else
        {
            resourcePath = "Pieces/Black/";
            resourceName = "Plastic 1 128x128_0";
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

        int x = Mathf.Abs(start.mBoardPosition.x - end.mBoardPosition.x);
        int y = Mathf.Abs(start.mBoardPosition.y - end.mBoardPosition.y);

        // Not valid move if not diagonal move
        if(x != y) {
            return false;
        }

        Cell[,] matrixboard = start.mBoard.mAllCells;

        // Check diagonal
        int[] xCords = Utilities.getRangeExclusive(start.mBoardPosition.x, end.mBoardPosition.x);
        int[] yCords = Utilities.getRangeExclusive(start.mBoardPosition.y, end.mBoardPosition.y);
        for(int pos = 0; pos < x - 1; pos++) {
            if(matrixboard[xCords[pos],yCords[pos]].currentPiece != null) {
                    return false;
            }
        }
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
