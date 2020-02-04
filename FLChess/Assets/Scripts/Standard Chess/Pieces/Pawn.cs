

using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public bool hasMoved = false;
    public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>();
        //gets which direction is forwards by player 
        int forwardDirection = GameManager.instance.currentPlayer.forward;
        //creates a forward vector2
        Vector2Int forward = new Vector2Int(gridPoint.x, gridPoint.y + forwardDirection);
        //First Moves 2 spaces
        Vector2Int twoForward = new Vector2Int(gridPoint.x, gridPoint.y + (2 * forwardDirection));

        if(GameManager.instance.PieceAtGrid(twoForward) == false && hasMoved == false )
        {
            locations.Add(twoForward);
        
        }

        //checks to see if forward location is valid
        if(GameManager.instance.PieceAtGrid(forward) == false)
        {
            locations.Add(forward);
        }

        //checks for valid attack
        Vector2Int forwardRight = new Vector2Int(gridPoint.x + 1, gridPoint.y + forwardDirection);
        if (GameManager.instance.PieceAtGrid(forwardRight))
        {
            locations.Add(forwardRight);
        }

        //checks for valid attack
        Vector2Int forwardLeft = new Vector2Int(gridPoint.x - 1, gridPoint.y + forwardDirection);
        if (GameManager.instance.PieceAtGrid(forwardLeft))
        {
            locations.Add(forwardLeft);
        }

        return locations;
    }
}
