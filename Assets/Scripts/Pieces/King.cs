using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class King : Piece
{
    // Start is called before the first frame update

    public override void init(TurnManager turnManager, bool white, PieceManager pieceManager)
    {
        base.init(turnManager, white, pieceManager);
        string resourcePath = null;
        string resourceName = null;
        this.hasMoved = false;
        if (white)
        {
            resourcePath = "Pieces/White/";
            // resourceName = "Plastic 1 128x128_2";
            resourceName = "White_-_Plastic_1_128x128-noback_2";
        }
        else
        {
            resourcePath = "Pieces/Black/";
            // resourceName = "Plastic 1 128x128_3";
            resourceName = "Black_-_Plastic_1_128x128-noback_2";
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

        // Check castle
        if (xDelta == 2 && !this.hasMoved) {
            foreach(int i in Utilities.getRangeExclusive(start.mBoardPosition.x, end.mBoardPosition.x)){
                if(matrixboard[i,start.mBoardPosition.y].currentPiece != null) {
                    return false;
                }
            }
            Piece rook = matrixboard[end.mBoardPosition.x + 1,end.mBoardPosition.y].currentPiece;
            if (rook != null && rook.GetType().Equals(typeof(Rook)) && !rook.hasMoved) {
                this.castle("King", matrixboard, end);
                this.hasMoved = true;
                return true;
            }
            rook = matrixboard[end.mBoardPosition.x - 2, end.mBoardPosition.y].currentPiece;
            if (rook != null && rook.GetType().Equals(typeof(Rook)) && !rook.hasMoved) {
                this.castle("Queen", matrixboard, end);
                this.hasMoved = true;
                return true;
            }
        } 

        // Not valid move if moved more than 1 place
        if(xDelta > 1 || yDelta > 1) {
            return false;
        }

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
        if (!this.hasMoved) {
            this.hasMoved = (x && !y) || (!x && y) || (xDelta == yDelta);
        }
        return (x && !y) || (!x && y) || (xDelta == yDelta);
    }

    public void castle(string direction, Cell[,] matrixboard, Cell end) {
        // Do a king side castle
        if (direction == "King") {
            Piece rook = matrixboard[end.mBoardPosition.x + 1, end.mBoardPosition.y].currentPiece;
            matrixboard[end.mBoardPosition.x + 1, end.mBoardPosition.y].currentPiece = null;
            rook.place(matrixboard[end.mBoardPosition.x - 1, end.mBoardPosition.y]);
        }
        // Do a queen side castle 
        else {
            Piece rook = matrixboard[end.mBoardPosition.x - 2, end.mBoardPosition.y].currentPiece;
            matrixboard[end.mBoardPosition.x - 2, end.mBoardPosition.y].currentPiece = null;
            rook.place(matrixboard[end.mBoardPosition.x + 1, end.mBoardPosition.y]);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
