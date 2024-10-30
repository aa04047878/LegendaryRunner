using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]   //加上這句話後物件會變得很奇怪(有改Material的物件才會) >> 以Curvature的y來控制，0為看起來正常，正值物體會往下捲，負值會往上捲
public class CurvedWorld : MonoBehaviour
{
    public Vector3 Curvature = new Vector3(0, 0.0005f, 0);
    int CurvatureID;

    private void OnEnable()
    {
        CurvatureID = Shader.PropertyToID("_Curvature");
    }

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalVector(CurvatureID, Curvature);
    }
}
