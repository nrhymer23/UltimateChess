

using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>();
        int forwardDirecton = GameManager.instance.currentPlayer.forward;
        int backwardDirecton = -1 * forwardDirecton;

        //Forward 1, Right 2
        Vector2Int forward = new Vector2Int(gridPoint.x + 2, gridPoint.y + forwardDirecton);
        //Forward 1, Left 2
        Vector2Int forward2 = new Vector2Int(gridPoint.x - 2, gridPoint.y + forwardDirecton);
        //Forward 2, Right 1
        Vector2Int forward3 = new Vector2Int(gridPoint.x + 1, gridPoint.y + (2 * forwardDirecton));
        //Forward 2, Left 1
        Vector2Int forward4 = new Vector2Int(gridPoint.x - 1, gridPoint.y + (2 * forwardDirecton));
        //Back 1, Right 2
        Vector2Int backward = new Vector2Int(gridPoint.x + 2, gridPoint.y + backwardDirecton);
        //Back 1, Left 2
        Vector2Int backward2 = new Vector2Int(gridPoint.x - 2, gridPoint.y + backwardDirecton);
        //Back 2, Right 1
        Vector2Int backward3 = new Vector2Int(gridPoint.x + 1, gridPoint.y + (2 * backwardDirecton));
        //Back 2, Left 1
        Vector2Int backward4 = new Vector2Int(gridPoint.x - 1, gridPoint.y + (2 * backwardDirecton));

        if (GameManager.instance.PieceAtGrid(forward) == false || !GameManager.instance.FriendlyPieceAt(forward))
        {
            locations.Add(forward);
        }

        if (GameManager.instance.PieceAtGrid(forward2) == false || !GameManager.instance.FriendlyPieceAt(forward2))
        {
            locations.Add(forward2);
        }

        if(GameManager.instance.PieceAtGrid(forward3) == false || !GameManager.instance.FriendlyPieceAt(forward3))
        {
            locations.Add(forward3);
        }

        if (GameManager.instance.PieceAtGrid(forward4) == false || !GameManager.instance.FriendlyPieceAt(forward4))
        {
            locations.Add(forward4);
        }

        if (GameManager.instance.PieceAtGrid(backward) == false || !GameManager.instance.FriendlyPieceAt(backward))
        {
            locations.Add(backward);
        }

        if (GameManager.instance.PieceAtGrid(backward2) == false || !GameManager.instance.FriendlyPieceAt(backward2))
        {
            locations.Add(backward2);
        }

        if (GameManager.instance.PieceAtGrid(backward3) == false || !GameManager.instance.FriendlyPieceAt(backward3))
        {
            locations.Add(backward3);
        }

        if (GameManager.instance.PieceAtGrid(backward4) == false || !GameManager.instance.FriendlyPieceAt(backward4))
        {
            locations.Add(backward4);
        }


        return locations;


    }
}
