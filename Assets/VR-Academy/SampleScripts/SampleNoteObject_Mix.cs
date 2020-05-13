using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleNoteObject_Mix : MonoBehaviour
{

    public void Launch(Vector3 from, Vector3 to, float time)
    {
        //初期位置に持っていって
        transform.position = from;

        //元のスケールを保持しておいてから小さくする
        Vector3 scale = transform.localScale;
        transform.localScale = Vector3.zero;


        //Sequenceを宣言して、一連のアニメーションに備える
        Sequence sequence = DOTween.Sequence();

        //Joinは同時にアニメーションをするもの
        sequence.Join(transform.DOMove(to, time).SetEase(Ease.Linear));
        sequence.Join(transform.DOScale(scale, time * 0.5f).SetEase(Ease.Linear));


        //Appendは終了したあとにアニメーションが始まるもの
        sequence.Append(transform.DOScale(Vector3.zero, time * 0.5f).SetEase(Ease.Linear));

        //登録が終わったらSequenceを再生する
        sequence.Play();



        //スタートからtimeと終了後時間分＝アニメーション終了後に自己破壊
        Destroy(gameObject, time + (time * 0.5f));
    }
}
