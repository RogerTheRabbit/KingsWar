using UnityEngine;

public enum GameState { WELCOME, GAME, PAUSED }

public class GameManager : MonoBehaviour
{

    public Board board;
    public PieceManager pieceManager;
    public TurnManager turnManager;
    public GameObject cardPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TESTTT");
        Debug.Log(board);
        board.Create();
        pieceManager.Setup(board, turnManager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
