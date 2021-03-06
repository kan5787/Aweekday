﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {
    [HideInInspector]//隐藏下面的属性
    public bool bFaceRight = true;
    [HideInInspector]//隐藏下面的属性
    public bool beJump = false;

    public float maxSpeed = 6;
    public float maxForce = 300;//设置添加的刚体力的大小
    public float JumpForce = 400;
    public int moneyCount = 0;
    public UITextList money;
    public Rigidbody2D herobody;

    private Transform mGroundCheck;
    private bool bGrounded = false;
    private Animator anim;

    // Use this for initialization
    private void Awake()
    {
        mGroundCheck = transform.Find("GroundCheck");
        anim = transform.root.gameObject.GetComponent<Animator>();
    }

    void Start () {
        money.Add("0");
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");//获取玩家水平输入
        herobody = gameObject.GetComponent<Rigidbody2D>();

        anim.SetFloat("Speed", Mathf.Abs(h));//获得速度大小的绝对值

        if (h * herobody.velocity.x < maxSpeed)//小于最大速度时
            herobody.AddForce(Vector2.right * h * maxForce);
        if (Mathf.Abs(herobody.velocity.x) > maxSpeed)//绝对值与之比较
            herobody.velocity = new Vector2(Mathf.Sign(herobody.velocity.x) * maxSpeed,
                herobody.velocity.y);//Math.Sign返回正负

        //判断是否转身
        if (h > 0 && !bFaceRight)
            flip();
        else if (h < 0 && bFaceRight)
            flip();

        //输入w键并且主角在地面上时跳起
        if (beJump)
        {
            anim.SetTrigger("Jump");//判断为Jump时切换动画
            herobody.AddForce(Vector2.up * JumpForce);
        }

        Debug.Log(h);
    }

    // Update is called once per frame
    void Update () {
        int nlayer = LayerMask.NameToLayer("ground");//将地面都分在一个ground Layer里面
        bGrounded = Physics2D.Linecast(transform.position,
            mGroundCheck.position, 1 << nlayer);
        Debug.Log("Layer" + nlayer);

        beJump = Input.GetKeyDown(KeyCode.UpArrow) && bGrounded;

    }

    void flip()
    {//角色转身
        bFaceRight = !bFaceRight;
        Vector3 localscale = transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale;
    }

    public void mcount()
    {//增加钱币
        moneyCount++;
        string mC = moneyCount.ToString();
        money.Add(mC);
    }

}
