//Handles Game Rules and Logic pertaining to

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FLGameManager : MainMenu
{
    public static FLGameManager instance;

    public Board board;

    public GameObject whiteKing, whiteKing2, whiteKing3;

    public GameObject whiteQueen, whiteQueen2, whiteQueen3;
    public GameObject whiteBishop, whiteBishop2, whiteBishop3;
    public GameObject whiteKnight, whiteKnight2, whiteKnight3;
    public GameObject whiteRook, whiteRook2, whiteRook3;
    public GameObject whitePawn, whitePawn2, whitePawn3;

    public GameObject blackKing, blackKing2, blackKing3;
    public GameObject blackQueen, blackQueen2, blackQueen3;
    public GameObject blackBishop, blackBishop2, blackBishop3;
    public GameObject blackKnight, blackKnight2, blackKnight3;
    public GameObject blackRook, blackRook2, blackRook3;
    public GameObject blackPawn, blackPawn2, blackPawn3;

    //Array that serves as grid
    private GameObject[,] pieces;

    private FLPlayer white;
    private FLPlayer black;
    public FLPlayer currentPlayer;
    public FLPlayer otherPlayer;

    public Text turnText;
    public Text winnerText;
    public GameObject gameOverText;
    public bool gameOver = false;

    float currentTime = 0f;
    float startingTime = 120f;
    public Text countdownText;

    private int dieRoll;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //pieces arrray for game logic
        pieces = new GameObject[8, 8];

        //creates Player objects adn initializes forward direction
        white = new FLPlayer("white", true);
        black = new FLPlayer("black", false);

        currentPlayer = white;
        otherPlayer = black;

        InitialSetup();

        if (QuickmodeEnabled == true)
        {
            startingTime = 120f;
            currentTime = startingTime;
        }
        else
        {
            startingTime = 0f;
            currentTime = startingTime;
        }
    }

    private void Update()
    {
        if (currentPlayer == white)
        {
            turnText.text = "Player 1 Turn";
        }
        else
        {
            turnText.text = "Player 2 Turn";
        }

        if (QuickmodeEnabled == true)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 120;
                NextPlayer();
            }
        }
        else
        {
            currentTime += 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");
        }
    }

    //adds pieces to board, player and piceces array
    private void InitialSetup()
    {
        if (pieceSelection == 0)
        {
            AddPiece(whiteRook, white, 0, 0);
            AddPiece(whiteKnight, white, 1, 0);
            AddPiece(whiteBishop, white, 2, 0);
            AddPiece(whiteQueen, white, 3, 0);
            AddPiece(whiteKing, white, 4, 0);
            AddPiece(whiteBishop, white, 5, 0);
            AddPiece(whiteKnight, white, 6, 0);
            AddPiece(whiteRook, white, 7, 0);

            for (int i = 0; i < 8; i++)
            {
                AddPiece(whitePawn, white, i, 1);
            }

            AddPiece(blackRook, black, 0, 7);
            AddPiece(blackKnight, black, 1, 7);
            AddPiece(blackBishop, black, 2, 7);
            AddPiece(blackQueen, black, 4, 7);
            AddPiece(blackKing, black, 3, 7);
            AddPiece(blackBishop, black, 5, 7);
            AddPiece(blackKnight, black, 6, 7);
            AddPiece(blackRook, black, 7, 7);

            for (int i = 0; i < 8; i++)
            {
                AddPiece(blackPawn, black, i, 6);
            }
        }


        else if (pieceSelection == 1)
        {
            AddPiece(whiteRook2, white, 0, 0);
            AddPiece(whiteKnight2, white, 1, 0);
            AddPiece(whiteBishop2, white, 2, 0);
            AddPiece(whiteQueen2, white, 3, 0);
            AddPiece(whiteKing2, white, 4, 0);
            AddPiece(whiteBishop2, white, 5, 0);
            AddPiece(whiteKnight2, white, 6, 0);
            AddPiece(whiteRook2, white, 7, 0);

            for (int i = 0; i < 8; i++)
            {
                AddPiece(whitePawn2, white, i, 1);
            }

            AddPiece(blackRook2, black, 0, 7);
            AddPiece(blackKnight2, black, 1, 7);
            AddPiece(blackBishop2, black, 2, 7);
            AddPiece(blackQueen2, black, 4, 7);
            AddPiece(blackKing2, black, 3, 7);
            AddPiece(blackBishop2, black, 5, 7);
            AddPiece(blackKnight2, black, 6, 7);
            AddPiece(blackRook2, black, 7, 7);

            for (int i = 0; i < 8; i++)
            {
                AddPiece(blackPawn2, black, i, 6);
            }

        }
        else if (pieceSelection == 2)
        {
            AddPiece(whiteRook3, white, 0, 0);
            AddPiece(whiteKnight3, white, 1, 0);
            AddPiece(whiteBishop3, white, 2, 0);
            AddPiece(whiteQueen3, white, 3, 0);
            AddPiece(whiteKing3, white, 4, 0);
            AddPiece(whiteBishop3, white, 5, 0);
            AddPiece(whiteKnight3, white, 6, 0);
            AddPiece(whiteRook3, white, 7, 0);

            for (int i = 0; i < 8; i++)
            {
                AddPiece(whitePawn3, white, i, 1);
            }

            AddPiece(blackRook3, black, 0, 7);
            AddPiece(blackKnight3, black, 1, 7);
            AddPiece(blackBishop3, black, 2, 7);
            AddPiece(blackQueen3, black, 4, 7);
            AddPiece(blackKing3, black, 3, 7);
            AddPiece(blackBishop3, black, 5, 7);
            AddPiece(blackKnight3, black, 6, 7);
            AddPiece(blackRook3, black, 7, 7);

            for (int i = 0; i < 8; i++)
            {
                AddPiece(blackPawn3, black, i, 6);
            }


        }
    }

    public void AddPiece(GameObject prefab, FLPlayer player, int col, int row)
    {
        //adds prefab to the board
        GameObject pieceObject = board.AddPiece(prefab, col, row);
        //adds piece to the player pieces list
        player.pieces.Add(pieceObject);
        //adds piece to the piece array in GameManager
        pieces[col, row] = pieceObject;
    }

    public void CountAction()
    {
        currentPlayer.actions++;
    }


    public void Move(GameObject piece, Vector2Int gridPoint)
    {
        if (piece.GetComponent<FLPiece>().type == PieceType.Pawn)
        {
            piece.GetComponent<FLPawn>().hasMoved = true;
        }
        if (piece.GetComponent<FLPiece>().type == PieceType.King)
        {
            piece.GetComponent<FLKing>().hasMoved = true;
        }
        if (piece.GetComponent<FLPiece>().type == PieceType.Rook)
        {
            piece.GetComponent<FLRook>().hasMoved = true;
        }



        //gets piece vector2 using GridForPiece function
        Vector2Int startGridPoint = GridForPiece(piece);
        //sets array where piece was to null
        pieces[startGridPoint.x, startGridPoint.y] = null;
        //sets array where piece is moved to
        pieces[gridPoint.x, gridPoint.y] = piece;
        //moves prefab on board
        board.MovePiece(piece, gridPoint);
    }

    //removes piece from GameManager.pieces array and removes prefab
    public void CapturePieceAt(Vector2Int gridPoint)
    {

        GameObject pieceToCapture = PieceAtGrid(gridPoint);
        currentPlayer.capturedPieces.Add(pieceToCapture);
        pieces[gridPoint.x, gridPoint.y] = null;
        if (pieceToCapture.GetComponent<FLPiece>().type == PieceType.King)
        {
            Debug.Log(currentPlayer.name + " wins!");
            gameOver = true;
            gameOverText.SetActive(true);
            if (currentPlayer == white)
            {
                winnerText.text = "White Wins!";
            }
            else
            {
                winnerText.text = "Black Wins!";
            }
            //Disables moving effectively ending the game
            Destroy(board.GetComponent<FLTileSelector>());
            Destroy(board.GetComponent<FLMoveSelector>());
        }
        Destroy(pieceToCapture);
    }


    //gets all valid moves for a piece
    public List<Vector2Int> MovesForPiece(GameObject pieceObject)
    {
        FLPiece piece = pieceObject.GetComponent<FLPiece>();
        Vector2Int gridPoint = GridForPiece(pieceObject);
        //generates a list of moves for a piece from a specific location
        var locations = new List<Vector2Int>(piece.MoveLocations(gridPoint));

        // filter out offboard locations
        locations.RemoveAll(tile => tile.x < 0 || tile.x > 7
            || tile.y < 0 || tile.y > 7);

        // filter out locations with friendly piece
        locations.RemoveAll(tile => FriendlyPieceAt(tile));

        return locations;
    }

    //Keeps track of player and makes sure to not overwrite player
    public void NextPlayer()
    {
        if (currentPlayer.actions == 2)
        {
            ResetAttacks();
            currentPlayer.actions = 0;
            FLPlayer tempPlayer = currentPlayer;
            currentPlayer = otherPlayer;
            otherPlayer = tempPlayer;
            if (QuickmodeEnabled == true)
            {
                currentTime = 120f;
            }
        }
    }

    //helper function to get piece from GameManager.pieces array from a gridpoint
    public GameObject PieceAtGrid(Vector2Int gridPoint)
    {
        if (gridPoint.x > 7 || gridPoint.y > 7 || gridPoint.x < 0 || gridPoint.y < 0)
        {
            return null;
        }
        return pieces[gridPoint.x, gridPoint.y];
    }

    //helper function to find where the piece is in GameManager.pieces
    public Vector2Int GridForPiece(GameObject piece)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (pieces[i, j] == piece)
                {
                    return new Vector2Int(i, j);
                }
            }
        }

        return new Vector2Int(-1, -1);
    }

    //Helper function to find friendly piece
    public bool FriendlyPieceAt(Vector2Int gridPoint)
    {
        GameObject piece = PieceAtGrid(gridPoint);

        if (piece == null)
        {
            return false;
        }

        if (otherPlayer.pieces.Contains(piece))
        {
            return false;
        }

        return true;
    }

    //Helper function to find friendly piece
    public bool DoesPieceBelongToCurrentPlayer(GameObject piece)
    {
        return currentPlayer.pieces.Contains(piece);
    }

    //turns on graphical reperesentation of a piece that is selected using gridPoint
    public void SelectPieceAtGrid(Vector2Int gridPoint)
    {
        GameObject selectedPiece = pieces[gridPoint.x, gridPoint.y];
        if (selectedPiece)
        {
            board.SelectPiece(selectedPiece);
        }
    }

    //turns on graphical reperesentation of a piece that is selected
    public void SelectPiece(GameObject piece)
    {
        board.SelectPiece(piece);
    }

    //turns off graphical representation of a piece that is selected
    public void DeselectPiece(GameObject piece)
    {
        board.DeselectPiece(piece);
    }

    public bool PieceHasAttacked(GameObject piece)
    {
        return piece.GetComponent<FLPiece>().HasAttacked;
    }

    public void ResetAttacks()
    {
        foreach (GameObject piece in currentPlayer.attackingPieces)
        {
            piece.GetComponent<FLPiece>().HasAttacked = false;
        }
        currentPlayer.attackingPieces.Clear();
    }

    public bool RollToCapture(GameObject piece, Vector2Int gridPoint)
    {
        if (piece.GetComponent<FLPiece>().type != PieceType.Knight)
        {
            piece.GetComponent<FLPiece>().HasAttacked = true;

        }

        currentPlayer.attackingPieces.Add(piece);

        GameObject pieceToCapture = PieceAtGrid(gridPoint);
        dieRoll = (int)Random.Range(1, 7);
        Debug.Log(dieRoll);
        switch (piece.GetComponent<FLPiece>().type)
        {
            case PieceType.Pawn:
                switch (pieceToCapture.GetComponent<FLPiece>().type)
                {
                    case PieceType.Pawn:
                        if (dieRoll == 6 || dieRoll == 5 || dieRoll == 4)
                            return true;
                        else return false;

                    case PieceType.Knight:
                        if (dieRoll == 6 || dieRoll == 5)
                            return true;
                        else return false;

                    default:
                        if (dieRoll == 6)
                            return true;
                        else return false;


                }

            case PieceType.Knight:
                switch (pieceToCapture.GetComponent<FLPiece>().type)
                {
                    case PieceType.Pawn:
                        if (dieRoll == 6 || dieRoll == 5 || dieRoll == 4 || dieRoll == 3)
                            return true;
                        else return false;

                    case PieceType.Knight:
                        if (dieRoll == 6 || dieRoll == 5 || dieRoll == 4)
                            return true;
                        else return false;

                    case PieceType.Bishop:
                        if (dieRoll == 6 || dieRoll == 5)
                            return true;
                        else return false;

                    case PieceType.Rook:
                        if (dieRoll == 6 || dieRoll == 5)
                            return true;
                        else return false;

                    default:
                        if (dieRoll == 6)
                            return true;
                        else return false;


                }

            case PieceType.Rook:
                switch (pieceToCapture.GetComponent<FLPiece>().type)
                {
                    case PieceType.Pawn:
                        if (dieRoll == 6 || dieRoll == 5 || dieRoll == 4 || dieRoll == 3 || dieRoll == 2)
                            return true;
                        else return false;

                    case PieceType.Knight:
                        if (dieRoll == 6 || dieRoll == 5 || dieRoll == 4 || dieRoll == 3)
                            return true;
                        else return false;

                    case PieceType.Bishop:
                        if (dieRoll == 6 || dieRoll == 5 || dieRoll == 4)
                            return true;
                        else return false;

                    case PieceType.Rook:
                        if (dieRoll == 6 || dieRoll == 5 || dieRoll == 4)
                            return true;
                        else return false;

                    default:
                        if (dieRoll == 6 || dieRoll == 5)
                            return true;
                        else return false;


                }

            case PieceType.Bishop:
                switch (pieceToCapture.GetComponent<FLPiece>().type)
                {
                    case PieceType.Pawn:
                        if (dieRoll == 6 || dieRoll == 5 || dieRoll == 4 || dieRoll == 3 || dieRoll == 2)
                            return true;
                        else return false;

                    case PieceType.Knight:
                        if (dieRoll == 6 || dieRoll == 5 || dieRoll == 4 || dieRoll == 3)
                            return true;
                        else return false;

                    case PieceType.Bishop:
                        if (dieRoll == 6 || dieRoll == 5 || dieRoll == 4)
                            return true;
                        else return false;

                    case PieceType.Rook:
                        if (dieRoll == 6 || dieRoll == 5 || dieRoll == 4)
                            return true;
                        else return false;

                    default:
                        if (dieRoll == 6 || dieRoll == 5)
                            return true;
                        else return false;


                }

            case PieceType.Queen:
                switch (pieceToCapture.GetComponent<FLPiece>().type)
                {
                    case PieceType.Pawn:
                        return true;

                    case PieceType.Knight:
                        if (dieRoll == 6 || dieRoll == 5 || dieRoll == 4 || dieRoll == 3 || dieRoll == 2)
                            return true;
                        else return false;

                    case PieceType.Bishop:
                        if (dieRoll == 6 || dieRoll == 5 || dieRoll == 4 || dieRoll == 3)
                            return true;
                        else return false;

                    case PieceType.Rook:
                        if (dieRoll == 6 || dieRoll == 5 || dieRoll == 4 || dieRoll == 3)
                            return true;
                        else return false;

                    default:
                        if (dieRoll == 6 || dieRoll == 5 || dieRoll == 4)
                            return true;
                        else return false;


                }

            case PieceType.King:
                switch (pieceToCapture.GetComponent<FLPiece>().type)
                {
                    case PieceType.Pawn:
                        return true;

                    case PieceType.Knight:
                        if (dieRoll == 6 || dieRoll == 5 || dieRoll == 4 || dieRoll == 3 || dieRoll == 2)
                            return true;
                        else return false;

                    case PieceType.Bishop:
                        if (dieRoll == 6 || dieRoll == 5 || dieRoll == 4 || dieRoll == 3)
                            return true;
                        else return false;

                    case PieceType.Rook:
                        if (dieRoll == 6 || dieRoll == 5 || dieRoll == 4 || dieRoll == 3)
                            return true;
                        else return false;

                    default:
                        if (dieRoll == 6 || dieRoll == 5 || dieRoll == 4)
                            return true;
                        else return false;


                }

        }
        return false;

    }

}
