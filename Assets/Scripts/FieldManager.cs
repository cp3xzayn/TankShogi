using UnityEngine;
using DG.Tweening;

/// <summary>
/// 盤面を管理するクラス
/// </summary>
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
    
    /// <summary>
    /// 駒の移動をする
    /// </summary>
    /// <param name="piece"> 移動させる駒 </param>
    /// <param name="gridPoint"> 駒の移動先 </param>
    public void PieceMoved(GameObject piece, Vector2Int gridPoint)
    {
        Vector3 nextPosition = GridPosition.PointFromGrid(gridPoint);
        piece.transform.DOMove(nextPosition, 1.0f);
        //piece.transform.position = GridPosition.PointFromGrid(gridPoint);
    }

    /// <summary>
    /// 選択された駒を黄色にする
    /// </summary>
    /// <param name="piece"></param>
    public void SelectPieces(GameObject piece)
    {
        MeshRenderer mesh = piece.GetComponent<MeshRenderer>();
        mesh.material.color = Color.yellow;
    }

    /// <summary>
    /// 選択が解除されたら駒を白色にする
    /// </summary>
    /// <param name="piece"></param>
    public void DeselectPieces(GameObject piece)
    {
        MeshRenderer mesh = piece.GetComponent<MeshRenderer>();
        mesh.material.color = Color.white;
    }
}
