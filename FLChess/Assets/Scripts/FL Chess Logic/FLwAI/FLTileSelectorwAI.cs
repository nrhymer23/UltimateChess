using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLTileSelectorwAI : MonoBehaviour
{
    public GameObject tileHighlightPrefab;

    private GameObject tileHighlight;

    // Start is called before the first frame update
    void Start()
    {
        Vector2Int gridPoint = Geometry.GridPoint(0, 0);
        Vector3 point = Geometry.PointFromGrid(gridPoint);
        tileHighlight = Instantiate(tileHighlightPrefab, point, Quaternion.identity, gameObject.transform);
        tileHighlight.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        //Checks to see if raycast hits collieder
        if (Physics.Raycast(ray, out hit))
        {
            //get vector 3 point of collision
            Vector3 point = hit.point;
            //converts from vector3 to vector2
            Vector2Int gridPoint = Geometry.GridFromPoint(point);

            //highlights tile
            tileHighlight.SetActive(true);
            tileHighlight.transform.position =
                Geometry.PointFromGrid(gridPoint);

            //get the piece at selected grid point
            if (Input.GetMouseButtonDown(0))
            {
                //gets the selected piece
                GameObject selectedPiece =
                    FLGameManagerwAI.instance.PieceAtGrid(gridPoint);
                //checks to see if piece is owned by player
                if (FLGameManagerwAI.instance.DoesPieceBelongToCurrentPlayer(selectedPiece) && !FLGameManagerwAI.instance.PieceHasAttacked(selectedPiece))
                {
                    //turns on graphical representation of a selected piece
                    FLGameManagerwAI.instance.SelectPiece(selectedPiece);
                    //initiates switching from tileselector to move selector
                    ExitState(selectedPiece);
                }
            }

        }
        else
        {
            tileHighlight.SetActive(false);
        }
    }

    public void EnterState()
    {
        enabled = true;
    }

    public void ExitState(GameObject movingPiece)
    {
        //disables tile selector component
        this.enabled = false;
        tileHighlight.SetActive(false);
        //Gets move selector component and and calls enter state function
        FLMoveSelectorwAI move = GetComponent<FLMoveSelectorwAI>();
        move.EnterState(movingPiece);

    }
}
