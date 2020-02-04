

using System.Collections.Generic;
using UnityEngine;

public class FLPlayer
{
    public List<GameObject> pieces;
    public List<GameObject> capturedPieces;
    public List<GameObject> attackingPieces;

    public string name;
    public int forward;
    public int actions;

    public FLPlayer(string name, bool positiveZMovement)
    {
        this.actions = 0;
        this.name = name;
        pieces = new List<GameObject>();
        capturedPieces = new List<GameObject>();
        attackingPieces = new List<GameObject>();

        if (positiveZMovement == true)
        {
            this.forward = 1;
        }
        else
        {
            this.forward = -1;
        }
    }
}
