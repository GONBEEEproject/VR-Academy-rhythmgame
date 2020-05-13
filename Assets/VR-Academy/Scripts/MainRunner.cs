using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRunner : MonoBehaviour
{
    [Header("叩くアイテム")]
    [SerializeField]
    private GameObject hitItem;

    [Header("避けるアイテム")]
    [SerializeField]
    private GameObject avoidItem;

    [Header("座標類")]
    [SerializeField]
    private Transform from, to;

    [Header("移動時間")]
    [SerializeField]
    private float time;

    private AudioSource source;


    private void Start()
    {
        //譜面データのロードと楽曲の初期化などなどをする
    }

    private void Update()
    {
        SearchNote();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Generate(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Generate(1);
        }
    }

    /// <summary>
    /// 譜面データを読んできてアイテムを生成する
    /// </summary>
    private void SearchNote()
    {


    }

    private void Generate(int type)
    {
        GameObject item = null;
        switch (type)
        {
            //譜面タイプが0だったとき
            case 0:
                item = Instantiate(hitItem);
                break;
            //譜面タイプが1だったとき
            case 1:
                item = Instantiate(avoidItem);
                break;
            //エラーなり譜面データが読めなかった場合
            default:
                item = Instantiate(hitItem);
                break;
        }

        item.GetComponent<ItemBehaviour>().Launch(from.position, to.position, time);
    }

}
