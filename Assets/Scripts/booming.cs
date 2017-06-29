using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booming : MonoBehaviour {

    public GameObject explosion;//调用boom对象

    // Use this for initialization
    void Start () {
        Destroy(gameObject, 2);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
     void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "sheep")//打到敌人
        {
            col.gameObject.GetComponent<sheep>().Hurt();//HP--
            OnExplode();
            Destroy(gameObject);
        }
        if (col.tag == "turtle")//打到敌人
        {
            col.gameObject.GetComponent<turtle>().Hurt();//HP--
            OnExplode();
            Destroy(gameObject);
        }

        if (col.tag != "Player")//防止打到自己
        {
            OnExplode();
            Destroy(gameObject);//销毁子弹对象
        }
    }
    void OnExplode()
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, 
                                        Random.Range(0, 360)));//在z轴方向旋转0-360任意角度
        Instantiate(explosion, transform.position, rotation);//克隆爆炸对象
    }

}
