using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Arms {
    public new string name = "手枪";                  //武器名字
    public GameObject bullet;                         //子弹

    void Start()
    {
        Destroy(gameObject, disappearTime);
    }

    public override void Attack(Transform startposition)
    {
        var posion = startposition.forward;
        var bul = Instantiate(bullet, new Vector3(startposition.position.x, startposition.position.y + 1,
                                                    startposition.position.z), 
                                                    Quaternion.identity);

        bul.GetComponent<Bullet>().damageValue = damageValue;           //设置子弹的伤害值
        Rigidbody rigidbody = bul.GetComponent<Rigidbody>();

        rigidbody.AddForce(startposition.forward * sendPower);
    }
}
