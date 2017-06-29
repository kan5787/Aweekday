using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtle : MonoBehaviour
{
    public float moveSpeed = 2f;//速度
    public int HP = 2;//血量
    public float deathSpinMin = -100f;//旋转的最小角度
    public float deathSpinMax = 100f;//旋转的最大角度
    public GameObject badd;

    private Transform frontCheck;//frontCheck的位置
    private Rigidbody2D enemyBody;//enemy的rigidbody2d
    private void Awake()
    {
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "imitate")
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        enemyBody.velocity = new Vector2(transform.localScale.x * moveSpeed,
            enemyBody.velocity.y);//设置enemy在x方向上的速度

        if (HP == 0)
        {
            Instantiate(badd, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
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