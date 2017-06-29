using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgCompensation : MonoBehaviour {
    public Transform[] BkPos;//建立一个图像数组
    public float Factor = 0.5f;//缩放变量,摄像机的运动和背景运动的比例关系
    public float FrameFactor = 0.5f;
    private Vector3 PreCamPos;
    public Transform CamPos;
    public float smoothing = 8f;

    // Use this for initialization
    void Start () {
        CamPos = Camera.main.transform;//获取相机的坐标
        PreCamPos = CamPos.position;//初始化坐标
    }
	
	// Update is called once per frame
	void Update () {
        float xmove = (PreCamPos.x - CamPos.position.x) * Factor;

        //使不同图层补偿量不同
        for (int i = 0; i < BkPos.Length; i++)
        {
            float newx = BkPos[i].position.x - xmove * (1 + i * FrameFactor);//i越大移动速度越大 
            Vector3 backgroundTargetPos = new Vector3(newx, BkPos[i].position.y, BkPos[i].position.z);
            BkPos[i].position = Vector3.Lerp(BkPos[i].position, backgroundTargetPos, smoothing * Time.deltaTime);//平滑过渡

        }
        PreCamPos = CamPos.position;
    }

}
