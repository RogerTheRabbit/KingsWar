using UnityEngine;
using UnityEngine.UI;

public class Rook : Piece
{

    public override void init(TurnManager turnManager, bool white, PieceManager pieceManager)
    {
        base.init(turnManager, white, pieceManager);
        string resourcePath = null;
        string resourceName = null;
        this.hasMoved = false;
        if (white)
        {
            resourcePath = "Pieces/White/";
            // resourceName = "Plastic 1 128x128_5";
            resourceName = "White_-_Plastic_1_128x128-noback_4";
        }
        else
        {
            resourcePath = "Pieces/Black/";
            // resourceName = "Plastic 1 128x128_5";
            resourceName = "Black_-_Plastic_1_128x128-noback_4";
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
        Cell[,] matrixboard = start.mBoard.mAllCells;

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
        bool x = xDelta == 0;
        bool y = yDelta == 0;
        if (!hasMoved) {
            hasMoved = (x && !y) || (!x && y);
        }
        return (x && !y) || (!x && y);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
