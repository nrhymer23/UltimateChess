
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>();
        //gets which direction is forwards by player 
        int forwardDirection = GameManager.instance.currentPlayer.forward;
        //creates a forward vector2
        Vector2Int forward = new Vector2Int(gridPoint.x, gridPoint.y + forwardDirection);

        foreach (Vector2Int dir in RookDirections)
        {
            for (int i = 1; i < 8; i++)
            {
                Vector2Int newRooklocation = new Vector2Int(gridPoint.x + i * dir.x, gridPoint.y + i * dir.y);
                locations.Add(newRooklocation);
                if (GameManager.instance.PieceAtGrid(newRooklocation))
                {
                    break;
                }
            }
        }

        foreach (Vector2Int dir in BishopDirections)
        {
            for (int i = 1; i < 8; i++)
            {
                Vector2Int newBishoplocation = new Vector2Int(gridPoint.x + i * dir.x, gridPoint.y + i * dir.y);
                locations.Add(newBishoplocation);
                if (GameManager.instance.PieceAtGrid(newBishoplocation))
                {
                    break;
                }
            }
        }

        return locations;
    }
}
