using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 駒の種類
/// </summary>
public enum PieceType
{
    Hohei,
    Ginsho,
    Kinsho,
    Ousho
}

/// <summary>
/// 駒の情報を持つ基盤クラス
/// </summary>
public abstract class Pieces : MonoBehaviour
{
    /// <summary> 駒の種類 </summary>
    public PieceType pieceType;
    /// <summary> 縦横方向 </summary>
    protected Vector2Int[] VerticalDirections = {new Vector2Int(0,1), new Vector2Int(1, 0),
        new Vector2Int(0, -1), new Vector2Int(-1, 0)};
    /// <summary> 斜め方向 </summary>
    protected Vector2Int[] DiagonalDirections = {new Vector2Int(1,1), new Vector2Int(1, -1),
        new Vector2Int(-1, -1), new Vector2Int(-1, 1)};

    /// <summary>
    /// 移動方向の情報
    /// </summary>
    /// <param name="gridPoint"></param>
    /// <returns></returns>
    public abstract List<Vector2Int> MoveLocation(Vector2Int gridPoint);
}
