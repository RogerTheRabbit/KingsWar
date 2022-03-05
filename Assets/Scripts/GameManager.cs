using UnityEngine;

public enum GameState { WELCOME, GAME, PAUSED }

public class GameManager : MonoBehaviour
{

    public Board board;
    public PieceManager pieceManager;

    // Start is called before the first frame update
    void Start()
    {
        board.Create();
        // pieceManager.Setup()
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
