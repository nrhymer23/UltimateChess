

using UnityEngine;
//Helper Functions to convert col,row , grindPoints, and points
public class Geometry
{
    //Helper function to turn a gridPoint to a vector 3 point
    static public Vector3 PointFromGrid(Vector2Int gridPoint)
    {
        float x = -3.5f + 1.0f * gridPoint.x;
        float z = -3.5f + 1.0f * gridPoint.y;
        return new Vector3(x, 0, z);
    }

    //Helper function to turn a col,row from GameManger.pieces array to gridPoint
    static public Vector2Int GridPoint(int col, int row)
    {
        return new Vector2Int(col, row);
    }

    //Helper function to turn a point from raycasting to a gridPoint
    static public Vector2Int GridFromPoint(Vector3 point)
    {
        int col = Mathf.FloorToInt(4.0f + point.x);
        int row = Mathf.FloorToInt(4.0f + point.z);
        return new Vector2Int(col, row);
    }
}
