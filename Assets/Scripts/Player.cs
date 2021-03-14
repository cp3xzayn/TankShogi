using System.Collections.Generic;
using UnityEngine;
public class Player
{
    public List<GameObject> pieces;
    public List<GameObject> capturedPieces;

    public string name;
    public int forward;

    public Player(string name, bool zMovement)
    {
        this.name = name;
        pieces = new List<GameObject>();
        capturedPieces = new List<GameObject>();

        if (zMovement)
        {
            this.forward = 1;
        }
        else
        {
            this.forward = -1;
        }
    }
}
