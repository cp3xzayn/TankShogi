using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ginsho : Pieces
{
    public override List<Vector2Int> MoveLocation(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>();
        List<Vector2Int> direction = new List<Vector2Int>(DiagonalDirections);
        // 駒の正面を取得する
        int forwardDirection = GameManager.instance.currentPlayer.forward;
        // 正面方向の移動
        Vector2Int forward = new Vector2Int(gridPoint.x + forwardDirection, gridPoint.y);
        // 正面方向に敵の駒がない場合
        if (!GameManager.instance.PieceAtGrid(forward))
        {
            locations.Add(forward);
        }
        // 正面方向に敵の駒がある場合
        if (GameManager.instance.PieceAtGrid(forward))
        {
            locations.Add(forward);
        }
        // 斜め方向の移動

        foreach (Vector2Int dir in direction)
        {
            Vector2Int nextGridPoint = new Vector2Int(gridPoint.x + dir.x * forwardDirection, gridPoint.y + dir.y * forwardDirection);
            locations.Add(nextGridPoint);
        }

        
        return locations;
    }
}
