

using UnityEngine;
//Handles all graphical representations of pieces
public class Board : MonoBehaviour
{
    public Material defaultMaterial;
    public Material selectedMaterial;

    //add prefab to the board
    public GameObject AddPiece(GameObject piece, int col, int row)
    {
        //turns the col,row point into a Vector2Int gridpoint using helper function from Gemometry
        Vector2Int gridPoint = Geometry.GridPoint(col, row);
        //adds piece to the gameboard
        GameObject newPiece = Instantiate(piece, Geometry.PointFromGrid(gridPoint),
            piece.transform.rotation, gameObject.transform);
        return newPiece;
    }

    //turns the selectedMaterial material on for selected piece
    public void SelectPiece(GameObject piece)
    {
        MeshRenderer renderers = piece.GetComponentInChildren<MeshRenderer>();
        defaultMaterial = piece.GetComponentInChildren<Renderer>().material;
        renderers.material = selectedMaterial;
    }

    //turns the defaultMaterial material on for selected piece
    public void DeselectPiece(GameObject piece)
    {
        MeshRenderer renderers = piece.GetComponentInChildren<MeshRenderer>();
        renderers.material = defaultMaterial;
    }

    //Removes prefab from board
    public void RemovePiece(GameObject piece)
    {
        Destroy(piece);
    }

    //Moves piece to specified point 
    public void MovePiece(GameObject piece, Vector2Int gridPoint)
    {
        piece.transform.position = Geometry.PointFromGrid(gridPoint);
    }
}
