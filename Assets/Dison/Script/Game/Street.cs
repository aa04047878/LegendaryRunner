using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : MonoBehaviour
{
    /// <summary>
    /// 障礙物清單
    /// </summary>
    [Header("障礙物清單")]
    public List<GameObject> ListObstacle;

    /// <summary>
    /// 金幣地區清單
    /// </summary>
    [Header("金幣地區清單")]
    public List<GameObject> ListGoldCoinsArea;

    public MainStreet mainStreet;
    

    int obstaclerange01;
    /// <summary>
    /// 街道傳送
    /// </summary>
    public bool streetteleport;
    /// <summary>
    /// 是否傳送(參數)
    /// </summary>
    public bool whetherteleport;

    /// <summary>
    /// 是否傳送
    /// </summary>
    void whetherTeleport()
    {
        if (transform.position.z <= -200)
        {
            Debug.Log("<= -200了");
            whetherteleport = true;
        }
        if (whetherteleport)
        {
            MySapphiArtchanScript.inst.WhetherOpenCollisions();
            //MySapphiArtchanScript.inst.OpenCollisions();
        }
    }

    /// <summary>
    /// 街道傳送至前方
    /// </summary>
    public void StreetTeleportToTheFront()
    {       
        if (streetteleport)
        {                       
            transform.position = new Vector3(transform.position.x, transform.position.y, 300);
            Debug.Log("= 300");
            streetteleport = false;
            GameScript.inst.mainstreetmove = true;
        }
    }

    /// <summary>
    /// 改變障礙物內容
    /// </summary>
    public void ChangeObstacleContent()
    {
        ChangeObstacleContent_01();
        ChangeObstacleContent_02();
    }

    /// <summary>
    /// 改變障礙物內容_01
    /// </summary>
    public void ChangeObstacleContent_01()
    {
        if (transform.position.z <= -200)
        {
            obstaclerange01 = Random.Range(0, 10);
            ListObstacle[0].transform.GetChild(obstaclerange01).gameObject.SetActive(true);
        }        
    }

    /// <summary>
    /// 改變障礙物內容_02
    /// </summary>
    public void ChangeObstacleContent_02()
    {
        if (transform.position.z <= -200)
        {
            if (obstaclerange01 > 5)
            {
                return;
            }
            int obstaclerange02 = Random.Range(0, 6);
            ListObstacle[1].transform.GetChild(obstaclerange02).gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 關閉障礙物
    /// </summary>
    public void CloseObstacle()
    {
        CloseObstacle_01();
        CloseObstacle_02();
    }

    /// <summary>
    /// 關閉障礙物_01
    /// </summary>
    public void CloseObstacle_01()
    {
        if (transform.position.z <= -200)
        {
            for (int i = 0; i < 10; i++)
            {
                if (ListObstacle[0].transform.GetChild(i).gameObject.activeSelf == true)
                {
                    ListObstacle[0].transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }        
    }

    /// <summary>
    /// 關閉障礙物_02
    /// </summary>
    public void CloseObstacle_02()
    {
        if (transform.position.z <= -200)
        {
            for (int i = 0; i < 6; i++)
            {
                if (ListObstacle[1].transform.GetChild(i).gameObject.activeSelf == true)
                {
                    ListObstacle[1].transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }      
    }

    /// <summary>
    /// 關閉金幣地區
    /// </summary>
    void CloseGoldCoinsArea()
    {
        CloseGoldCoinsArea_01();
        CloseGoldCoinsArea_02();
    }

    /// <summary>
    /// 關閉金幣地區_01
    /// </summary>
    void CloseGoldCoinsArea_01()
    {
        if (transform.position.z <= -200)
        {
            for (int i = 0; i < 8; i++)
            {
                if (ListGoldCoinsArea[0].transform.GetChild(i).gameObject.activeSelf == true)
                {
                    ListGoldCoinsArea[0].transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }

    /// <summary>
    /// 關閉金幣地區_02
    /// </summary>
    void CloseGoldCoinsArea_02()
    {
        if (transform.position.z <= -200)
        {
            for (int i = 0; i < 8; i++)
            {
                if (ListGoldCoinsArea[1].transform.GetChild(i).gameObject.activeSelf == true)
                {
                    ListGoldCoinsArea[1].transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }

   
    /// <summary>
    /// 改變金幣地區內容
    /// </summary>
    void ChangeGoldCoinsAreaContent()
    {
        ChangeGoldCoinsArea_01();
        ChangeGoldCoinsArea_02();
    }

    /// <summary>
    /// 改變金幣地區_01
    /// </summary>
    void ChangeGoldCoinsArea_01()
    {
        if (transform.position.z <= -200)
        {
            if (obstaclerange01 > 5)
            {
                return;
            }
            int changeGoldCoinsType = Random.Range(0, 8);
            ListGoldCoinsArea[0].transform.GetChild(changeGoldCoinsType).gameObject.SetActive(true);
        }            
    }

    /// <summary>
    /// 改變金幣地區_02
    /// </summary>
    void ChangeGoldCoinsArea_02()
    {
        if (transform.position.z <= -200)
        {
            int changeGoldCoinsType = Random.Range(0, 8);
            ListGoldCoinsArea[1].transform.GetChild(changeGoldCoinsType).gameObject.SetActive(true);
        }         
    }

    /// <summary>
    /// 街道重製
    /// </summary>
    public void StreetRemake()
    {
        CloseObstacle();
        ChangeObstacleContent();
        CloseGoldCoinsArea();
        ChangeGoldCoinsAreaContent();       
        whetherTeleport();
        
        mainStreet.WaitStreet();
        StreetTeleportToTheFront();
    }    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
