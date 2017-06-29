using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getBlood : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
    }

    //private void OnMouseOver()
    //{//拾取
    //    if (Input.GetButtonDown("Fire2"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.gameObject.GetComponent<playerhealth>().addhealth();
            Destroy(gameObject);
        }
    }
}
