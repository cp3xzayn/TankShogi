using UnityEngine;

public class TileSelect : MonoBehaviour
{
    [SerializeField] GameObject m_MovePosition = null;
    [SerializeField] GameObject m_selectPieceManager = null;

    private GameObject tileHighlight;

    void Start()
    {
        Vector2Int gridPoint = GridPosition.GridPoint(0, 0);
        Vector3 point = GridPosition.PointFromGrid(gridPoint);
        tileHighlight = Instantiate(m_MovePosition, point, Quaternion.identity);
        tileHighlight.SetActive(false);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 point = hit.point;
            Vector2Int gridPoint = GridPosition.GridFromPoint(point);
            tileHighlight.SetActive(true);
            tileHighlight.transform.position = GridPosition.PointFromGridForField(gridPoint);
            if (Input.GetMouseButtonDown(0))
            {
                GameObject selectedPiece = GameManager.instance.PieceAtGrid(gridPoint);
                if (GameManager.instance.IsPieceBelongPlayer(selectedPiece))
                {
                    GameManager.instance.SelectPiece(selectedPiece);
                    ExitState(selectedPiece);
                }
            }
        }
        else
        {
            tileHighlight.SetActive(false);
        }
    }

    /// <summary>
    /// Tileを選択ができるようになった時に呼ばれる
    /// </summary>
    public void EnterState()
    {
        enabled = true;
    }

    /// <summary>
    /// Tileの選択ができなくなった時に呼ばれる
    /// </summary>
    /// <param name="movingPiece"></param>
    private void ExitState(GameObject movingPiece)
    {
        this.enabled = false;
        tileHighlight.SetActive(false);
        m_selectPieceManager.GetComponent<SelectPieceManager>().EnterState(movingPiece);
    }
}
