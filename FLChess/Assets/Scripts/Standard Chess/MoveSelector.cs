using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveSelector : MonoBehaviour
{
    //Overlays
    public GameObject moveLocationPrefab;
    public GameObject tileHighlightPrefab;
    public GameObject attackLocationPrefab;

    private GameObject tileHighlight;
    private GameObject movingPiece;
    private List<Vector2Int> moveLocations;
    private List<GameObject> locationHighlights;


    // Initializes as disabled since tileSelector needs to run first
    void Start()
    {
        this.enabled = false;
        //loads highlight overlay
        tileHighlight = Instantiate(tileHighlightPrefab, Geometry.PointFromGrid(new Vector2Int(0, 0)),
            Quaternion.identity, gameObject.transform);
        tileHighlight.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {   
        //creates ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        //checks to see if ray collides with a collider
        if (Physics.Raycast(ray, out hit))
        {
            // gets collision point info 
            Vector3 point = hit.point;
            Vector2Int gridPoint = Geometry.GridFromPoint(point);

            //turns on tile highlighter 
            tileHighlight.SetActive(true);
            tileHighlight.transform.position = Geometry.PointFromGrid(gridPoint);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(!moveLocations.Contains(gridPoint));
                //if a point clicked not in the moveLocations list exit moveSelector and return to tileSelector
                if (!moveLocations.Contains(gridPoint))
                {
                    CancelMove();
                    tileHighlight.SetActive(false);
                    return;
                }

                //check for valid move location
                if (GameManager.instance.PieceAtGrid(gridPoint) == null)
                {
                    
                    //game manager moves piece
                    GameManager.instance.Move(movingPiece, gridPoint);
                }
                else
                {
                    //if valid move but piece there capture piece
                    GameManager.instance.CapturePieceAt(gridPoint);
                    //move current piece to capture point
                    GameManager.instance.Move(movingPiece, gridPoint);
                }
                
                //Exits moveSelector and hands control over to tileSelector
                Debug.Log("Exiting State");
                ExitState();
            }
        }
        else
        {
            tileHighlight.SetActive(false);
        }
       

    }

    //Method to deselect current piece and move from moveSelector back to TileSelector without switching turns
    private void CancelMove()
    {
        this.enabled = false;

        foreach (GameObject highlight in locationHighlights)
        {
            Destroy(highlight);
        }
        //turn off graphical reperesentaion of selection
        GameManager.instance.DeselectPiece(movingPiece);
        //get tileSelector and turn it on
        TileSelector selector = GetComponent<TileSelector>();
        selector.EnterState();
    }


    //when called from tileselector sets piece gameobject and enables moveselector comnponent 
    public void EnterState(GameObject piece)
    {
        movingPiece = piece;
        this.enabled = true;
        //gets list of valid move locations for moving piece
        moveLocations = GameManager.instance.MovesForPiece(movingPiece);
        locationHighlights = new List<GameObject>();

        //highlights all valid moves and attacks
        foreach (Vector2Int loc in moveLocations)
        {
            GameObject highlight;
            //highlights valid attack
            if (GameManager.instance.PieceAtGrid(loc))
            {
                highlight = Instantiate(attackLocationPrefab, Geometry.PointFromGrid(loc),
                    Quaternion.identity, gameObject.transform);
            }
            //highlights valid move
            else
            {
                highlight = Instantiate(moveLocationPrefab, Geometry.PointFromGrid(loc),
                    Quaternion.identity, gameObject.transform);
            }
            locationHighlights.Add(highlight);
        }

    }

    //called to switch from moveSelector to tileSelector
    private void ExitState()
    {
        //removes any highlights on the board
        foreach (GameObject highlight in locationHighlights)
        {
            Destroy(highlight);
        }

        //disable move selector component
        this.enabled = false;
        tileHighlight.SetActive(false);
        //game manger deselects piece
        GameManager.instance.DeselectPiece(movingPiece);
        movingPiece = null;
        //returns control to tile selector component 
        TileSelector selector = GetComponent<TileSelector>();
        //sets moveable pieces to next player
        GameManager.instance.NextPlayer();
        selector.EnterState();
    }

}
