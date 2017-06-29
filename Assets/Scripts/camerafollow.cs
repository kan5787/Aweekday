using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour {
    public float Xdistance = 1;//摄像机和角色的距离
    public float Ydistance = 1;
    public Vector2 XY_Max;
    public Vector2 XY_Min;
    public Transform heroPos;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float fnewX = transform.position.x;//获取相机的坐标
        float fnewY = transform.position.y;
        if (IsLargX())
            fnewX = Mathf.Lerp(transform.position.x, heroPos.position.x, Time.deltaTime);//相机位置跟随到角色位置

        if (IsLargY())
            fnewY = Mathf.Lerp(transform.position.y, heroPos.position.y, Time.deltaTime);

        fnewX = Mathf.Clamp(fnewX, XY_Min.x, XY_Max.x);//fnewX的值在Min和Max之间,小于Min返回Min,大于Max返回Max
        fnewY = Mathf.Clamp(fnewY, XY_Min.y, XY_Max.y);

        transform.position = new Vector3(fnewX, fnewY, transform.position.z);//更新相机位置

    }
    private bool IsLargX()
    {//判断在x轴方向上是否还需要跟随
        return (Mathf.Abs(heroPos.position.x - transform.position.x) > Xdistance);
    }
    private bool IsLargY()
    {
        return (Mathf.Abs(heroPos.position.y - transform.position.y) > Ydistance);
    }

}
