using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleNoteObject_Rotation : MonoBehaviour
{

    public void Launch(Vector3 from,Vector3 rotate, float time)
    {
        //初期位置に持っていって
        transform.position = from;

        //time秒かけてrotate分回転する
        //SetEase(Ease.Linear)は動き方の補正、等速で移動するようにする
        //DORotate(回転量,かける時間,);
        transform.DORotate(rotate, time, RotateMode.LocalAxisAdd).SetEase(Ease.Linear);

        //スタートからtime秒後＝アニメーション終了後に自己破壊
        Destroy(gameObject, time);
    }
}
