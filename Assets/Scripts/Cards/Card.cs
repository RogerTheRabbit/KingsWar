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

    public string text = "";

    public virtual void init(TurnManager turnmanager, PieceManager pieceManager,bool white)
    {

        // GetComponent<Image>().color = Color.clear;

        this.turnManager = turnmanager;
        this.pieceManager = pieceManager;
        this.white = white;

        GameObject cardPanel = new GameObject("cardPanel");
        cardPanel.transform.SetParent(this.transform);
        cardPanel.transform.localPosition = new Vector3(-1.37343001f, 1.37884998f, 0);
        Image cardImage = cardPanel.AddComponent<Image>();
        cardImage.color = Color.red;
        cardPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(56, 80);

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
        manaTextBox.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);

        GameObject cardBorder = new GameObject("cardBorder");
        cardBorder.transform.SetParent(manaPanel.transform);
        cardBorder.transform.localPosition = new Vector3(14.7553997f, -26.8768997f, 0);
        Image cardBorderImage = cardBorder.AddComponent<Image>();
        cardBorderImage.sprite = Resources.Load<Sprite>("toppng.com-board-game-blank-card-template-743x1025");
        cardBorder.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 85);

        GameObject cardTextBox = new GameObject("cardText");
        cardTextBox.transform.SetParent(cardPanel.transform);
        cardTextBox.transform.localPosition = new Vector3(0, -8.80000019f, 0);
        Text cardText = cardTextBox.AddComponent<Text>();
        cardText.text = text.ToString();
        cardText.color = Color.white;
        cardText.fontSize = 80;
        cardText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        cardTextBox.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.1f, 0.1f);
        cardTextBox.GetComponent<RectTransform>().sizeDelta = new Vector2(530, 460);

    }

    public bool canPlayCard(Card card)
    {
        return turnManager.canPlayCard(card);
    }

    public void spendMana()
    {
        turnManager.spendMana(manaCost);
    }

    public abstract bool playCard(Cell pieceLocation);

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


        if (targetCell != null && playCard(targetCell))
        {
            Player tempPlayer = white ? turnManager.whitePlayer : turnManager.blackPlayer;
            foreach(Card card in tempPlayer.cards) {
                if (card == this) {
                    gameObject.SetActive(false);
                    Object.Destroy(this);
                }
            }
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
