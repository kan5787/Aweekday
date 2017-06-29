using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passing : MonoBehaviour {
    public UITweener passanim;
    private BoxCollider2D pass;
	// Use this for initialization
	void Start () {
        pass = gameObject.GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            passanim.PlayForward();
            pass.isTrigger = true;
        }

    }
}
