using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //碰撞效果
    public GameObject HitPre;
    //爆炸效果
    public GameObject BombPre;
    //血量
    public int hp = 3;

    private Rigidbody rBody;


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //水平轴
        float horizontal = Input.GetAxis("Horizontal");
        //垂直轴
        float vertical = Input.GetAxis("Vertical");
        //方向
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        if(dir != Vector3.zero)
        {
            //移动
            rBody.velocity = dir * 2f;
        }
    }
    //碰到碰撞体调用
    private void OnCollisionEnter(Collision collision)
    {
        //如果碰到墙
        if (collision.collider.tag == "Wall")
        {
            hp--;
            if(hp <= 0)
            {
                AudioManager.Instance.PlayBomb();
                //死了
                Instantiate(BombPre, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                Instantiate(HitPre, collision.contacts[0].point, Quaternion.identity);
            }
        }
    }
}

