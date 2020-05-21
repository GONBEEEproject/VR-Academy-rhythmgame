using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemBehaviour : MonoBehaviour
{

    protected Sequence animationSequence;

    public virtual void Launch(Transform from,Transform[] path, float time)
    {
    }

    public virtual void Interact()
    {

    }

    public virtual void OnDestroy()
    {

    }

}
