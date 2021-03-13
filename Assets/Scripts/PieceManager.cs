using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    void Update()
    {
        SelectPiece();
    }
    
    /// <summary>
    /// 駒を選んだ時の処理
    /// </summary>
    void SelectPiece()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        switch (TurnManager.Instance.NowState)
        {
            case GameState.SelectMyPiece:
                if (Physics.Raycast(ray, out hit, 10.0f))
                {
                    if (Input.GetMouseButton(0))
                    {
                        if (hit.collider.gameObject.tag == "Player")
                        {
                            hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                            hit.collider.gameObject.GetComponent<PieceMoveController>().IsSelect = true;
                            StartCoroutine("NextMyGameState");
                        }
                    }
                }
                break;
            case GameState.SelectEnePiece:
                if (Physics.Raycast(ray, out hit, 10.0f))
                {
                    if (Input.GetMouseButton(0))
                    {
                        if (hit.collider.gameObject.tag == "Enemy")
                        {
                            hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                            hit.collider.gameObject.GetComponent<PieceMoveController>().IsSelect = true;
                            StartCoroutine("NextEneGameState");
                        }
                    }
                }
                break;
        }
    }

    IEnumerator NextMyGameState()
    {
        yield return new WaitForSeconds(1f);
        TurnManager.Instance.SetNowState(GameState.MoveMyPiece);
    }
    IEnumerator NextEneGameState()
    {
        yield return new WaitForSeconds(1f);
        TurnManager.Instance.SetNowState(GameState.MoveEnePiece);
    }
}
