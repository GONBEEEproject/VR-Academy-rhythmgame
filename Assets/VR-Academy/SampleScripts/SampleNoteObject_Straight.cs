using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SampleNoteObject_Straight : MonoBehaviour
{
    public void Launch(Vector3 from, Vector3 to, float time)
    {
        //初期位置に持っていって
        transform.position = from;

        //ゴールにtime秒かけて移動する
        //SetEase(Ease.Linear)は動き方の補正、等速で移動するようにする
        //DOMove(行きたい座標,かける時間).SetEase(どんな動き方をしてほしいか);
        transform.DOMove(to, time*2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}