using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Piece : EventTrigger
{

    public Cell startCell = null;
    public Cell endCell = null;
    public PieceManager pieceManager = null;
    public bool white = false;
    public bool killed = false;

    public virtual void init(PieceManager pieceManager, bool white)
    {
        this.pieceManager = pieceManager;
        this.white = white;
    }

    public virtual void place(Cell cell)
    {
        startCell = cell;
        endCell = cell;
        //TODO set cells piece to this
        startCell.currentPiece = this;
        transform.position = cell.transform.position;
        gameObject.SetActive(true);
    }

    // Checks that the user's move is valid. Ensure that there are no pieces inbetween that inhibits movement and that it is not sharing a spot with a friendly piece.
    public abstract bool hasMove(Cell start, Cell end);

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);


        if (this.hasMove(startCell, endCell))
        {
            Move();
        }
        

        // End turn
        //pieceManager.SwitchSides(mColor);
    }

    protected virtual void Move()
    {

        // If there is an enemy piece, remove it
        endCell.RemovePiece();

        // Clear current
        startCell.currentPiece = null;

        // Switch cells
        startCell = endCell;
        startCell.currentPiece = this;

        // Move on board
        transform.position = startCell.transform.position;
        endCell = null;
    }

    public virtual void Kill()
    {
        // Clear current cell
        startCell.currentPiece = null;

        // Remove piece
        gameObject.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
