using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    void Start()
    {
        PieceManager.Up = 1;
        PieceManager.Down = 0;
        PieceManager.Left = 0;
        PieceManager.Right = 0;
        Debug.Log(PieceManager.Up);
    }
}
