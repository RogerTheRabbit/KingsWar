using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public abstract class Card : EventTrigger
{
    public int manaCost;

    public TurnManager turnManager;
    public PieceManager pieceManager;
    private Cell targetCell;
    public bool white = false;

    public virtual void init(TurnManager turnmanager, PieceManager pieceManager,bool white)
    {

        // GetComponent<Image>().color = Color.clear;

        this.turnManager = turnmanager;
        this.pieceManager = pieceManager;
        this.white = white;

        GameObject manaPanel = new GameObject("manaPanel");
        manaPanel.transform.SetParent(this.transform);
        manaPanel.transform.localPosition = new Vector3(-2.4f, 3.18f, 0);
        Image manaImage = manaPanel.AddComponent<Image>();
        manaImage.color = Color.blue;
        manaPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(25, 25);

        GameObject manaTextBox = new GameObject("manaCost");
        manaTextBox.transform.SetParent(manaPanel.transform);
        manaTextBox.transform.localPosition = new Vector3(-2.5f, 3, 0);
        Text manaText = manaTextBox.AddComponent<Text>();
        manaText.text = manaCost.ToString();
        manaText.color = Color.white;
        manaText.fontSize = 120;
        manaText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        manaTextBox.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.1f, 0.1f);
        manaTextBox.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);

    }

    public abstract bool playCard(Cell pieceLocation);
    public abstract void useMana();

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        foreach (Cell cell in turnManager.board.mAllCells)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(cell.mRectTransform, Input.mousePosition))
            {
                // If the mouse is within a valid cell, get it, and break.
                targetCell = cell;
                break;
            }
            // If the mouse is not within any highlighted cell, we don't have a valid move.
            targetCell = null;
        }


        if (targetCell != null)
        {
            playCard(targetCell);
        }


    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);

        // Follow pointer
        transform.position += (Vector3)eventData.delta;
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
