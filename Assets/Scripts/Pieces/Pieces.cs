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

public abstract class Pieces : MonoBehaviour
{
    public PieceType pieceType;

    public abstract List<Vector2Int> MoveLocation(Vector2Int gridPoint);
}
