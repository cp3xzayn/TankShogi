using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 動かす駒を選択するクラス
/// </summary>
public class SelectPieceManager : MonoBehaviour
{
    void Start()
    {
        this.enabled = false;
    }

    void Update()
    {
        SelectPiece();
    }

    /// <summary>
    /// 駒を選択したときの処理
    /// </summary>
    void SelectPiece()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 point = hit.point;
            Vector2Int gridPoint = GridPosition.GridFromPoint(point);

            if (Input.GetMouseButtonDown(0))
            {

            }
        }
    }
}
