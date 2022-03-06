using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public abstract class Piece : EventTrigger
{
    public int attack;
    public int health;
    
    public Cell startCell = null;
    public Cell endCell = null;
    public Cell targetCell = null;
    public TurnManager turnmanager = null;
    public bool white = false;
    public bool killed = false;

    public virtual void init(TurnManager turnmanager, bool white)
    {

        GetComponent<Image>().color = Color.clear;

        this.turnmanager = turnmanager;
        this.white = white;

        GameObject healthTextBox = new GameObject("health");
        healthTextBox.transform.SetParent(this.transform);
        healthTextBox.transform.localPosition = new Vector3(40f, -42.9000015f, 0f);
        Text healthText = healthTextBox.AddComponent<Text>();
        healthText.text = health.ToString();
        healthText.color = Color.white;
        healthText.fontSize = 120;
        healthText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        healthTextBox.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.1f, 0.1f);
        healthTextBox.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 150);

        GameObject attackTextBox = new GameObject("health");
        attackTextBox.transform.SetParent(this.transform);
        attackTextBox.transform.localPosition = new Vector3(-26.5f, -42.9000015f, 0f);
        Text attackText = attackTextBox.AddComponent<Text>();
        attackText.text = health.ToString();
        attackText.color = Color.white;
        attackText.fontSize = 120;
        attackText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        attackTextBox.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.1f, 0.1f);
        attackTextBox.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 150);

    }

    public virtual void place(Cell cell)
    {
        startCell = cell;
        endCell = cell;
        //TODO set cells piece to this
        startCell.currentPiece = this;
        transform.position = cell.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, 70);
        //transform.localScale = new Vector3(100, 100, 100);
        gameObject.SetActive(true);
    }

    // Checks that the user's move is valid. Ensure that there are no pieces inbetween that inhibits movement and that it is not sharing a spot with a friendly piece.
    public virtual bool hasMove(Cell start, Cell end) {
        if (end == null || start == null) {
            return false;
        }

        if (end.currentPiece != null && end.currentPiece.white == start.currentPiece.white)
        {
            return false;
        }

        // Not a valid move if the piece doesn't move.
        if(start.mBoardPosition.x - end.mBoardPosition.x == 0 && start.mBoardPosition.y - end.mBoardPosition.y == 0) {
            return false;
        }

        return true;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);


        if (this.hasMove(startCell, targetCell))
        {
            Move();
        }
        else
        {
            transform.position = startCell.gameObject.transform.position;
            return;
        }
        

        // End turn
        //turnmanager.SwitchSides(mColor);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);

        // Follow pointer
        transform.position += (Vector3)eventData.delta;

        foreach (Cell cell in startCell.mBoard.mAllCells) {
            if (RectTransformUtility.RectangleContainsScreenPoint(cell.mRectTransform, Input.mousePosition))
            {
                // If the mouse is within a valid cell, get it, and break.
                targetCell = cell;
                break;
            }
            // If the mouse is not within any highlighted cell, we don't have a valid move.
            targetCell = null;
        }

        
    }

    protected virtual void Move()
    {
        Debug.Log(targetCell);
        // If there is an enemy piece, remove it
        targetCell.RemovePiece();

        // Clear current
        startCell.currentPiece = null;

        // Switch cells
        startCell = targetCell;
        startCell.currentPiece = this;

        // Move on board
        transform.position = startCell.transform.position;
        targetCell = null;

        turnmanager.hasMoved = false;
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
