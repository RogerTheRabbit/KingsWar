using UnityEngine;
using UnityEngine.UI;

public class Rook : Piece
{
    // Start is called before the first frame update

    public override void init(TurnManager turnManager, bool white)
    {

        base.init(turnmanager, white);
        string resourcePath = null;
        string resourceName = null;
        if (white)
        {
            resourcePath = "Pieces/White/";
            resourceName = "Plastic 1 128x128_5";
        }
        else
        {
            resourcePath = "Pieces/Black/";
            resourceName = "Plastic 1 128x128_5";
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

        Cell[,] matrixboard = start.mBoard.mAllCells;

        int x = start.mBoardPosition.x - end.mBoardPosition.x;
        int y = start.mBoardPosition.y - end.mBoardPosition.y;

        if (y == 0) {
            int[] range = Utilities.getRangeExclusive(start.mBoardPosition.x, end.mBoardPosition.x);
            foreach(int i in range){
                if (matrixboard[x,i].currentPiece != null) {
                    return false;
                }
            }
        }

        if (x == 0) {
            int[] range = Utilities.getRangeExclusive(start.mBoardPosition.y, end.mBoardPosition.y);
            foreach(int i in range){
                if (matrixboard[i,y].currentPiece != null) {
                    return false;
                }
            }
        }
        return (x == 0 && y != 0) || (x != 0 && y == 0);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
