using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    void Update()
    {
        SelectPiece();
    }

    [SerializeField] Material m_selectedMaterial = null;

    void SelectPiece()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (TurnManager.Instance.NowState == GameState.SelectMyPiece)
        {
            if (Physics.Raycast(ray, out hit, 10.0f))
            {
                if (Input.GetMouseButton(0))
                {
                    if (hit.collider.gameObject.tag == "Player")
                    {
                        hit.collider.gameObject.GetComponent<MeshRenderer>().material = m_selectedMaterial;
                        hit.collider.gameObject.GetComponent<PieceMoveController>().IsSelect = true;
                        StartCoroutine("NextGameState");
                    }
                }
            }
        }
    }

    IEnumerator NextGameState()
    {
        yield return new WaitForSeconds(2f);
        TurnManager.Instance.SetNowState(GameState.MoveMyPiece);
    }
}
