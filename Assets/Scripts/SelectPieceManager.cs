using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 動かす駒を選択するクラス
/// </summary>
public class SelectPieceManager : MonoBehaviour
{
    [SerializeField] GameObject m_field = null;
    [SerializeField] GameObject m_moveableField = null;
    [SerializeField] GameObject m_selectedField = null;
    [SerializeField] GameObject m_attackField = null;

    private GameObject m_tileHighlight;
    private List<Vector2Int> moveLocations;

    void Start()
    {
        //this.enabled = false;
        m_tileHighlight = Instantiate(m_selectedField, GridPosition.PointFromGrid(new Vector2Int(0, 0)), Quaternion.identity);
        m_tileHighlight.SetActive(false);
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
            //　マウスポイントが当たってる面に色付きの面をつける。
            m_tileHighlight.SetActive(true);
            m_tileHighlight.transform.position = GridPosition.PointFromGridForField(gridPoint);
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.gameObject != m_field)
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                    this.enabled = false;
                }
            }
        }
        else
        {
            m_tileHighlight.SetActive(false);
        }
    }
}
