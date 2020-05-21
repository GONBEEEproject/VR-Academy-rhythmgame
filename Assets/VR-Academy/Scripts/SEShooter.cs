using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEShooter : MonoBehaviour
{
    private static SEShooter instance;
    public static SEShooter Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<SEShooter>();
            return instance;
        }
    }

    [SerializeField]
    private AudioClip hitSE, missSE;
    private OVRHapticsClip hitClip, missClip;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();

        hitClip = new OVRHapticsClip(hitSE);
        missClip = new OVRHapticsClip(missSE);
    }


    public void Hit()
    {
        source.PlayOneShot(hitSE);
        OVRHaptics.RightChannel.Mix(hitClip);
    }

    public void Miss()
    {
        source.PlayOneShot(missSE);
        OVRHaptics.RightChannel.Mix(missClip);
    }
}
