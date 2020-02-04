﻿using System.Collections.Generic;
using UnityEngine;

public class FLKing : FLPiece
{
	public bool hasMoved = false;
	public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
	{
		List<Vector2Int> locations = new List<Vector2Int>();
		List<Vector2Int> directions = new List<Vector2Int>(BishopDirections);
		directions.AddRange(RookDirections);

		foreach (Vector2Int dir in directions)
		{
			Vector2Int nextKinglocation = new Vector2Int(gridPoint.x + dir.x, gridPoint.y + dir.y);
			locations.Add(nextKinglocation);
		}


		return locations;
	}

}
