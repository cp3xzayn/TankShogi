using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 歩兵の情報を持つ派生クラス
/// </summary>
public  class Hohei : Pieces
{
    public override List<Vector2Int> MoveLocation(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>();

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

        return locations;
    }
}
