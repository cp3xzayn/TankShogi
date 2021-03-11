using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PieceMoveController : MonoBehaviour
{
    [SerializeField] Transform t = null;
    Vector3 m_nextPosition;

    void Update()
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

    void PieceMove(Vector3 v)
    {
        //1秒で座標（1,1,1）に移動
        t.DOMove(v, 1.0f);
    }

    void check(Koma selectkoma)
    {
        switch (selectkoma)
        {
            case Koma.kinn:
                break;
            case Koma.gyoku:
                break;
            default:
                break;
        }
    }
}
public enum Koma
{ 
    kinn,
    gyoku
}
