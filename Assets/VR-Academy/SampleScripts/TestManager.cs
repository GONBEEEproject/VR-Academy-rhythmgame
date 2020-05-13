using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{


    [SerializeField]
    private GameObject note;

    [SerializeField]
    private Transform from, to;

    [SerializeField]
    private Transform[] path;

    [SerializeField]
    private Vector3 rotate;


    [SerializeField]
    private float time;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject go = Instantiate(note);
            go.GetComponent<SampleNoteObject_Straight>().Launch(from.position, to.position, time);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameObject go = Instantiate(note);
            go.GetComponent<SampleNoteObject_Curve>().Launch(from.position, path, time);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameObject go = Instantiate(note);
            go.GetComponent<SampleNoteObject_Rotation>().Launch(from.position, rotate, time);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameObject go = Instantiate(note);
            go.GetComponent<SampleNoteObject_Scale>().Launch(from.position, time);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            GameObject go = Instantiate(note);
            go.GetComponent<SampleNoteObject_Mix>().Launch(from.position, to.position, time);
        }
    }
}