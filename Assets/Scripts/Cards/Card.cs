using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public abstract class Card : EventTrigger
{
    public int manaCost;

    public TurnManager turnManager;
    private Cell targetCell;
    public bool white = false;

    public virtual void init(TurnManager turnmanager, bool white)
    {

        // GetComponent<Image>().color = Color.clear;

        this.turnManager = turnmanager;
        this.white = white;

        GameObject manaTextBox = new GameObject("manaCost");
        manaTextBox.transform.SetParent(this.transform);
        manaTextBox.transform.localPosition = new Vector3(50f, -42.9000015f, 0f);
        Text manaText = manaTextBox.AddComponent<Text>();
        manaText.text = manaCost.ToString();
        manaText.color = Color.white;
        manaText.fontSize = 120;
        manaText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        manaTextBox.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.1f, 0.1f);
        manaTextBox.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 150);

    }

    public abstract bool playCard(Cell pieceLocation);
    public abstract void useMana();

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);


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
