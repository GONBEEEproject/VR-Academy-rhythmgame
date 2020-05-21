using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hit_Item : ItemBehaviour
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
        sequence.OnComplete(() =>
        {
            Destroy(gameObject);
        });

        animationSequence = sequence;
        animationSequence.Play();
    }

    public override void Interact()
    {
        //HitItemを叩いたときはスコア加算的な
        //かっこいいSEが鳴る

        SEShooter.Instance.Hit();
    }
}
