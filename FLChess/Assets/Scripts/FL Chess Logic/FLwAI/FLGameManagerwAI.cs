//Handles Game Rules and Logic pertaining to

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FLGameManagerwAI : MainMenu
{
    public static FLGameManagerwAI instance;

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
    public GameObject[,] pieces;

    private FLPlayer white;
    private FLPlayer black;
    public FLPlayer currentPlayer;
    public FLPlayer otherPlayer;

    public Text turnText;
    public Text winnerText;
    public GameObject gameOverText;
    public bool gameOver = false;


    float actionTime = 0f;
    float rollTime = 0f;
    float actionTimey = 0f;
    float rollTimey = 0f;
    public GameObject CPUActions;
    public GameObject CPUdieRoll;
    public GameObject YourAction;
    public GameObject YourDieroll;
    public Text actionTextCpu;
    public Text dieRollText;
    public Text actionTextyours;
    public Text dieRollTextyours;



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

        //Human player first
        currentPlayer = white;
        otherPlayer = black;


        /*
        currentPlayer = black;
        otherPlayer = white;
        */
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
            turnText.text = "Your Turn";
        }
        else
        {
            turnText.text = "CPU'S Turn";
        }

        /* actionTimey -= 1 * Time.deltaTime;
        if ((pickModetext != null) && (actionTimey <= 0f))
        {
            YourAction.SetActive(false);
        }

        rollTimey -= 1 * Time.deltaTime;
        if ((pickModetext != null) && (rollTimey <= 0f))
        {
            YourDieroll.SetActive(false);
        }

        actionTime -= 1 * Time.deltaTime;
        if ((pickModetext != null) && (actionTime <= 0f))
        {
            CPUActions.SetActive(false);
        }

        rollTime -= 1 * Time.deltaTime;
        if ((pickModetext != null) && (rollTime <= 0f))
        {
            CPUdieRoll.SetActive(false);
        }
        */

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


    public double EvaluateBoard(GameObject[,] pieces)
    {
        double total = 0;


        Dictionary<PieceType, int> PieceVal = new Dictionary<PieceType, int>();
        PieceVal.Add(PieceType.Pawn, 10);
        PieceVal.Add(PieceType.Rook, 30);
        PieceVal.Add(PieceType.Bishop, 35);
        PieceVal.Add(PieceType.Knight, 40);
        PieceVal.Add(PieceType.Queen, 50);
        PieceVal.Add(PieceType.King, 900);

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (pieces[j, i])
                {
                    Debug.Log(" the piece " + pieces[j, i].GetComponent<FLPiece>().type + " @" + i + "," + j);

                    if (pieces[j, i].GetComponent<FLPiece>().type == PieceType.Pawn)
                    {
                        int[,] PawnBoardWeight =
                    {
                        {0,  0,  0,  0,  0,  0,  0,  0},
                        {5, 10, 10,-20,-20, 10, 10,  5},
                        {5, -5,-10,  0,  0,-10, -5,  5},
                        {0,  0,  0, 20, 20,  0,  0,  0},
                        {5,  5, 10, 25, 25, 10,  5,  5},
                        {10, 10, 20, 30, 30, 20, 10, 10},
                        {50, 50, 50, 50, 50, 50, 50, 50},
                        {0,  0,  0,  0,  0,  0,  0,  0}
                    };

                        Vector2Int gridpoint = new Vector2Int(j, i);
                        double probability = 0;
                        if (PieceAtGrid(gridpoint) != FriendlyPieceAt(gridpoint))

                        {

                            if (pieces[j, i] == whitePawn || pieces[j, i] == whitePawn2 || pieces[j, i] == whitePawn3)
                            {
                                probability = 1 / 2;
                                return probability;
                            }

                            else if (pieces[j, i] == whiteKnight || pieces[j, i] == whiteKnight2 || pieces[j, i] == whiteKnight3)
                            {
                                probability = 1 / 3;
                                return probability;
                            }

                            else if (pieces[j, i] == whiteRook || pieces[j, i] == whiteRook2 || pieces[j, i] == whiteRook3)
                            {
                                probability = 1 / 6;
                                return probability;
                            }

                            if (pieces[j, i] == whiteBishop || pieces[j, i] == whiteBishop2 || pieces[j, i] == whiteBishop3)
                            {
                                probability = 1 / 6;
                                return probability;
                            }

                            if (pieces[j, i] == whiteQueen || pieces[j, i] == whiteQueen2 || pieces[j, i] == whiteQueen3)
                            {
                                probability = 1 / 6;
                                return probability;
                            }

                            if (pieces[j, i] == whiteKing || pieces[j, i] == whiteKing2 || pieces[j, i] == whiteKing3)
                            {
                                probability = 1 / 6;
                                return probability;
                            }
                        }



                        Debug.Log("Value" + PieceVal[pieces[j, i].GetComponent<FLPiece>().type] * (pieces[j, i].GetComponent<FLPiece>().owner == Owner.White ? -1 : 1));
                        Debug.Log("total = " + (probability * 10.0 + PawnBoardWeight[j, i]));
                        total = total + PieceVal[pieces[j, i].GetComponent<FLPiece>().type] * (pieces[j, i].GetComponent<FLPiece>().owner == Owner.White ? -1 : 1);
                        //Debug.Log("Totally total = " + (probability * 10.0 + PawnBoardWeight[j, i]));

                    }
                    else if (pieces[j, i].GetComponent<FLPiece>().type != PieceType.Rook)
                    {
                        int[,] RookBoardWeight =
                    {
                        {0,  0,  0,  5,  5,  0,  0,  0},
                        {-5,  0,  0,  0,  0,  0,  0, -5},
                        {-5,  0,  0,  0,  0,  0,  0, -5},
                        {-5,  0,  0,  0,  0,  0,  0, -5},
                        {-5,  0,  0,  0,  0,  0,  0, -5},
                        {-5,  0,  0,  0,  0,  0,  0, -5},
                        {5, 10, 10, 10, 10, 10, 10,  5},
                        {0,  0,  0,  0,  0,  0,  0,  0}
                    };

                        Vector2Int gridpoint = new Vector2Int(j, i);
                        double probability = 0;
                        if (PieceAtGrid(gridpoint) != FriendlyPieceAt(gridpoint))

                        {

                            if (pieces[j, i] == whitePawn || pieces[j, i] == whitePawn2 || pieces[j, i] == whitePawn3)
                            {
                                probability = 5 / 6;
                                return probability;
                            }

                            else if (pieces[j, i] == whiteKnight || pieces[j, i] == whiteKnight2 || pieces[j, i] == whiteKnight3)
                            {
                                probability = 2 / 3;
                                return probability;
                            }

                            else if (pieces[j, i] == whiteRook || pieces[j, i] == whiteRook2 || pieces[j, i] == whiteRook3)
                            {
                                probability = 1 / 2;
                                return probability;
                            }

                            if (pieces[j, i] == whiteBishop || pieces[j, i] == whiteBishop2 || pieces[j, i] == whiteBishop3)
                            {
                                probability = 1 / 2;
                                return probability;
                            }

                            if (pieces[j, i] == whiteQueen || pieces[j, i] == whiteQueen2 || pieces[j, i] == whiteQueen3)
                            {
                                probability = 1 / 3;
                                return probability;
                            }

                            if (pieces[j, i] == whiteKing || pieces[j, i] == whiteKing2 || pieces[j, i] == whiteKing3)
                            {
                                probability = 1 / 3;
                                return probability;
                            }
                        }


                        Debug.Log("Value" + PieceVal[pieces[j, i].GetComponent<FLPiece>().type] * (pieces[j, i].GetComponent<FLPiece>().owner == Owner.White ? -1 : 1));
                        Debug.Log("total = " + (probability * 30.0 + RookBoardWeight[j, i]));
                        total = total + PieceVal[pieces[j, i].GetComponent<FLPiece>().type] * (pieces[j, i].GetComponent<FLPiece>().owner == Owner.White ? -1 : 1);
                        //Debug.Log("Totally total = " + (probability * 30.0 + RookBoardWeight[j, i]));
                    }
                    else if (pieces[j, i].GetComponent<FLPiece>().type != PieceType.Bishop)
                    {
                        int[,] BishopBoardWeight =
                    {
                         {-20,-10,-10,-10,-10,-10,-10,-20},
                        {-10,  5,  0,  0,  0,  0,  5,-10},
                        {-10, 10, 10, 10, 10, 10, 10,-10},
                        {-10,  0, 10, 10, 10, 10,  0,-10},
                        {-10,  5,  5, 10, 10,  5,  5,-10},
                        {-10,  0,  5, 10, 10,  5,  0,-10},
                        {-10,  0,  0,  0,  0,  0,  0,-10},
                        {-20,-10,-10,-10,-10,-10,-10,-20}
                    };

                        Vector2Int gridpoint = new Vector2Int(j, i);
                        double probability = 0;
                        if (PieceAtGrid(gridpoint) != FriendlyPieceAt(gridpoint))

                        {

                            if (pieces[j, i] == whitePawn || pieces[j, i] == whitePawn2 || pieces[j, i] == whitePawn3)
                            {
                                probability = 5 / 6;
                                return probability;
                            }

                            else if (pieces[j, i] == whiteKnight || pieces[j, i] == whiteKnight2 || pieces[j, i] == whiteKnight3)
                            {
                                probability = 2 / 3;
                                return probability;
                            }

                            else if (pieces[j, i] == whiteRook || pieces[j, i] == whiteRook2 || pieces[j, i] == whiteRook3)
                            {
                                probability = 1 / 2;
                                return probability;
                            }

                            if (pieces[j, i] == whiteBishop || pieces[j, i] == whiteBishop2 || pieces[j, i] == whiteBishop3)
                            {
                                probability = 1 / 2;
                                return probability;
                            }

                            if (pieces[j, i] == whiteQueen || pieces[j, i] == whiteQueen2 || pieces[j, i] == whiteQueen3)
                            {
                                probability = 1 / 3;
                                return probability;
                            }

                            if (pieces[j, i] == whiteKing || pieces[j, i] == whiteKing2 || pieces[j, i] == whiteKing3)
                            {
                                probability = 1 / 3;
                                return probability;
                            }
                        }

                        Debug.Log("Value" + PieceVal[pieces[j, i].GetComponent<FLPiece>().type] * (pieces[j, i].GetComponent<FLPiece>().owner == Owner.White ? -1 : 1));
                        Debug.Log("total = " + (probability * 35.0 + BishopBoardWeight[j, i]));
                        total = total + PieceVal[pieces[j, i].GetComponent<FLPiece>().type] * (pieces[j, i].GetComponent<FLPiece>().owner == Owner.White ? -1 : 1);
                        //Debug.Log("Totally total = " + (probability * 35.0 + BishopBoardWeight[j, i]));
                    }
                    else if (pieces[j, i].GetComponent<FLPiece>().type != PieceType.Knight)
                    {
                        int[,] KnightBoardWeight =
                    {
                        {-50,-40,-30,-30,-30,-30,-40,-50},
                        {-40,-20,  0,  5,  5,  0,-20,-40},
                        {-30,  5, 10, 15, 15, 10,  5,-30},
                        {-30,  0, 15, 20, 20, 15,  0,-30},
                        {-30,  5, 15, 20, 20, 15,  5,-30},
                        {-30,  0, 10, 15, 15, 10,  0,-30},
                        {-40,-20,  0,  0,  0,  0,-20,-40},
                        {-50,-40,-30,-30,-30,-30,-40,-50}
                    };

                        Vector2Int gridpoint = new Vector2Int(j, i);
                        double probability = 0;
                        if (PieceAtGrid(gridpoint) != FriendlyPieceAt(gridpoint))

                        {

                            if (pieces[j, i] == whitePawn || pieces[j, i] == whitePawn2 || pieces[j, i] == whitePawn3)
                            {
                                probability = 2 / 3;
                                return probability;
                            }

                            else if (pieces[j, i] == whiteKnight || pieces[j, i] == whiteKnight2 || pieces[j, i] == whiteKnight3)
                            {
                                probability = 1 / 2;
                                return probability;
                            }

                            else if (pieces[j, i] == whiteRook || pieces[j, i] == whiteRook2 || pieces[j, i] == whiteRook3)
                            {
                                probability = 1 / 6;
                                return probability;
                            }

                            if (pieces[j, i] == whiteBishop || pieces[j, i] == whiteBishop2 || pieces[j, i] == whiteBishop3)
                            {
                                probability = 1 / 6;
                                return probability;
                            }

                            if (pieces[j, i] == whiteQueen || pieces[j, i] == whiteQueen2 || pieces[j, i] == whiteQueen3)
                            {
                                probability = 1 / 6;
                                return probability;
                            }

                            if (pieces[j, i] == whiteKing || pieces[j, i] == whiteKing2 || pieces[j, i] == whiteKing3)
                            {
                                probability = 1 / 6;
                                return probability;
                            }
                        }

                        Debug.Log("Value" + PieceVal[pieces[j, i].GetComponent<FLPiece>().type] * (pieces[j, i].GetComponent<FLPiece>().owner == Owner.White ? -1 : 1));
                        Debug.Log("total = " + (probability * 40.0 + KnightBoardWeight[j, i]));
                        total = total + PieceVal[pieces[j, i].GetComponent<FLPiece>().type] * (pieces[j, i].GetComponent<FLPiece>().owner == Owner.White ? -1 : 1);
                        //Debug.Log("Totally total = " + (probability * 40.0 + KnightBoardWeight[j, i]));
                    }
                    else if (pieces[j, i].GetComponent<FLPiece>().type != PieceType.Queen)
                    {
                        int[,] QueenBoardWeight =
                    {
                        {-20,-10,-10, -5, -5,-10,-10,-20},
                        {-10,  0,  5,  0,  0,  0,  0,-10},
                        {-10,  5,  5,  5,  5,  5,  0,-10},
                        {0,  0,  5,  5,  5,  5,  0, -5},
                        {-5,  0,  5,  5,  5,  5,  0, -5},
                        {-10,  0,  5,  5,  5,  5,  0,-10},
                        {-10,  0,  0,  0,  0,  0,  0,-10},
                        {-20,-10,-10, -5, -5,-10,-10,-20}
                    };

                        Vector2Int gridpoint = new Vector2Int(j, i);
                        double probability = 0;
                        if (PieceAtGrid(gridpoint) != FriendlyPieceAt(gridpoint))

                        {

                            if (pieces[j, i] == whitePawn || pieces[j, i] == whitePawn2 || pieces[j, i] == whitePawn3)
                            {
                                probability = 1.0;
                                return probability;
                            }

                            else if (pieces[j, i] == whiteKnight || pieces[j, i] == whiteKnight2 || pieces[j, i] == whiteKnight3)
                            {
                                probability = 5 / 6;
                                return probability;
                            }

                            else if (pieces[j, i] == whiteRook || pieces[j, i] == whiteRook2 || pieces[j, i] == whiteRook3)
                            {
                                probability = 2 / 3;
                                return probability;
                            }

                            if (pieces[j, i] == whiteBishop || pieces[j, i] == whiteBishop2 || pieces[j, i] == whiteBishop3)
                            {
                                probability = 2 / 3;
                                return probability;
                            }

                            if (pieces[j, i] == whiteQueen || pieces[j, i] == whiteQueen2 || pieces[j, i] == whiteQueen3)
                            {
                                probability = 1 / 2;
                                return probability;
                            }

                            if (pieces[j, i] == whiteKing || pieces[j, i] == whiteKing2 || pieces[j, i] == whiteKing3)
                            {
                                probability = 1 / 2;
                                return probability;
                            }
                        }

                        Debug.Log("Value" + PieceVal[pieces[j, i].GetComponent<FLPiece>().type] * (pieces[j, i].GetComponent<FLPiece>().owner == Owner.White ? -1 : 1));
                        Debug.Log("total = " + (probability * 50.0 + QueenBoardWeight[j, i]));
                        total = total + PieceVal[pieces[j, i].GetComponent<FLPiece>().type] * (pieces[j, i].GetComponent<FLPiece>().owner == Owner.White ? -1 : 1);
                        //Debug.Log("Totally total = " + (probability * 50.0 + QueenBoardWeight[j, i]));
                    }

                    else if (pieces[j, i].GetComponent<FLPiece>().type != PieceType.King)
                    {
                        int[,] KingBoardWeight =
                    {
                        {-30,-40,-40,-50,-50,-40,-40,-30},
                        {-30,-40,-40,-50,-50,-40,-40,-30},
                        {-30,-40,-40,-50,-50,-40,-40,-30},
                        {-30,-40,-40,-50,-50,-40,-40,-30},
                        {-20,-30,-30,-40,-40,-30,-30,-20},
                        {-10,-20,-20,-20,-20,-20,-20,-10},
                        {20, 20,  0,  0,  0,  0, 20, 20},
                        {20, 30, 10,  0,  0, 10, 30, 20}
                    };

                        Vector2Int gridpoint = new Vector2Int(j, i);
                        double probability = 0;
                        if (PieceAtGrid(gridpoint) != FriendlyPieceAt(gridpoint))

                        {

                            if (pieces[j, i] == whitePawn || pieces[j, i] == whitePawn2 || pieces[j, i] == whitePawn3)
                            {
                                probability = 1.0;
                                return probability;
                            }

                            else if (pieces[j, i] == whiteKnight || pieces[j, i] == whiteKnight2 || pieces[j, i] == whiteKnight3)
                            {
                                probability = 5 / 6;
                                return probability;
                            }

                            else if (pieces[j, i] == whiteRook || pieces[j, i] == whiteRook2 || pieces[j, i] == whiteRook3)
                            {
                                probability = 2 / 3;
                                return probability;
                            }

                            if (pieces[j, i] == whiteBishop || pieces[j, i] == whiteBishop2 || pieces[j, i] == whiteBishop3)
                            {
                                probability = 2 / 3;
                                return probability;
                            }

                            if (pieces[j, i] == whiteQueen || pieces[j, i] == whiteQueen2 || pieces[j, i] == whiteQueen3)
                            {
                                probability = 1 / 2;
                                return probability;
                            }

                            if (pieces[j, i] == whiteKing || pieces[j, i] == whiteKing2 || pieces[j, i] == whiteKing3)
                            {
                                probability = 1 / 2;
                                return probability;
                            }
                        }

                        Debug.Log("Value" + PieceVal[pieces[j, i].GetComponent<FLPiece>().type] * (pieces[j, i].GetComponent<FLPiece>().owner == Owner.White ? -1 : 1));
                        Debug.Log("total = " + (probability * 900.0 + KingBoardWeight[j, i]));
                        total = total + PieceVal[pieces[j, i].GetComponent<FLPiece>().type] * (pieces[j, i].GetComponent<FLPiece>().owner == Owner.White ? -1 : 1);
                        //Debug.Log("Totally total = " + (probability * 900.0 + KingBoardWeight[j, i]));
                    }
                    total = total + (pieces[j, i].GetComponent<FLPiece>().owner == Owner.White ? -1 : 1);
                    Debug.Log("Total: " + total);
                }
            }
        }

        Debug.Log("Board Eval: " + total);
        return total;
    }

    public void GenerateMoves(bool isMax)
    {

        var MovesList = new List<PossibleMove>();
        if (isMax)
        {

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (pieces[j, i] && pieces[j, i].GetComponent<FLPiece>().owner == Owner.Black)
                    {

                        FLPiece currentPiece = pieces[j, i].GetComponent<FLPiece>();
                        Vector2Int point = new Vector2Int(j, i);

                        //Debug.Log(currentPiece.GetComponent<FLPiece>().type + " @ " + j + "," + i);


                        //generates a list of moves for a piece from a specific location
                        var locations = new List<Vector2Int>(currentPiece.MoveLocations(point));

                        // filter out offboard locations
                        locations.RemoveAll(tile => tile.x < 0 || tile.x > 7
                            || tile.y < 0 || tile.y > 7);

                        //filter out locations with friendly piece
                        locations.RemoveAll(tile => FriendlyPieceAt(tile));


                        foreach (Vector2Int n in locations)
                        {
                            bool isAttack = false;
                            if (pieces[n.x, n.y] != null)
                            {
                                isAttack = true;
                            }

                            //Debug.Log("Possible move for " + currentPiece.GetComponent<FLPiece>().type + " @: " + n.x + "," + n.y);
                            GameObject[,] tempArr = new GameObject[8, 8];
                            System.Array.Copy(pieces, tempArr, 64);

                            //removes piece from current position
                            tempArr[j, i] = null;
                            //sets array where piece is moved to
                            tempArr[n.x, n.y] = pieces[j, i];
                            PossibleMove currentPossibleMove = new PossibleMove(tempArr, n, pieces[j, i], isAttack);
                            MovesList.Add(currentPossibleMove);
                            /*Used To check correct movement of pieces
                            Vector2Int gridPoint = new Vector2Int(n.x, n.y);
                            board.MovePiece(pieces[j,i], gridPoint);
                            */

                        }



                    }
                }
            }
        }
        if (!isMax)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (pieces[j, i] && pieces[j, i].GetComponent<FLPiece>().owner == Owner.White)
                    {
                        FLPiece currentPiece = pieces[j, i].GetComponent<FLPiece>();
                        Vector2Int point = new Vector2Int(j, i);

                        //Debug.Log(currentPiece.GetComponent<FLPiece>().type + " @ " + j + "," + i);


                        //generates a list of moves for a piece from a specific location
                        var locations = new List<Vector2Int>(currentPiece.MoveLocations(point));

                        // filter out offboard locations
                        locations.RemoveAll(tile => tile.x < 0 || tile.x > 7
                            || tile.y < 0 || tile.y > 7);

                        // filter out locations with friendly piece
                        locations.RemoveAll(tile => FriendlyPieceAt(tile));


                        /*
                        foreach (Vector2Int n in locations)
                        {
                                Debug.Log("Possible move for " + currentPiece.GetComponent<FLPiece>().type + " @: " + n.x + "," + n.y);
                        }
                        */



                    }
                }
            }
        }

        MovesList.Shuffle();
        var BestMovesList = new List<PossibleMove>() { null, null, null };
        double bestMoveValue = double.NegativeInfinity;
        double secBestMoveValue = double.NegativeInfinity;
        double thirdBestMoveValue = double.NegativeInfinity;

        foreach (PossibleMove move in MovesList)
        {
            double boardValue = 0.0;
            //Debug.Log("Possible move for " + move.pieceToMove.GetComponent<FLPiece>().type + " @: " + move.moveTo.x + "," + move.moveTo.y);
            if (move.isAttack)
            {
                boardValue = (EvaluateBoard(move.board) + move.pieceToMove.GetComponent<FLPiece>().AttackPower);
            }
            else
                boardValue = EvaluateBoard(move.board);

            if (boardValue > bestMoveValue)
            {
                thirdBestMoveValue = secBestMoveValue;
                BestMovesList.Insert(2, BestMovesList[1]);

                secBestMoveValue = bestMoveValue;
                BestMovesList.Insert(1, BestMovesList[0]);

                bestMoveValue = boardValue;
                BestMovesList.Insert(0, move);
            }
            else if (boardValue > secBestMoveValue)
            {
                thirdBestMoveValue = secBestMoveValue;
                BestMovesList.Insert(2, BestMovesList[1]);

                secBestMoveValue = boardValue;
                BestMovesList.Insert(1, move);
            }
            else if (boardValue > thirdBestMoveValue)
            {
                thirdBestMoveValue = boardValue;
                BestMovesList.Insert(2, move);
            }
        }

        /*

        //Debug.Log("Possible Moves: " + MovesList.Count);
        double bestMoveValue = double.NegativeInfinity;
        GameObject[,] bestMove = new GameObject[8, 8];
        GameObject pieceToMove = null;
        Vector2Int bestMoveTo = new Vector2Int();

        foreach(PossibleMove move in MovesList)
        {
            //Debug.Log("Possible move for " + move.pieceToMove.GetComponent<FLPiece>().type + " @: " + move.moveTo.x + "," + move.moveTo.y);

            double boardValue = EvaluateBoard(move.board);
            if(boardValue > bestMoveValue)
            {
                bestMoveValue = boardValue;
                bestMove = move.board;
                pieceToMove = move.pieceToMove;
                bestMoveTo = move.moveTo;
            }
        }

        Debug.Log("Piece to Move: " + pieceToMove + " to " + bestMoveTo.x + "," + bestMoveTo.y);
        

        takeAction(bestMoveTo, pieceToMove);
        */
        //yield return new WaitForSeconds(1);
        bool ActionTaken = takeAction(BestMovesList[0].moveTo, BestMovesList[0].pieceToMove);
        int index = 1;
        while (!ActionTaken)
        {
            ActionTaken = takeAction(BestMovesList[index].moveTo, BestMovesList[index].pieceToMove);
            index++;
        }

    }



    public bool takeAction(Vector2Int gridPoint, GameObject movingPiece)
    {
        //Debug.Log("Piece to Move: " + movingPiece + " to " + gridPoint.x + "," + gridPoint.y);


        //check for valid move location
        //Moving piece is piece from FLGameManager pieces[,]
        if (PieceAtGrid(gridPoint) == null && !PieceHasAttacked(movingPiece))
        {
            StartCoroutine(displayPieceForMove(movingPiece, gridPoint));
            //game manager moves piece

            return true;
        }
        else if (!PieceHasAttacked(movingPiece))
        {
            if (RollToCapture(movingPiece, gridPoint))
            {
                StartCoroutine(displayPieceForAttack(movingPiece, gridPoint));

                return true;
            }
            else
            {
                StartCoroutine(displayPiece(movingPiece));
                return true;
            }

        }

        return false;
    }

    public System.Collections.IEnumerator displayPieceForMove(GameObject movingPiece, Vector2Int gridPoint)
    {
        SelectPiece(movingPiece);
        yield return new WaitForSeconds(2);
        Move(movingPiece, gridPoint);
        CountAction();
        NextPlayer();
        DeselectPiece(movingPiece);
    }

    public System.Collections.IEnumerator displayPieceForAttack(GameObject movingPiece, Vector2Int gridPoint)
    {
        SelectPiece(movingPiece);
        yield return new WaitForSeconds(2);
        //if valid move but piece there capture piece
        CapturePieceAt(gridPoint);
        //move current piece to capture point
        Move(movingPiece, gridPoint);
        CountAction();
        NextPlayer();
        DeselectPiece(movingPiece);
    }

    public System.Collections.IEnumerator displayPiece(GameObject movingPiece)
    {
        SelectPiece(movingPiece);
        yield return new WaitForSeconds(2);
        CountAction();
        NextPlayer();
        DeselectPiece(movingPiece);
    }


    public void Move(GameObject piece, Vector2Int gridPoint)
    {

        if (piece.GetComponent<FLPiece>().type == PieceType.Pawn)
        {
            piece.GetComponent<FLPawnwAI>().hasMoved = true;
        }
        if (piece.GetComponent<FLPiece>().type == PieceType.King)
        {
            piece.GetComponent<FLKingwAI>().hasMoved = true;
        }
        if (piece.GetComponent<FLPiece>().type == PieceType.Rook)
        {
            piece.GetComponent<FLRookwAI>().hasMoved = true;
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
                winnerText.text = "You Win!";
            }
            else
            {
                winnerText.text = "CPU Wins!";
            }
            //Disables moving effectively ending the game
            Destroy(board.GetComponent<FLTileSelectorwAI>());
            Destroy(board.GetComponent<FLMoveSelectorwAI>());
        }
        Destroy(pieceToCapture);
        EvaluateBoard(pieces);
    }


    //gets all valid moves for a piece
    public List<Vector2Int> MovesForPiece(GameObject pieceObject)
    {
        FLPiece piece = pieceObject.GetComponent<FLPiece>();
        Vector2Int gridPoint = GridForPiece(pieceObject);
        //Debug.Log(gridPoint);
        //generates a list of moves for a piece from a specific location
        var locations = new List<Vector2Int>(piece.MoveLocations(gridPoint));

        // filter out offboard locations
        locations.RemoveAll(tile => tile.x < 0 || tile.x > 7
            || tile.y < 0 || tile.y > 7);

        // filter out locations with friendly piece
        locations.RemoveAll(tile => FriendlyPieceAt(tile));

        /*
        Debug.Log(piece.type + " @ " + gridPoint.x + "," + gridPoint.y);
        foreach(Vector2Int n in locations){
            Debug.Log(n.x + "," + n.y);
        }
        */


        return locations;
    }

    int loopbreak = 0;
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
            NextPlayer();
            if (QuickmodeEnabled == true)
            {
                currentTime = 120f;
            }

        }
        else if (currentPlayer == black && loopbreak < 100)
        {
            GenerateMoves(true);
            loopbreak++;
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
        Debug.Log(piece + " is trying to take " + pieceToCapture + " at " + gridPoint.x + "," + gridPoint.y);
        /* if (currentPlayer == white)
        {   
            actionTextyours.text = piece + " is trying to take " + pieceToCapture + " at " + gridPoint.x + "," + gridPoint.y;
            YourAction.SetActive(true);
            actionTimey = 3f;

        }
        else
        {
            actionTextCpu.text = piece + " is trying to take " + pieceToCapture + " at " + gridPoint.x + "," + gridPoint.y;
            CPUActions.SetActive(true);
            actionTime = 3f;

        }

    */
        dieRoll = (int)Random.Range(1, 7);


        Debug.Log(piece + " Rolled a " + dieRoll);
        /* if (currentPlayer == white)
        {
            dieRollTextyours.text = piece + " Rolled a " + dieRoll;
            YourDieroll.SetActive(true);
            rollTimey = 3f;

        }
        else
        {
            dieRollText.text = piece + " Rolled a " + dieRoll;
            YourDieroll.SetActive(true);
            rollTimey = 3f;

        }
        */

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

class PossibleMove
{
    public GameObject[,] board;
    public Vector2Int moveTo;
    public GameObject pieceToMove;
    public bool isAttack;

    public PossibleMove(GameObject[,] board, Vector2Int moveTo, GameObject pieceToMove, bool isAttack)
    {
        this.board = board;
        this.moveTo = moveTo;
        this.pieceToMove = pieceToMove;
        this.isAttack = isAttack;
    }

}

public static class IListExtensions
{
    /// <summary>
    /// Shuffles the element order of the specified list.
    /// </summary>
    public static void Shuffle<T>(this IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}
