using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Hohei : Pieces
{
    public override List<Vector2Int> MoveLocation(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>();

        int forwardDirection = GameManager.instance.currentPlayer.forward;
        // 正面方向への移動
        Vector2Int forwardOne = new Vector2Int(gridPoint.x + forwardDirection, gridPoint.y);
        if (GameManager.instance.PieceAtGrid(forwardOne) == false)
        {
            locations.Add(forwardOne);
        }

        return locations;
    }
}
