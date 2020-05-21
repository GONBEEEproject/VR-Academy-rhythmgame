using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//1インスタンスで1ノーツ保持する
public class Note
{
    public float Timing { get; set; }
    public int Type { get; set; }
}

public class MainRunner : MonoBehaviour
{
    private static MainRunner instance;
    public static MainRunner Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<MainRunner>();
            return instance;
        }
    }

    [Header("譜面データのパス")]
    [SerializeField]
    private string csvPath;

    [Header("叩くアイテム")]
    [SerializeField]
    private GameObject hitItem;

    [Header("避けるアイテム")]
    [SerializeField]
    private GameObject avoidItem;

    [Header("座標類")]
    [SerializeField]
    private Transform[] hitPath;
    [SerializeField]
    private Transform[] avoidPath;

    [Header("移動時間")]
    [SerializeField]
    private float time;

    [Header("衝突用")]
    public string noteTag = "Note";

    private List<Note> notes = new List<Note>();
    private int noteID = 0;

    private AudioSource source;

    private bool isPlaying = false;


    private void Start()
    {
        source = GetComponent<AudioSource>();
        Load();
        Invoke(nameof(GameStart), 5f);
    }

    private void GameStart()
    {
        isPlaying = true;
        source.Play();
    }

    private void Load()
    {
        //譜面データの中身を持ってくる
        //StringReaderを噛ませて読む準備
        var csv = Resources.Load(csvPath) as TextAsset;
        var reader = new StringReader(csv.text);

        //ロードして配列に落としてくる
        while (reader.Peek() > -1)
        {
            /* 譜面データの中身は1行が1ノーツ
             * 1列目がタイミング
             * 2列目がノーツタイプ
             * ノーツを新規宣言してそれぞれデータを入れたあとに
             * ノーツリストに追加してループを出る
             */
            string row = reader.ReadLine();
            string[] data = row.Split(',');
            var n = new Note();
            n.Timing = float.Parse(data[0]);
            n.Type = int.Parse(data[1]);

            notes.Add(n);
        }
    }

    private void Update()
    {
        if (isPlaying)
        {
            SearchNote();
        }
    }

    /// <summary>
    /// 譜面データを読んできてアイテムを生成する
    /// </summary>
    private void SearchNote()
    {
        //ノーツを最後まで生成したらゲーム終了
        if (noteID < notes.Count)
        {
            /* ノーツ生成ロジック
             * 保持してるタイミング情報は楽曲再生時間でのジャストなので
             * アニメーションする用のオフセット分を引いて早めに生成する
             * 規模が大きくなった時のために時間は他の場所で管理するのがいい
             */
            if (notes[noteID].Timing - time < source.time)
            {
                Generate(notes[noteID].Type);
                noteID++;
            }
        }
        else
        {
            GameEnd();
            isPlaying = false;
        }
    }

    private void GameEnd()
    {
        //終了処理？
    }

    private void Generate(int type)
    {
        GameObject item = null;
        Transform[] sendPath = new Transform[0];
        switch (type)
        {
            //譜面タイプが0だったとき
            case 0:
                item = Instantiate(hitItem);
                sendPath = hitPath;
                break;
            //譜面タイプが1だったとき
            case 1:
                item = Instantiate(avoidItem);
                sendPath = avoidPath;
                break;
            //エラーなり譜面データが読めなかった場合
            default:
                item = Instantiate(hitItem);
                sendPath = hitPath;
                break;
        }

        item.GetComponent<ItemBehaviour>().Launch(sendPath[0], sendPath, time);
    }

}
