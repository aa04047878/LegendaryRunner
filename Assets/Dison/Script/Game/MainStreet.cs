using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStreet : MonoBehaviour
{
    public List<Street> list_Streets;

    public float mainstreetPosZ;
    public GameScript gameScript;
    /// <summary>
    /// 控制街道重製
    /// </summary>
    public void ControlStreetRemake()
    {
        foreach(Street item in list_Streets)
        {
            item.StreetRemake();
        }
        
    }


    /// <summary>
    /// 參數初始化
    /// </summary>
    public void parameterInit()
    {
        mainstreetPosZ = -100f;
    }

    /// <summary>
    /// 等街道一下
    /// </summary>
    public void WaitStreet()
    {
        foreach (Street item in list_Streets)
        {
            if(item.whetherteleport == true)
            {
                gameScript.mainstreetmove = false;
                mainstreetPosZ = mainstreetPosZ - 100f;
                transform.position = new Vector3(transform.position.x, transform.position.y, mainstreetPosZ);
                item.whetherteleport = false;
                item.streetteleport = true;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("list_Streets[1].transform.position : " + list_Streets[1].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
