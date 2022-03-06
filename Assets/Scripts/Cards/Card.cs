using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Card : EventTrigger
{
    private TurnManager turnManager;
    private Cell targetCell;

    void Create(TurnManager turnManager)
    {
        this.turnManager = turnManager;
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

        foreach (Cell cell in targetCell.mBoard.mAllCells)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(cell.mRectTransform, Input.mousePosition))
            {
                Debug.Log("HERE");
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
