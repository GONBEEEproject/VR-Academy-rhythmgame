using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SampleNoteObject_Curve : MonoBehaviour
{
    public void Launch(Vector3 from, Transform[] path, float time)
    {
        //初期位置に持っていって
        transform.position = from;

        //どのルートを経由するかを変換する
        Vector3[] pathPosition = new Vector3[path.Length];

        for (int i = 0; i < path.Length; i++)
        {
            pathPosition[i] = path[i].position;
        }

        //ゴールにtime秒かけて移動する
        //SetEase(Ease.Linear)は動き方の補正、等速で移動するようにする
        //DOPathは曲線に移動させられる移動方法
        //今回は管理が楽なキャットムルロムを選択
        //DOPath(経由地の座標全ての配列,かける時間,どの曲線タイプで動かすか);
        transform.DOPath(pathPosition, time, PathType.CubicBezier).SetEase(Ease.Linear);


        //スタートからtime秒後＝アニメーション終了後に自己破壊
        Destroy(gameObject, time);
    }
}
