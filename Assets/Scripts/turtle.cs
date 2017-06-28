using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtle : MonoBehaviour
{
    public float moveSpeed = 2f;//速度
    public int HP = 2;//血量
    public Sprite deadEnemy;
    public Sprite damagedEnemy;
    public float deathSpinMin = -100f;//旋转的最小角度
    public float deathSpinMax = 100f;//旋转的最大角度

    private SpriteRenderer ren;//body的renderer
    private Transform frontCheck;//frontCheck的位置
    private bool dead = false;//enemy是否死亡
    private Rigidbody2D enemyBody;//enemy的rigidbody2d

    private void Awake()
    {
        ren = transform.Find("body").GetComponent<SpriteRenderer>();//获取body的坐标
        frontCheck = transform.Find("frontCheck").transform;//获取frontCheck的坐标
        enemyBody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position, 1);//建立一个数组存放enemy前的碰撞体
        foreach (Collider2D c in frontHits)//遍历碰撞到的物体
        {
            if (c.tag == "imitate")//如果碰到Tower
            {
                Flip();//反向
                break;
            }
        }

        enemyBody.velocity = new Vector2(transform.localScale.x * moveSpeed,
            enemyBody.velocity.y);//设置enemy在x方向上的速度

        if ((HP == 1) && (damagedEnemy != null))
        {
            ren.sprite = damagedEnemy;//更换为半残的enemy
        }
        if (HP == 0 && !dead)
        {
            Death();//执行死亡行为
        }

    }
    void Death()
    {
        ren.sprite = deadEnemy;//更换死亡enemy
        dead = true;//死亡状态设为TRUE
        enemyBody.freezeRotation = false;//设置为可以旋转
        enemyBody.AddTorque(Random.Range(deathSpinMin, deathSpinMax));//随机旋转一个角度

        //遍历碰撞体到数组并将所有的碰撞体都设为trigger,使enemy直接下落
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

    public void Flip()
    {
        //将enemy坐标x*(-1)
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }

}