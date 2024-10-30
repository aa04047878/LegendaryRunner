using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MySapphiArtchanScript : MonoBehaviour
{
    public static MySapphiArtchanScript inst;

    /// <summary>
    /// 動畫控制器
    /// </summary>
    public Animator ani;

    public Animator character;

    /// <summary>
    /// 移動速度
    /// </summary>
    public float moveSpeed;
    /// <summary>
    /// 碼表時間
    /// </summary>
    public float StopwatchTime;

    public bool LeftToMid;
    public bool MidToRight;
    public bool RightToMid;
    public bool MidToLeft;
    public bool startDetection;
    public bool countMissTime;

    public MoveStatus moveStatus;
    public CharacterStatus characterStatus;

    public ParticleSystem ps;

    public List<GameObject> listHitCollisions;
    public List<GameObject> listOpenHitCollisions;
    public List<Image> img_DirectionLeft = new List<Image>();
    public List<Image> img_DirectionRight = new List<Image>();

    public GameObject obj_panelTeachingLeft;
    public GameObject obj_panelTeachingRight;

    public float indexHit;
    public float indexOepn;

    public Transform cmr;
    public Transform player;

    /// <summary>
    /// 分數
    /// </summary>
    public int score;

    /// <summary>
    /// 失誤時間
    /// </summary>
    public float missTime;

    /// <summary>
    /// 觸碰金幣次數
    /// </summary>
    public int touchGoldCoinTimes;

    /// <summary>
    /// 分數數字
    /// </summary>
    public Text txt_ScoreNumber;

    /// <summary>
    /// 金幣數量
    /// </summary>
    public Text txt_GoldCoinNumber;

    public Text txt_PanelScoreNumber;
    
    public Text txt_PanelGoldCoinNumber;

    public Button btn_GoHome;
    public GameObject panel_GameOver;
    public GameObject obj_Teaching;

    #region 移動相關
    /// <summary>
    /// 移動偵測
    /// </summary>
    public void MoveDetection()
    {
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    ani.SetBool("Run", true);
        //    transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);
        //    //StopwatchTiming();
        //}

        //if (Input.GetKeyUp(KeyCode.UpArrow))
        //{
        //    ani.SetBool("Run", false);
        //}
        if(startDetection)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x == 82)
            {
                MidToLeft = true;
                moveStatus = MoveStatus.FromMidToLeftMove;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x == 82)
            {
                MidToRight = true;
                moveStatus = MoveStatus.FromMidToRightMove;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x == 86)
            {
                RightToMid = true;
                moveStatus = MoveStatus.FromRightToMidMove;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x == 78)
            {
                LeftToMid = true;
                moveStatus = MoveStatus.FromLeftToMidMove;
            }
        }       
    }

    /// <summary>
    /// 開始移動
    /// </summary>
    public void StartMove()
    {
        if (RightToMid || MidToLeft)
        {
            MoveToLeft();
        }

        if(LeftToMid|| MidToRight)
        {
            MoveToRight();
        }
    }

    /// <summary>
    /// 移動控制
    /// </summary>
    public void MoveControl()
    {
        /*
        要寫2個功能，一個控制bool參數(控制移動參數)，一個控制移動範圍
        */
        ControlMoveRange();
        ControlBoolParameter();        
    }

    /// <summary>
    /// 控制移動參數
    /// </summary>
    void ControlBoolParameter()
    {
        if(moveStatus == MoveStatus.FromMidToLeftMove && transform.position.x <=78)
        {
            MidToLeft = false;
        }

        if(moveStatus == MoveStatus.FromMidToRightMove && transform.position.x >= 86)
        {
            MidToRight = false;
        }

        if (moveStatus == MoveStatus.FromRightToMidMove && transform.position.x <= 82)
        {
            RightToMid = false;
        }

        if (moveStatus == MoveStatus.FromLeftToMidMove && transform.position.x >= 82)
        {
            LeftToMid = false;
        }
    }

    /// <summary>
    /// 控制移動範圍
    /// </summary>
    public void ControlMoveRange()
    {
        if (moveStatus == MoveStatus.FromMidToLeftMove && transform.position.x <= 78)
        {
            transform.position = new Vector3(78, transform.position.y, transform.position.z);
        }

        if (moveStatus == MoveStatus.FromMidToRightMove && transform.position.x >= 86)
        {
            transform.position = new Vector3(86, transform.position.y, transform.position.z);
        }

        if (moveStatus == MoveStatus.FromRightToMidMove && transform.position.x <= 82)
        {
            transform.position = new Vector3(82, transform.position.y, transform.position.z);
        }

        if (moveStatus == MoveStatus.FromLeftToMidMove && transform.position.x >= 82)
        {
            transform.position = new Vector3(82, transform.position.y, transform.position.z);
        }

        //if (transform.position.x <= 78)
        //{
        //    transform.position = new Vector3(78, transform.position.y, transform.position.z);
        //}

        //if (transform.position.x >= 86)
        //{
        //    transform.position = new Vector3(86, transform.position.y, transform.position.z);
        //}
    }

    /// <summary>
    /// 向前移動
    /// </summary>
    public void MoveForward()
    {
        ani.SetBool("Run", true);
    }

    /// <summary>
    /// 向左移動
    /// </summary>
    public void MoveToLeft()
    {        
        transform.Translate(new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime);       
    }

    /// <summary>
    /// 向右移動
    /// </summary>
    public void MoveToRight()
    {
        transform.Translate(new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 被車撞
    /// </summary>
    public void HitByCar()
    {
        if (characterStatus == CharacterStatus.HitByCar)
        {
            GameScript.inst.mainstreetmove = false;
            //ani.SetBool("Run", false);
            ani.SetBool("Hit", true);
            
        }
    }

    /// <summary>
    /// 跌倒
    /// </summary>
    public void FallDown()
    {        
        if (characterStatus == CharacterStatus.FallDown)
        {
            ani.SetBool("ReadyFallDown", true);
            if (moveStatus == MoveStatus.FromLeftToMidMove || moveStatus == MoveStatus.FromMidToRightMove)
            {
                GameScript.inst.mainstreetmove = false;
                Debug.Log("FallDownRight");
                //ani.SetBool("Run", false);
                character.SetBool("FallDownRight", true);
               
            }

            if (moveStatus == MoveStatus.FromRightToMidMove || moveStatus == MoveStatus.FromMidToLeftMove)
            {
                GameScript.inst.mainstreetmove = false;
                Debug.Log("FallDownLeft");
                //ani.SetBool("Run", false);
                character.SetBool("FallDownLeft", true);
                
            }
        }                        
    }

    #endregion



    void OnCollisionEnter(Collision hit)
    {
        //hit就是指碰撞到的Collision(打到的對方)
        //						碰撞到的物體的名稱
        //Debug.Log(hit.transform.name);
        if (hit.transform.tag == "Teaching" && hit.collider.name == "TeachingLeft")
        {
            Debug.Log(hit.transform.tag);
            //Teaching();
            StartCoroutine(CoDirectionLeftOpen(hit));
        }
        else if (hit.transform.tag == "Teaching" && hit.collider.name == "TeachingRight")
        {
            Debug.Log("co");
            StartCoroutine(CoDirectionRightOpen(hit));
        }
        else if (hit.collider.name == "GoldCoin" && hit.transform.tag == "GoldCoin")
        {
            //Debug.Log("Enter >> hit.collider.name : " + hit.collider.name);
            //Debug.Log("Enter >> hit.transform.tag : " + hit.transform.tag);
            hit.transform.gameObject.SetActive(false);
            hit.transform.parent.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            listHitCollisions.Add(hit.gameObject);
            Debug.Log(hit.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.name);
            Debug.Log(listHitCollisions[0].transform.name);
            GetScore();
            AddTouchGoldCoinTimes();
        }
        else
        {
            if (hit.transform.tag == "Car")
            {
                cmr.parent = null;
                cmr.LookAt(player);
                Debug.Log("Car");
                characterStatus = CharacterStatus.HitByCar;
                HitByCar();
                CountMissTime();
            }

            if (hit.transform.tag == "FallDown")
            {
                cmr.parent = null;
                cmr.LookAt(player);
                hit.gameObject.SetActive(false);
                Debug.Log("FallDown");
                characterStatus = CharacterStatus.FallDown;
                FallDown();
                CountMissTime();
            }

        }
    }

    #region 偵測有無碰到金幣 & 金幣物件打開
    /// <summary>
    /// Collision初始化
    /// </summary>
    public void CollisionInit()
    {
        listHitCollisions = new List<GameObject>();
        listOpenHitCollisions = new List<GameObject>();
    }

    /// <summary>
    /// 是否開起Collision
    /// </summary>
    public void WhetherOpenCollisions()
    {
        Debug.Log("listHitCollisions.Count : " + listHitCollisions.Count);

        //for (int i = 0; i < 6; i++)
        //{
        //    Debug.Log(listHitCollisions[i].name);
        //}

        foreach (var hit in listHitCollisions)
        {
            Debug.Log(hit.transform.name);
            //Debug.Log("最終的爸爸是誰(上) : " + hit.transform.parent.name);
            //Debug.Log("最終的爸爸是誰 : " + (hit.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.name));
            if (hit.name == "GoldCoin" && hit.transform.tag == "GoldCoin")
            {
                //Debug.Log("最終的爸爸是誰 : " + (hit.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.name));
                //Debug.Log("最終爸爸的位置 : " + (hit.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.position));
                //Debug.Log("最終爸爸的名子(下) : " + (hit.transform.parent.name));
                //Debug.Log(hit.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.position);
                if (hit.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.position.z <= -200)
                {
                    //Debug.Log("(資料搬過去之前) listOpenHitCollisions.Count" + listOpenHitCollisions.Count);
                    //Debug.Log("(資料搬過去之前) listHitCollisions.Count" + listHitCollisions.Count);
                    //Debug.Log("在-200以後的地方 ");
                    //listOpenHitCollisions.Add(hit);
                    //listHitCollisions.Remove(hit);
                    indexHit++;
                    Debug.Log($"indexHit : {indexHit}");
                    //Debug.Log("(資料搬過去以後) listOpenHitCollisions.Count" + listOpenHitCollisions.Count);
                    //Debug.Log("(資料搬過去以後) listHitCollisions.Count" + listHitCollisions.Count);
                }
            }
        }

        for (int i = 0; i < indexHit; i++)
        {                     
            //Debug.Log("(資料搬過去之前) listOpenHitCollisions.Count : " + listOpenHitCollisions.Count);
            Debug.Log("(資料搬過去之前) listHitCollisions.Count : " + listHitCollisions.Count);
            //Debug.Log("在-200以後的地方 ");
            listHitCollisions[0].SetActive(true);
            listHitCollisions.RemoveAt(0);
            //Debug.Log("(資料搬過去以後) listOpenHitCollisions.Count : " + listOpenHitCollisions.Count);
            Debug.Log("(資料搬過去以後) listHitCollisions.Count : " + listHitCollisions.Count);                             
        }

        indexHit = 0;
        

        //for (int i = 0; i < indexHit; i++)
        //{
        //    //Debug.Log(listHitCollisions[i].name);
        //    //Debug.Log("最終的爸爸是誰(上) : " + listHitCollisions[i].transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.name);
        //    //Debug.Log("最終的爸爸是誰 : " + (hit.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.name));
        //    if (listHitCollisions[0].name == "GoldCoin" && listHitCollisions[0].transform.tag == "GoldCoin")
        //    {
        //        //Debug.Log("最終的爸爸是誰 : " + (hit.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.name));
        //        //Debug.Log("最終爸爸的位置 : " + (hit.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.position));
        //        //Debug.Log("最終爸爸的名子(下) : " + listHitCollisions[i].transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.name);
        //        //Debug.Log(hit.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.position);
        //        if (listHitCollisions[0].transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.position.z <= -200)
        //        {
        //            Debug.Log("(資料搬過去之前) listOpenHitCollisions.Count : " + listOpenHitCollisions.Count);
        //            Debug.Log("(資料搬過去之前) listHitCollisions.Count : " + listHitCollisions.Count);
        //            //Debug.Log("在-200以後的地方 ");
        //            listOpenHitCollisions.Add(listHitCollisions[i]);
        //            listHitCollisions.Remove(listHitCollisions[i]);
        //            Debug.Log("(資料搬過去以後) listOpenHitCollisions.Count : " + listOpenHitCollisions.Count);
        //            Debug.Log("(資料搬過去以後) listHitCollisions.Count : " + listHitCollisions.Count);
        //        }
        //    }
        //}

        //if (listHitCollisions.Count > 0)
        //{
        //    if (listHitCollisions[0].name == "GoldCoin" && listHitCollisions[0].transform.tag == "GoldCoin")
        //    {
        //        if (listHitCollisions[0].transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.position.z <= -200)
        //        {
        //            Debug.Log("(資料搬過去之前) listOpenHitCollisions.Count : " + listOpenHitCollisions.Count);
        //            Debug.Log("(資料搬過去之前) listHitCollisions.Count : " + listHitCollisions.Count);
        //            //Debug.Log("在-200以後的地方 ");
        //            listOpenHitCollisions.Add(listHitCollisions[0]);
        //            listHitCollisions.RemoveAt(0);
        //            Debug.Log("(資料搬過去以後) listOpenHitCollisions.Count : " + listOpenHitCollisions.Count);
        //            Debug.Log("(資料搬過去以後) listHitCollisions.Count : " + listHitCollisions.Count);
        //        }
        //    }
        //}


        //indexHit = 0;
    }

    /// <summary>
    /// 開啟Collision
    /// </summary>
    public void OpenCollisions()
    {
        //foreach (GameObject hit in listOpenHitCollisions)
        //{
        //    if (hit.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.position.z <= -200)
        //    {
        //        //hit.transform.gameObject.SetActive(true);
        //        //listOpenHitCollisions.Remove(hit.gameObject);
        //        indexOepn++;
        //    }

        //}

        //for (int i = 0; i < indexOepn; i++)
        //{
        //    if (listOpenHitCollisions[i].transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.position.z <= -200)
        //    {
        //        Debug.Log("listOpenHitCollisions.Count " + listOpenHitCollisions.Count);
        //        listOpenHitCollisions[i].SetActive(true);
        //        listOpenHitCollisions.Remove(listOpenHitCollisions[i]);
        //    }
        //}

        //if (listOpenHitCollisions.Count > 0)
        //{
        //    if (listOpenHitCollisions[0].transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.position.z <= -200)
        //    {
        //        Debug.Log("listOpenHitCollisions.Count " + listOpenHitCollisions.Count);
        //        listOpenHitCollisions[0].SetActive(true);
        //        listOpenHitCollisions.RemoveAt(0);
        //    }
        //}

        //indexOepn = 0;
    }

    #endregion

    #region 分數相關
    /// <summary>
    /// 分數初始化
    /// </summary>
    public void ScoreInit()
    {
        score = 0;
    }    

    /// <summary>
    /// 獲得分數
    /// </summary>
    public void GetScore()
    {
        score = score + 5;
    }

    /// <summary>
    /// 顯示分數
    /// </summary>
    public void ShowScore()
    {
        txt_ScoreNumber.text = score.ToString();
    }

    /// <summary>
    /// 觸碰金幣次數初始化
    /// </summary>
    public void TouchGoldCoinTimesInit()
    {
        touchGoldCoinTimes = 0;
    }
    

    /// <summary>
    /// 增加觸碰金幣次數
    /// </summary>
    public void AddTouchGoldCoinTimes()
    {
        touchGoldCoinTimes++;
    }

    /// <summary>
    /// 顯示金幣數量
    /// </summary>
    public void ShowGoldCoinNumber()
    {
        txt_GoldCoinNumber.text = touchGoldCoinTimes.ToString();
    }

    #endregion

    #region 遊戲結束相關
    /// <summary>
    /// 失誤時間初始化
    /// </summary>
    public void MissTimeInit()
    {
        missTime = 0;
    }

    /// <summary>
    /// 計算失誤時間
    /// </summary>
    public void CountMissTime()
    {
        countMissTime = true;
    }

    /// <summary>
    /// 增加失誤時間
    /// </summary>
    public void AddMissTime()
    {
        if (countMissTime)
        {
            missTime += Time.deltaTime;
        }        
    }

    /// <summary>
    /// 遊戲結束
    /// </summary>
    public void GameOver()
    {
        if (missTime >= 1.25f)
        {
            txt_PanelScoreNumber.text = txt_ScoreNumber.text;
            txt_PanelGoldCoinNumber.text = txt_GoldCoinNumber.text;
            countMissTime = false;           
            panel_GameOver.SetActive(true);
            missTime = 0;
        }
    }


    public void GameOverInit()
    {
        panel_GameOver.SetActive(false);
    }

    /// <summary>
    /// 回到主畫面
    /// </summary>
    public void GoHome()
    {
        btn_GoHome.onClick.AddListener(delegate () {
            missTime = 0;
            panel_GameOver.SetActive(false);
            SceneManager.LoadScene("Home");
        });
    }
    #endregion

    #region 新手教學
    /// <summary>
    /// 教學
    /// </summary>
    public void Teaching()
    {
        obj_Teaching.SetActive(true);
    }


    IEnumerator CoDirectionLeftOpen(Collision hit)
    {
        hit.gameObject.SetActive(false);
        obj_panelTeachingLeft.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            img_DirectionLeft[i].transform.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.08f);
        }
        StartCoroutine(CoDirectionLeftClose());
    }


    IEnumerator CoDirectionLeftClose()
    {               
        for (int i = 0; i < 10; i++)
        {
            img_DirectionLeft[i].transform.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.08f);
        }
        obj_panelTeachingLeft.SetActive(false);
    }

    IEnumerator CoDirectionRightOpen(Collision hit)
    {
        hit.gameObject.SetActive(false);
        obj_panelTeachingRight.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            img_DirectionRight[i].transform.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.08f);
        }
        StartCoroutine(CoDirectionRightClose());
    }

    IEnumerator CoDirectionRightClose()
    {
        for (int i = 0; i < 10; i++)
        {
            img_DirectionRight[i].transform.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.08f);
        }
        obj_panelTeachingRight.SetActive(false);
    }


    #endregion
    /// <summary>
    /// 碼表計時
    /// </summary>
    void StopwatchTiming()
    {
        StopwatchTime += Time.deltaTime;
        Debug.Log("StopwatchTime : " + StopwatchTime);
    }

    /// <summary>
    /// 碼表初始化
    /// </summary>
    void StopWatchInit()
    {
        StopwatchTime = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        StopWatchInit();
    }

    // Update is called once per frame
    void Update()
    {
        //RunningDetection();
        //ControlMoveRange();
    }

    private void Awake()
    {
        inst = this;
    }
}
