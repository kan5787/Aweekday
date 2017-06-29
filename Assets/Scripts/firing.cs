using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firing : MonoBehaviour
{
    public float speed = 20f;//手枪发射速度
    public Rigidbody2D bullet;//子弹对象
    private playerControl playertrl;//建立PlayerControl对象
    private Animator anim;

    private void Awake()
    {
        anim = transform.root.gameObject.GetComponent<Animator>();//获得更高层次的Animator对象
    }
    // Use this for initialization
    void Start()
    {
        playertrl = transform.parent.GetComponent<playerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("biu"))
        {
            anim.SetTrigger("biu");
            if (playertrl.bFaceRight)//如果角色向右
            {
                Rigidbody2D sheel = Instantiate(bullet, transform.position,
                    Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;//克隆子弹
                sheel.velocity = new Vector2(speed, 0);//设置子弹速度
            }
            else
            {
                Rigidbody2D sheel = Instantiate(bullet, transform.position,
                    Quaternion.Euler(new Vector3(0, 0, 180f))) as Rigidbody2D;
                sheel.velocity = new Vector2(-speed, 0);//180f子弹反向,-speed速度反向
            }
        }
    }

}

