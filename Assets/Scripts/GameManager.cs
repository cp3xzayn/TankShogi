using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] FieldManager fieldManager = null;
    [SerializeField] GameObject m_hohei = null;

    /// <summary> 盤面上にある駒を格納する配列 </summary>
    private GameObject[,] pieces;
    private List<GameObject> movedHohei;
    private Player player;
    private Player enemy;
    public Player currentPlayer;
    public Player otherPlayer;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pieces = new GameObject[7, 5];
        player = new Player("player", true);
        enemy = new Player("Enemy", false);

        currentPlayer = player;
        otherPlayer = enemy;

        InitialSetUp();
    }

    /// <summary>
    /// 駒の初期化
    /// </summary>
    void InitialSetUp()
    {
        for (int i = 0; i < 5; i++)
        {
            AddPiece(m_hohei, player, 1, i);
        }
        for (int j = 0; j < 5; j++)
        {
            AddPiece(m_hohei, enemy, 5, j);
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pieceObject"></param>
    /// <returns></returns>
    public List<Vector2Int> MoveForPiece(GameObject pieceObject)
    {
        Pieces piece = pieceObject.GetComponent<Pieces>();
        Vector2Int gridPoint = GridForPiece(pieceObject);
        List<Vector2Int> locations = piece.MoveLocation(gridPoint);

        locations.RemoveAll(gp => gp.x < 0 || gp.x > 7 || gp.y < 0 || gp.y > 5);

        return locations;
    }

    /// <summary>
    /// 駒が移動したときの処理 
    /// </summary>
    /// <param name="piece"></param>
    /// <param name="gridPoint"></param>
    public void Move(GameObject piece, Vector2Int gridPoint)
    {
        Pieces piecesComponent = piece.GetComponent<Pieces>();
        //if (piecesComponent.pieceType == PieceType.Hohei)
        //{
        //    movedHohei.Add(piece);
        //}
        Vector2Int startGridPosition = GridForPiece(piece);
        // 駒が元居た位置をnullにする
        pieces[startGridPosition.x, startGridPosition.y] = null;
        // 駒の移動先をpieceにする
        pieces[gridPoint.x, gridPoint.y] = piece;
        fieldManager.PieceMoved(piece, gridPoint);
    }

    /// <summary>
    /// 駒が選択されたときの処理
    /// </summary>
    /// <param name="piece"></param>
    public void SelectPiece(GameObject piece)
    {
        fieldManager.SelectPieces(piece);
    }

    /// <summary>
    /// 駒の選択が解除されたときの処理
    /// </summary>
    /// <param name="piece"></param>
    public void DeselectedPieces(GameObject piece)
    {
        fieldManager.DeselectPieces(piece);
    }

    /// <summary>
    /// 駒が現在のPlayerに所属しているかを判定する
    /// </summary>
    /// <param name="piece"></param>
    /// <returns></returns>
    public bool isPieceBelongPlayer(GameObject piece)
    {
        return currentPlayer.pieces.Contains(piece);
    }

    /// <summary>
    /// 駒のGameObjectを返す（盤面外が選択された場合nullを返す）
    /// </summary>
    /// <param name="gridPoint"></param>
    /// <returns></returns>
    public GameObject PieceAtGrid(Vector2Int gridPoint)
    {
        if (gridPoint.x > 7 || gridPoint.y > 7 || gridPoint.x < 0 || gridPoint.y < 0)
        {
            return null;
        }
        return pieces[gridPoint.x, gridPoint.y];
    }

    /// <summary>
    /// 駒がある位置情報を返す
    /// </summary>
    /// <param name="piece"></param>
    /// <returns></returns>
    public Vector2Int GridForPiece(GameObject piece)
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (pieces[i, j] == piece)
                {
                    return new Vector2Int(i, j);
                }
            }
        }
        return new Vector2Int(-1, -1);
    }

    /// <summary>
    /// Playerの状態を入れ替える
    /// </summary>
    public void NextPlayer()
    {
        Player plyer = currentPlayer;
        currentPlayer = otherPlayer;
        otherPlayer = player;
    }
}
