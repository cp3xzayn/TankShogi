using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public List<GameObject> pieces;
    public List<GameObject> capturedPieces;
    /// <summary> 駒の所属の名前 </summary>
    public string name;

    /// <summary> 駒の正面の情報(1が上、-1が下) </summary>
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
