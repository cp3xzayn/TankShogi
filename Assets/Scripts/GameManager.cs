using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] FieldManager fieldManager = null;
    [SerializeField] GameObject m_hohei = null;

    private GameObject[,] pieces;
    private Player p;
    private Player e;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pieces = new GameObject[7, 5];
        p = new Player("player", true);
        e = new Player("Enemy", false);
        InitialSetUp();
    }

    /// <summary>
    /// 駒の初期化
    /// </summary>
    void InitialSetUp()
    {
        for (int i = 0; i < 5; i++)
        {
            AddPiece(m_hohei, p, 1, i);
        }
        for (int j = 0; j < 5; j++)
        {
            AddPiece(m_hohei, e, 5, j);
        }
    }

    /// <summary>
    /// 駒をpieces[,]に追加する関数
    /// </summary>
    /// <param name="g"> 生成する駒 </param>
    /// <param name="player"></param>
    /// <param name="col"> 縦 </param>
    /// <param name="row"> 横 </param>
    public void AddPiece(GameObject g, Player player, int col, int row)
    {
        GameObject pieceObject = fieldManager.AddPiece(g, col, row);
        player.pieces.Add(pieceObject);
        pieces[col, row] = pieceObject;
    }
}
