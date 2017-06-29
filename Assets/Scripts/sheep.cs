using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheep : MonoBehaviour {
    public int HP = 1;//血量
    public Sprite deadEnemy;
    public float deathSpinMin = -100f;//旋转的最小角度
    public float deathSpinMax = 100f;//旋转的最大角度

    private SpriteRenderer ren;//body的renderer
    private Rigidbody2D enemyBody;//当前敌人的rigidbody2d

    // Use this for initialization
    private void Awake()
    {
        ren = transform.Find("body").GetComponent<SpriteRenderer>();//获取body的坐标
        enemyBody = GetComponent<Rigidbody2D>();

    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

	}
    private void FixedUpdate()
    {
        if (HP == 0)
        {
            Death();//执行死亡行为
        }

    }
    void Death()
    {
        ren.sprite = deadEnemy;//更换死亡enemy
        enemyBody.freezeRotation = false;//设置为可以旋转
        enemyBody.AddTorque(Random.Range(deathSpinMin, deathSpinMax));//随机旋转一个角度
        Collider2D[] cols = GetComponents<Collider2D>();
        foreach (Collider2D c in cols)
        {
            c.isTrigger = true;
        }
    }

    public void Hurt()
    {
        HP--;
    }


}
