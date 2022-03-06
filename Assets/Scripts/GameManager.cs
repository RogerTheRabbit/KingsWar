using UnityEngine;

public enum GameState { WELCOME, GAME, PAUSED }

public class GameManager : MonoBehaviour
{

    public Board board;
    public PieceManager pieceManager;
    public TurnManager turnManager;

    // Start is called before the first frame update
    void Start()
    {
        board.Create();
        turnManager = new TurnManager();
        pieceManager.Setup(board, turnManager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
