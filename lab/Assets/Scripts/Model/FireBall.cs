using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Arms {
    public new string name = "火球";

    void Start()
    {
        Destroy(gameObject, 3);                         //3秒钟之后武器消失
    }

    public override void Attack(Transform startposition)
    {
        var bul = Instantiate(gameObject, new Vector3(startposition.position.x , startposition.position.y,
                                                    startposition.position.z),
                                                    Quaternion.identity);

        Rigidbody rigidbody = bul.GetComponent<Rigidbody>();
        rigidbody.AddForce(startposition.forward * sendPower);
    }


    private void OnTriggerEnter(Collider collider)      //发生碰撞的事件
    {
        var target = collider.GetComponent<Player>();

        if (target)
            target.TakeDamage(damageValue);             //如果打中玩家

        if (collider.GetComponent<Dinosaur>())
            return;                                     //如果碰到恐龙，直接返回

        Destroy(gameObject);                            //碰撞完成之后清楚自身
    }
}
