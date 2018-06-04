using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Arms {
    public LayerMask layerMask;                        //并不知道用来干什么的
    public new string name = "斧子";                   //武器名称

    public override void Attack(Transform startposition)
    {
        
        GameObject axe = Instantiate(gameObject, new Vector3(startposition.position.x, startposition.position.y + 2, startposition.position.z), Quaternion.identity);
        Rigidbody rigidbody = axe.GetComponent<Rigidbody>();

        rigidbody.AddForce(startposition.forward * sendPower);
    }

    private void OnTriggerEnter(Collider collider)      //发生碰撞的事件
    {
        var target = collider.GetComponent<Monster>();

        if (target)
            target.TakeDamage(damageValue);             //如果打中怪物

        Destroy(gameObject);                            //碰撞完成之后清楚自身
    }
}
