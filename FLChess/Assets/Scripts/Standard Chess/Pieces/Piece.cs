//Abstract Class for all pieces
using System.Collections.Generic;
using UnityEngine;

public enum PieceType {King, Queen, Bishop, Knight, Rook, Pawn};

public abstract class Piece : MonoBehaviour
{
    public PieceType type;

    //used to hold directions for rook
    protected Vector2Int[] RookDirections = {new Vector2Int(0,1), new Vector2Int(1, 0), 
        new Vector2Int(0, -1), new Vector2Int(-1, 0)};

    //used to hold direction for bishop
    protected Vector2Int[] BishopDirections = {new Vector2Int(1,1), new Vector2Int(1, -1), 
        new Vector2Int(-1, -1), new Vector2Int(-1, 1)};

    public abstract List<Vector2Int> MoveLocations(Vector2Int gridPoint);
}
