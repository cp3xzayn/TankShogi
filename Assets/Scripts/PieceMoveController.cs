using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PieceMoveController : MonoBehaviour
{
    [SerializeField] Transform t = null;
    Vector3 v = new Vector3(1.5f, 0.5f, 1.5f);

    void Start()
    {
        
    }

    void Update()
    {
        //1秒で座標（1,1,1）に移動
        t.DOMove( v,  //移動後の座標
            1.0f       //時間
            );
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
