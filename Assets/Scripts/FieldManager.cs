using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    /// <summary>
    /// 駒の種類と生成ポジションをセットし、生成する関数
    /// </summary>
    /// <param name="piece"></param>
    /// <param name="col"></param>
    /// <param name="row"></param>
    /// <returns></returns>
    public GameObject AddPiece(GameObject piece, int col, int row)
    {
        Vector2Int gridPoint = GridPosition.GridPoint(col, row);
        GameObject newPiece = Instantiate(piece, GridPosition.PointFromGrid(gridPoint), Quaternion.identity);
        return newPiece;
    }    
}
