using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public static GameScript inst;

    public MainStreet mainStreet;
    public GameObject obj_MainStreet;   
    public float movespeed;
    public bool mainstreetmove;

    public Button btn_Start;


    //public GameObject obj_CoinAndVFX;

    #region 物件移動相關
    /// <summary>
    /// 主街道移動
    /// </summary>
    void ObjMainStreetMove()
    {
        if(mainstreetmove)
        {
            obj_MainStreet.transform.Translate(new Vector3(0, 0, -1) * movespeed * Time.deltaTime);
        }
        
    }

    /// <summary>
    /// 人物移動
    /// </summary>
    void FigureMove()
    {
        MySapphiArtchanScript.inst.MoveDetection();
        MySapphiArtchanScript.inst.StartMove();
        MySapphiArtchanScript.inst.MoveControl();
    }

    /// <summary>
    /// 街道連續生成
    /// </summary>
    void StreetContinuousGenerate()
    {
        mainStreet.ControlStreetRemake();
        //mainStreet.WaitStreet();
    }



    #endregion


    /// <summary>
    /// 開始遊戲
    /// </summary>
    void StartGame()
    {
        btn_Start.onClick.AddListener(delegate () {
            btn_Start.gameObject.SetActive(false);
            MySapphiArtchanScript.inst.MoveForward();
            MySapphiArtchanScript.inst.startDetection = true;
            mainstreetmove = true;
        });
    }

    /// <summary>
    /// 顯示分數
    /// </summary>
    void ShowScore()
    {
        MySapphiArtchanScript.inst.ShowScore();
    }

    /// <summary>
    /// 顯示金幣數量
    /// </summary>
    void ShowGoldCoinNumber()
    {
        MySapphiArtchanScript.inst.ShowGoldCoinNumber();
    }


    void GameOver()
    {
        MySapphiArtchanScript.inst.GameOver();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        mainStreet.parameterInit();
        MySapphiArtchanScript.inst.GameOverInit();
        MySapphiArtchanScript.inst.GoHome();
        MySapphiArtchanScript.inst.CollisionInit();
        MySapphiArtchanScript.inst.ScoreInit();
        MySapphiArtchanScript.inst.TouchGoldCoinTimesInit();
        MySapphiArtchanScript.inst.MissTimeInit();
    }

    // Update is called once per frame
    void Update()
    {
        ObjMainStreetMove();
        FigureMove();
        ShowScore();
        ShowGoldCoinNumber();
        StreetContinuousGenerate();
        MySapphiArtchanScript.inst.AddMissTime();
        GameOver();
    }

    private void Awake()
    {
        inst = this;
    }
}
