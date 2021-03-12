using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PieceMoveController : MonoBehaviour
{
    [SerializeField] Transform t = null;
    Vector3 m_nextPosition;

    private bool isSelect;

    public bool IsSelect
    {
        set { isSelect = value; }
        get { return isSelect; }
    }

    void Update()
    {
        if (TurnManager.Instance.NowState == GameState.MoveMyPiece && IsSelect == true)
        {
            SetPosMove();
        }
    }

    /// <summary>
    /// 駒の移動をする関数
    /// </summary>
    /// <param name="v"> 移動後のポジション </param>
    void PieceMove(Vector3 v)
    {
        //1秒で座標（1,1,1）に移動
        t.DOMove(v, 1.0f);
    }

    /// <summary>
    /// Rayを飛ばして駒の移動位置を設定する関数
    /// </summary>
    void SetPosMove()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10.0f))
        {
            if (Input.GetMouseButton(0))
            {
                m_nextPosition = new Vector3(hit.collider.gameObject.transform.position.x,
                    hit.collider.gameObject.transform.position.y + 0.5f,
                    hit.collider.gameObject.transform.position.z);
                PieceMove(m_nextPosition);
            }
        }
    }
}
