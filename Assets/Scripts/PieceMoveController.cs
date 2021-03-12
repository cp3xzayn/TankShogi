using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PieceMoveController : MonoBehaviour
{
    /// <summary> 駒の情報 <summary>
    [SerializeField] Transform t = null;
    /// <summary> 選択されたかを判断する </summary>
    private bool isSelect;
    bool isMove = true;

    /// <summary>
    /// 選択されたかを判断する
    /// </summary>
    public bool IsSelect
    {
        set { isSelect = value; }
        get { return isSelect; }
    }

    void Update()
    {
        if (TurnManager.Instance.NowState == GameState.MoveMyPiece && IsSelect)
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
        isMove = false;
        //1秒で座標（1,1,1）に移動
        t.DOMove(v, 1.0f).OnComplete(() => OnChange());
    }

    /// <summary>
    /// Stateと駒の色を変更する関数
    /// </summary>
    void OnChange()
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        isMove = true;
        TurnManager.Instance.SetNowState(GameState.EndMyTurn);
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
            if (Input.GetMouseButton(0) && isMove)
            {
                Vector3 m_nextPosition = new Vector3(hit.collider.gameObject.transform.position.x,
                    hit.collider.gameObject.transform.position.y + 0.5f,
                    hit.collider.gameObject.transform.position.z);
                PieceMove(m_nextPosition);
            }
        }
    }
}
