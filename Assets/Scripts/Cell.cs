using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cell : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Image mOutlineImage;
    public Vector2Int mBoardPosition = Vector2Int.zero;
    public Board mBoard = null;
    public RectTransform mRectTransform = null;

    public Piece currentPiece = null;

    public void RemovePiece()
    {
        if (currentPiece != null)
        {
            if(currentPiece is King) {
                SceneManager.LoadScene(currentPiece.white ? "EndGameBlack" :"EndGameWhite");
            }
            currentPiece.Kill();
        }
    }


    public void Setup(Vector2Int newBoardPosition, Board newBoard)
    {
        mBoardPosition = newBoardPosition;
        mBoard = newBoard;

        mRectTransform = GetComponent<RectTransform>();
    }
}
