using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PieceMoveController : MonoBehaviour
{
    [SerializeField] Transform t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1秒で座標（1,1,1）に移動
        t.DOMove( Vector3.one,  //移動後の座標
            1.0f       //時間
            );
    }
}
