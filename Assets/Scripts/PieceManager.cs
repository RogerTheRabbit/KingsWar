using System;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{

    public GameObject mPiecePrefab;

    private List<Piece> mWhitePieces = null;
    private List<Piece> mBlackPieces = null;
    // Start is called before the first frame update

    private Dictionary<string, Type> pieceLibrary = new Dictionary<string, Type>()
    {
        {"P",  typeof(Knight)},
        {"R",  typeof(Knight)},
        {"KN", typeof(Knight)},
        {"B",  typeof(Knight)},
        {"K",  typeof(Knight)},
        {"Q",  typeof(Knight)}
    };


    private string[] pieceOrder = new string[16]
    {
        "P", "P", "P", "P", "P", "P", "P", "P",
        "R", "KN", "B", "Q", "K", "B", "KN", "R"
    };

    public void Setup(Board board)
    {
        // Create white pieces
        mWhitePieces = CreatePieces(Color.white, new Color32(80, 124, 159, 255), true);

        // Create place pieces
        mBlackPieces = CreatePieces(Color.black, new Color32(210, 95, 64, 255), false);

        // Place pieces
        PlacePieces(1, 0, mWhitePieces, board);
        PlacePieces(6, 7, mBlackPieces, board);

        // White goes first
        //TODO
        //SwitchSides(Color.black);
    }

    private List<Piece> CreatePieces(Color teamColor, Color32 spriteColor, bool white)
    {
        List<Piece> newPieces = new List<Piece>();

        for (int i = 0; i < pieceOrder.Length; i++)
        {
            // Get the type
            string key = pieceOrder[i];
            Type pieceType = pieceLibrary[key];

            // Create
            Piece newPiece = CreatePiece(pieceType);
            newPieces.Add(newPiece);

            // Setup
            newPiece.init(this, white);
        }

        return newPieces;
    }

    private void PlacePieces(int pawnRow, int royaltyRow, List<Piece> pieces, Board board)
    {
        for (int i = 0; i < 8; i++)
        {
            // Place pawns    
            pieces[i].place(board.mAllCells[i, pawnRow]);

            // Place royalty
            pieces[i + 8].place(board.mAllCells[i, royaltyRow]);
        }
    }

    private Piece CreatePiece(Type pieceType)
    {
        // Create new object
        GameObject newPieceObject = Instantiate(mPiecePrefab);
        newPieceObject.transform.SetParent(transform);

        // Set scale and position
        newPieceObject.transform.localScale = new Vector3(1, 1, 1);
        newPieceObject.transform.localRotation = Quaternion.identity;

        // Store new piece
        Piece newPiece = (Piece)newPieceObject.AddComponent(pieceType);

        return newPiece;
    }

    //for the player when they play a card
    public Cell getCell()
    {
        return null;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
