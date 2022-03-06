using UnityEngine;
using UnityEngine.UI;

public class Rook : Piece
{
    // Start is called before the first frame update

    public override void init(PieceManager pieceManager, bool white)
    {
        base.init(pieceManager, white);
        Sprite[] all = Resources.LoadAll<Sprite>("Pieces/Black/");
        foreach (var s in all)
        {
            if (s.name.Contains("Black - Plastic 1 128x128_5"))
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
        if (end.currentPiece != null && end.currentPiece.white == start.currentPiece.white)
        {
            return false;
        }

        // Not a valid move if the piece doesn't move.
        if(start.mBoardPosition.x - end.mBoardPosition.x == 0 && start.mBoardPosition.y - end.mBoardPosition.y == 0) {
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
