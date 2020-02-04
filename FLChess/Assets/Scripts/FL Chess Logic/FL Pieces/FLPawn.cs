
using System.Collections.Generic;
using UnityEngine;

public class FLPawn : FLPiece
{
	public bool hasMoved = false;
	public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
	{
		List<Vector2Int> locations = new List<Vector2Int>();
		//gets which direction is forwards by player 
		int forwardDirection = FLGameManager.instance.currentPlayer.forward;
		//creates a forward vector2
		Vector2Int forward = new Vector2Int(gridPoint.x, gridPoint.y + forwardDirection);
		//First Moves 2 spaces
		Vector2Int twoForward = new Vector2Int(gridPoint.x, gridPoint.y + (2 * forwardDirection));

		if (hasMoved == false)
		{
			locations.Add(twoForward);

		}

		//3x3 movement
		foreach (Vector2Int dir in RookDirections)
		{
			Vector2Int newRooklocation = new Vector2Int(gridPoint.x + 1 * dir.x, gridPoint.y + 1 * dir.y);
			locations.Add(newRooklocation);
		}
		foreach (Vector2Int dir in BishopDirections)
		{
			Vector2Int newBishoplocation = new Vector2Int(gridPoint.x + 1 * dir.x, gridPoint.y + 1 * dir.y);
			locations.Add(newBishoplocation);
		}

		/*
        //checks to see if forward location is valid
        if (FLGameManager.instance.PieceAtGrid(forward) == false)
        {
            locations.Add(forward);
        }

        //checks for valid attack
        Vector2Int forwardRight = new Vector2Int(gridPoint.x + 1, gridPoint.y + forwardDirection);
        if (FLGameManager.instance.PieceAtGrid(forwardRight))
        {
            locations.Add(forwardRight);
        }

        //checks for valid attack
        Vector2Int forwardLeft = new Vector2Int(gridPoint.x - 1, gridPoint.y + forwardDirection);
        if (FLGameManager.instance.PieceAtGrid(forwardLeft))
        {
            locations.Add(forwardLeft);
        }
        */

		return locations;
	}
}
