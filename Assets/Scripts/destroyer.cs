using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void DestroyGameObject()
    {
        Destroy(gameObject);//0.5秒后销毁物体
    }

}
