using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeScript : MonoBehaviour
{
    public Button btn_StartGame;
    public Button btn_LeaveGame;
    public GameObject obj_PanelLeave;
    public Button btn_ExitGame;
    public Button btn_ContinueGame;

    /// <summary>
    /// 是否開始遊戲
    /// </summary>
    void WhetherStartGame()
    {
        btn_StartGame.onClick.AddListener(delegate () {
            SceneManager.LoadScene("Game");
        });
    }


    void WhetherLeaveGame()
    {
        btn_LeaveGame.onClick.AddListener(delegate () {
            obj_PanelLeave.SetActive(true);
        });
    }


    void LeaveGame()
    {
        btn_ExitGame.onClick.AddListener(delegate () {
            Application.Quit();
        });
    }


    void ContinueGame()
    {
        btn_ContinueGame.onClick.AddListener(delegate () {
            obj_PanelLeave.SetActive(false);
        });
    }

    /// <summary>
    /// 初始化
    /// </summary>
    void init()
    {
        obj_PanelLeave.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        WhetherStartGame();
        WhetherLeaveGame();
        ContinueGame();
        LeaveGame();
        init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
