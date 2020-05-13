using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SampleNoteObject_Straight : MonoBehaviour
{
    public void Launch(Vector3 from, Vector3 to,float time)
    {
        //初期位置に持っていって
        transform.position = from;

        //ゴールにtime秒かけて移動する
        //SetEase(Ease.Linear)は動き方の補正、等速で移動するようにする
        transform.DOMove(to, time).SetEase(Ease.Linear);

        //スタートからtime秒後＝アニメーション終了後に自己破壊
        Destroy(gameObject, time);
    }
}