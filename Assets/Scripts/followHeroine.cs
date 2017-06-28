using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followHeroine : MonoBehaviour {
    public Vector3 offset;//为了调整血条相对主角的位置
    Transform herotran;//主角的位置

    // Use this for initialization
    void Start () {
        herotran = GameObject.Find("heroine").transform;//获得主角的位置
        Debug.Log(herotran.position);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = herotran.position + offset;//更新位置
    }
}
