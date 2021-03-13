using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 駒の所属
/// </summary>
public enum GroupType
{
    Player,
    Enemy
}

/// <summary>
/// 駒の種類
/// </summary>
public enum PieceType
{
    Hohei
}

public class PieceMoveController : MonoBehaviour
{
    /// <summary> 駒の位置情報 <summary>
    [SerializeField] Transform t = null;
    /// <summary> 選択されたかを判断する </summary>
    private bool isSelect;
    bool isMove = true;
    /// <summary> 駒の所属 </summary>
    [SerializeField] GroupType group;
    /// <summary> 駒の種類 </summary>
    [SerializeField] PieceType piece;

    /// <summary>
    /// 選択されたかを判断する
    /// </summary>
    public bool IsSelect
    {
        set { isSelect = value; }
        get { return isSelect; }
    }

    int m_up;
    int m_down;
    int m_left;
    int m_right;

    void Awake()
    {
        MoveableRange();
    }

    /// <summary>
    /// 移動できる範囲をセットする関数
    /// </summary>
    void MoveableRange()
    {
        if (group == GroupType.Player)
        {
            switch (piece)
            {
                case PieceType.Hohei:
                    m_up = 1;
                    m_down = 0;
                    m_left = 0;
                    m_right = 0;
                    break;
                default:
                    break;
            }
        }
        else if (group == GroupType.Enemy)
        {
            switch (piece)
            {
                case PieceType.Hohei:
                    m_up = 0;
                    m_down = 1;
                    m_left = 0;
                    m_right = 0;
                    break;
                default:
                    break;
            }
        }
    }

    void Update()
    {
        if (IsSelect)
        {
            if (TurnManager.Instance.NowState == GameState.MoveMyPiece || TurnManager.Instance.NowState == GameState.MoveEnePiece)
            {
                SetPosMove();
            }
        }
    }

    /// <summary>
    /// 駒の移動をする関数
    /// </summary>
    /// <param name="v"> 移動先のポジション </param>
    void PieceMove(Vector3 v)
    {
        isMove = false;
        //1秒で座標（1,1,1）に移動
        t.DOMove(v, 1.0f).OnComplete(() => OnChange());
    }

    /// <summary>
    /// GameStateと駒の色を変更する関数
    /// </summary>
    void OnChange()
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        IsSelect = false;
        isMove = true;
        switch (group)
        {
            case GroupType.Player:
                TurnManager.Instance.SetNowState(GameState.EndMyTurn);
                break;
            case GroupType.Enemy:
                TurnManager.Instance.SetNowState(GameState.EndEneTurn);
                break;
        }
        
    }

    /// <summary>
    /// Rayを飛ばして駒の移動位置を設定する関数
    /// </summary>
    void SetPosMove()
    {
        Transform thisGo = this.gameObject.transform;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10.0f))
        {
            if (Input.GetMouseButton(0) && isMove)
            {
                Transform hitGameObject = hit.collider.gameObject.transform;
                if (group == GroupType.Player)
                {
                    if (hitGameObject.position.x <= thisGo.position.x + m_up &&
                        hitGameObject.position.x >= thisGo.position.x - m_down &&
                        hitGameObject.position.z <= thisGo.position.z + m_left &&
                        hitGameObject.position.z >= thisGo.position.z - m_right )
                    {
                        Vector3 m_nextPosition = new Vector3(hitGameObject.position.x, hitGameObject.position.y + 0.5f, hitGameObject.position.z);
                        if (FieldInfo.Field[(int)m_nextPosition.x, (int)m_nextPosition.z] == FieldState.Empty)
                        {
                            PieceMove(m_nextPosition);
                            FieldStateChange(m_nextPosition);
                        }
                    }
                    else
                    {
                        Debug.Log("移動できる範囲外です");
                    }
                }
                else if (group == GroupType.Enemy)
                {
                    if (hitGameObject.position.x <= thisGo.position.x + m_up &&
                        hitGameObject.position.x >= thisGo.position.x - m_down &&
                        hitGameObject.position.z <= thisGo.position.z + m_left &&
                        hitGameObject.position.z >= thisGo.position.z - m_right )
                    {
                        Vector3 m_nextPosition = new Vector3(hitGameObject.position.x, hitGameObject.position.y + 0.5f, hitGameObject.position.z);
                        if (FieldInfo.Field[(int)m_nextPosition.x, (int)m_nextPosition.z] == FieldState.Empty)
                        {
                            PieceMove(m_nextPosition);
                            FieldStateChange(m_nextPosition);
                        }
                    }
                    else
                    {
                        Debug.Log("移動できる範囲外です");
                    }
                }
                
            }
        }
    }

    public void FieldColor()
    {
        m_field.GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    GameObject m_field;

    void OnCollisionStay(Collision col)
    {
        m_field = col.gameObject;
    }

    /// <summary>
    /// Fieldの情報を変える
    /// </summary>
    /// <param name="v">移動先のポジション</param>
    void FieldStateChange(Vector3 v)
    {
        switch (group)
        {
            case GroupType.Player:
                FieldInfo.Field[(int)v.x, (int)v.z] = FieldState.MyPiece;
                Debug.Log($"{(int)v.x},{(int)v.z},{FieldInfo.Field[(int)v.x, (int)v.z]}");
                break;
            case GroupType.Enemy:
                FieldInfo.Field[(int)v.x, (int)v.z] = FieldState.EnePiece;
                Debug.Log($"{(int)v.x},{(int)v.z},{FieldInfo.Field[(int)v.x, (int)v.z]}");
                break;
        }
    }
}
