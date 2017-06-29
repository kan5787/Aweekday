using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject Sheep;
    public float spawnTime = 5f;//两个敌人出现的时间差
    public float spawnDelay = 1f;//游戏开始后敌人出现的时间差

    // Use this for initialization
    void Start () {
        //游戏开始延迟后依照时间差调用Spawn功能。
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Spawn()
    {
        //实例化一个随机的敌人
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0,
                                        Random.Range(0, 360)));//在z轴方向旋转0-360任意角度
        Instantiate(Sheep, transform.position, rotation);//克隆爆炸对象
        
    }
}
