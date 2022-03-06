using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;
using System;
using System.Collections.Generic;

public abstract class Piece : EventTrigger
{
    public int attack;
    public int health;
    
    public bool hasMoved;
    public Cell startCell = null;
    public Cell endCell = null;
    public Cell targetCell = null;
    public TurnManager turnManager = null;
    public PieceManager pieceManager = null;

    public bool white;

    public bool killed = false;

    public List<Buffs> activeBuffs = new List<Buffs>();
    GameObject shield = null;
    GameObject airRage = null;

    public virtual void init(TurnManager turnManager, bool white, PieceManager pieceManager)

    {
        GetComponent<Image>().color = Color.clear;

        this.turnManager = turnManager;
        this.white = white;
        this.pieceManager = pieceManager;

        GameObject healthPanel = new GameObject("healthPanel");
        healthPanel.transform.SetParent(this.transform);
        healthPanel.transform.localPosition = new Vector3(29.593399f, -38.6049995f, 0);
        Image healthImage = healthPanel.AddComponent<Image>();
        healthImage.color = Color.red;
        healthPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(15, 12);
        

        GameObject healthTextBox = new GameObject("health");
        healthTextBox.transform.SetParent(healthPanel.transform);
        healthTextBox.transform.localPosition = new Vector3(0f, 0f, 0f);
        Text healthText = healthTextBox.AddComponent<Text>();
        healthText.text = health.ToString();
        healthText.alignment = TextAnchor.MiddleCenter;
        healthText.color = Color.white;
        healthText.fontSize = 120;
        healthText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        healthTextBox.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.1f, 0.1f);
        healthTextBox.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 150);

        GameObject attackPanel = new GameObject("attackPanel");
        attackPanel.transform.SetParent(this.transform);
        attackPanel.transform.localPosition = new Vector3(-29.593399f, -38.6049995f, 0);
        Image attackImage = attackPanel.AddComponent<Image>();
        attackImage.color = Color.gray;
        attackPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(15, 12);

        GameObject attackTextBox = new GameObject("attack");
        attackTextBox.transform.SetParent(attackPanel.transform);
        attackTextBox.transform.localPosition = new Vector3(0f, 0f, 0f);
        Text attackText = attackTextBox.AddComponent<Text>();
        attackText.text = attack.ToString();
        attackText.alignment = TextAnchor.MiddleCenter;
        attackText.color = Color.white;
        attackText.fontSize = 120;
        attackText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        attackTextBox.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.1f, 0.1f);
        attackTextBox.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 150);

        shield = new GameObject("shield");
        shield.transform.SetParent(this.transform);
        Image shieldImage = shield.AddComponent<Image>();
        shieldImage.sprite = Resources.Load<Sprite>("Circle") as Sprite;
        shieldImage.color = new Color(1f, 0.92f, 0.016f, 0.3f);
        shield.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        shield.SetActive(true);

        activeBuffs.Add(new HolyProtectionBuff());

        airRage = new GameObject("airRage");
        airRage.transform.SetParent(this.transform);
        Image airRageImage = airRage.AddComponent<Image>();
        airRageImage.sprite = Resources.Load<Sprite>("Air-Rage") as Sprite;
        airRageImage.color = new Color(1f, 1f, 1f, 0.4f);
        airRage.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        airRage.SetActive(true);

    }

    public virtual void updateHealth()
    {
        Array.Find(gameObject.GetComponentsInChildren<Text>(), c => c.name.Equals("health")).text = health.ToString();
    }

    public virtual void updateAttack()
    {
        Array.Find(gameObject.GetComponentsInChildren<Text>(), c => c.name.Equals("attack")).text = attack.ToString();
    }

    public virtual void updateSprite()
    {
        if (activeBuffs.Exists(b => b.GetType().Equals(typeof(HolyProtectionBuff))))
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }

        if (activeBuffs.Exists(b => b.GetType().Equals(typeof(AirRageBuff))))
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }
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
        if(turnManager.hasMoved) {
            return false;
        }

        if(turnManager.isWhiteTurn == white) {
            return false;
        }

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
            action();
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

    protected virtual void action()
    {
        if (targetCell.currentPiece == null)
        {
            Move();
        }
        else
        {
            Piece enemyPiece = targetCell.currentPiece;

            if (enemyPiece.activeBuffs.Exists(b => b.GetType().Equals(typeof(HolyProtectionBuff))))
            {
                enemyPiece.activeBuffs.RemoveAll(b => b.GetType().Equals(typeof(HolyProtectionBuff)));
                enemyPiece.updateSprite();
            }
            else
            {
                enemyPiece.health -= this.attack;
            }

            

            if (activeBuffs.Exists(b => b.GetType().Equals(typeof(HolyProtectionBuff))))
            {
                activeBuffs.RemoveAll(b => b.GetType().Equals(typeof(HolyProtectionBuff)));
                updateSprite();
            }
            else
            {
                this.health -= enemyPiece.attack;
            }

            updateHealth();
            enemyPiece.updateHealth();

            if (enemyPiece.health <= 0 && this.health <= 0)
            {
                targetCell.RemovePiece();
                startCell.RemovePiece();
            }
            else if (enemyPiece.health <= 0 && this.health > 0)
            {
                Move();
            }
            else if (enemyPiece.health > 0 && this.health <= 0)
            {
                startCell.RemovePiece();
            }
            else if (enemyPiece.health > 0 && this.health > 0)
            {
                transform.position = startCell.gameObject.transform.position;
            }
        }
        turnManager.hasMoved = true;
    }

    protected virtual void Move()
    {
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
