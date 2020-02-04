using System.Collections.Generic;
using UnityEngine;

public class FLRook : FLPiece
{
	public bool hasMoved = false;
	public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
	{
		List<Vector2Int> locations = new List<Vector2Int>();
		foreach (Vector2Int dir in RookDirections)
		{
			for (int i = 1; i <= 3; i++)
			{
				Vector2Int newRooklocation = new Vector2Int(gridPoint.x + i * dir.x, gridPoint.y + i * dir.y);
				locations.Add(newRooklocation);
				if (FLGameManager.instance.PieceAtGrid(newRooklocation))
				{
					break;
				}
			}
		}

		foreach (Vector2Int dir in BishopDirections)
		{
			for (int i = 1; i <= 3; i++)
			{
				Vector2Int newBishoplocation = new Vector2Int(gridPoint.x + i * dir.x, gridPoint.y + i * dir.y);
				locations.Add(newBishoplocation);
				if (FLGameManager.instance.PieceAtGrid(newBishoplocation))
				{
					break;
				}
			}
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
		return locations;
	}



}