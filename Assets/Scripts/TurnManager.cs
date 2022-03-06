using UnityEngine;

public class TurnManager : MonoBehaviour
{

    PieceManager pieceManager;
    Player player1;
    Player player2;

    void Create(PieceManager pieceManager)
    {
        this.pieceManager = pieceManager;
        player1 = new Player();
        player2 = new Player();
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
