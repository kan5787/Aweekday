using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhealth : MonoBehaviour {
    public float health = 100f;
    public float repeatDamagePeriod = 2f;

    public float hurtForce = 10f;
    public float damageAmount = 10f;

    private SpriteRenderer healthBar;//用于血条变色
    private float lastHitTime;
    private Vector3 healthScale;//用于血条长度
    private playerControl playerControl;//用于获取相关持续时间


    private void Awake()
    {
        playerControl = GetComponent<playerControl>();
        healthBar = GameObject.Find("blood").GetComponent<SpriteRenderer>();
        healthScale = healthBar.transform.localScale;

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "sheep"|| (col.gameObject.tag == "turtle"))
        {
            if (Time.time > lastHitTime + repeatDamagePeriod)
            {
                //有血,则见血并设置当前时间为最后一次受伤时间
                if (health > 0)
                {
                    TakeDamage(col.transform);
                    lastHitTime = Time.time;
                }
                //无血
                else
                {
                    print("die");
                    //失败窗口（主界面，重新开始）
                }
            }
        }
    }

    void TakeDamage(Transform enemy)
    {
        playerControl.beJump = false;
        Vector3 hurtVector = transform.position + Vector3.up * 5f;//跳跃弹开
        GetComponent<Rigidbody2D>().AddForce(hurtVector * hurtForce);

        health -= damageAmount;
        UpdateHealthBar();
    }

    public void addhealth()
    {
        if (health < 100f)
        {
            health += 10f;
            if (health > 100f)
            {
                health = 100f;
            }
        }
        
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        //设置材质颜色
        healthBar.material.color = Color.Lerp(Color.green, Color.red, (100 - health) * 0.01f);
        //设置血条比例
        healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, healthScale.y, 1);
    }

    

}
