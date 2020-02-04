using System.Collections.Generic;
using UnityEngine;

public class FLKnight : FLPiece
{
	public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
	{
		List<Vector2Int> locations = new List<Vector2Int>();
		int forwardDirecton = FLGameManager.instance.currentPlayer.forward;
		int backwardDirecton = -1 * forwardDirecton;

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

		if (FLGameManager.instance.PieceAtGrid(forward) == false || !FLGameManager.instance.FriendlyPieceAt(forward))
		{
			locations.Add(forward);
		}

		if (FLGameManager.instance.PieceAtGrid(forward2) == false || !FLGameManager.instance.FriendlyPieceAt(forward2))
		{
			locations.Add(forward2);
		}

		if (FLGameManager.instance.PieceAtGrid(forward3) == false || !FLGameManager.instance.FriendlyPieceAt(forward3))
		{
			locations.Add(forward3);
		}

		if (FLGameManager.instance.PieceAtGrid(forward4) == false || !FLGameManager.instance.FriendlyPieceAt(forward4))
		{
			locations.Add(forward4);
		}

		if (FLGameManager.instance.PieceAtGrid(backward) == false || !FLGameManager.instance.FriendlyPieceAt(backward))
		{
			locations.Add(backward);
		}

		if (FLGameManager.instance.PieceAtGrid(backward2) == false || !FLGameManager.instance.FriendlyPieceAt(backward2))
		{
			locations.Add(backward2);
		}

		if (FLGameManager.instance.PieceAtGrid(backward3) == false || !FLGameManager.instance.FriendlyPieceAt(backward3))
		{
			locations.Add(backward3);
		}

		if (FLGameManager.instance.PieceAtGrid(backward4) == false || !FLGameManager.instance.FriendlyPieceAt(backward4))
		{
			locations.Add(backward4);
		}


		return locations;


	}
}
