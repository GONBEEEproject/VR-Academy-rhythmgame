using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleNoteObject_Scale : MonoBehaviour
{
    public void Launch(Vector3 from, float time)
    {
        //初期位置に持っていって
        transform.position = from;

        //元のスケールを保持しておいてから小さくする
        Vector3 scale = transform.localScale;
        transform.localScale = Vector3.zero;

        //time秒かけてスケールが元に戻る
        //SetEase(Ease.Linear)は動き方の補正、等速で移動するようにする
        transform.DOScale(scale, time).SetEase(Ease.Linear);

        //スタートからtime秒後＝アニメーション終了後に自己破壊
        Destroy(gameObject, time);
    }
}
