using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 動かす駒を選択するクラス
/// </summary>
public class SelectPieceManager : MonoBehaviour
{
    /// <summary> マウスカーソルのあった面に表示するGameObject </summary>
    [SerializeField] GameObject m_selectedField = null;
    /// <summary> 敵の駒が取れる位置にあるときに表示するGameObject </summary>
    [SerializeField] GameObject m_attackField = null;
    /// <summary> 移動できる場所に表示するGameObject </summary>
    [SerializeField] GameObject m_moveableField = null;
    /// <summary> TileSelectコンポーネント </summary>
    [SerializeField] GameObject m_tileSelect = null;

    private GameObject m_tileHighlight;
    /// <summary> 動かす駒 </summary>
    private GameObject movingPiece;
    /// <summary>  </summary>
    private List<Vector2Int> moveLocations;
    /// <summary> 移動できる場所を表示するGameObjectを格納するList </summary>
    private List<GameObject> locationHighlights;

    void Start()
    {
        this.enabled = false;
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
                if (!moveLocations.Contains(gridPoint))
                {
                    return;
                }
                if (GameManager.instance.PieceAtGrid(gridPoint) == null)
                {
                    GameManager.instance.Move(movingPiece, gridPoint);
                }
                else
                {
                    GameManager.instance.CapturePieceAt(gridPoint);
                    GameManager.instance.Move(movingPiece, gridPoint);
                }
                ExitState();
            }
        }
        else
        {
            m_tileHighlight.SetActive(false);
        }
    }

    /// <summary>
    /// 移動先が見つからない場合にキャンセルする処理
    /// </summary>
    private void CancelMove()
    {
        this.enabled = false;
        // 生成したオブジェクトを破壊する
        foreach (GameObject highlight in locationHighlights)
        {
            Destroy(highlight);
        }

        GameManager.instance.DeselectedPieces(movingPiece);
        m_tileSelect.GetComponent<TileSelect>().EnterState();
    }

    /// <summary>
    /// 移動する駒を選択できるようになった時の処理
    /// </summary>
    /// <param name="piece"></param>
    public void EnterState(GameObject piece)
    {
        movingPiece = piece;
        this.enabled = true;

        moveLocations = GameManager.instance.MoveForPiece(movingPiece);
        locationHighlights = new List<GameObject>();

        if (moveLocations.Count == 0)
        {
            CancelMove();
        }
        foreach (Vector2Int loc in moveLocations)
        {
            GameObject highlight;
            // 駒が戻り値である場合
            if (GameManager.instance.PieceAtGrid(loc))
            {
                Debug.Log("駒を取ることができます");
                // 駒を獲得できることを示すオブジェクトを生成する
                highlight = Instantiate(m_attackField,
                    GridPosition.PointFromGridForField(loc), Quaternion.identity);
            }
            else
            {
                // 駒が移動できることを示すオブジェクトを生成する
                highlight = Instantiate(m_moveableField, 
                    GridPosition.PointFromGridForField(loc), Quaternion.identity);
            }
            locationHighlights.Add(highlight);
        }
    }

    /// <summary>
    /// 駒の選択が終わった時の処理
    /// </summary>
    private void ExitState()
    {
        this.enabled = false;
        m_tileHighlight.SetActive(false);
        GameManager.instance.DeselectedPieces(movingPiece);
        movingPiece = null;
        GameManager.instance.NextPlayer();
        m_tileSelect.GetComponent<TileSelect>().EnterState();
        foreach (GameObject highlight in locationHighlights)
        {
            Destroy(highlight);
        }
    }
}
