using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoid_Item : ItemBehaviour
{
    //5月16日の応用問題的な
    public override void Launch(Transform from,Transform[] path, float time)
    {
        Sequence sequence = DOTween.Sequence();

        transform.position = from.position;

        Vector3 scale = transform.localScale;
        transform.localScale = Vector3.zero;

        Vector3[] pathPosition = new Vector3[path.Length];

        for (int i = 0; i < path.Length; i++)
        {
            pathPosition[i] = path[i].position;
        }

        sequence.Join(transform.DOPath(pathPosition, time, PathType.CatmullRom).SetEase(Ease.InSine));
        sequence.Join(transform.DOScale(scale, time * 0.5f).SetEase(Ease.InSine));
        sequence.Join(transform.DORotate(new Vector3(0, 0, 720), time, RotateMode.LocalAxisAdd).SetEase(Ease.InSine));
        sequence.OnComplete(() =>
        {
            Destroy(gameObject);
        });

        animationSequence = sequence;
        animationSequence.Play();
    }

    public override void Interact()
    {
        //AvoidItemを叩いたときは失敗的な
        //きたないSEが鳴る
        SEShooter.Instance.Miss();
    }
}
