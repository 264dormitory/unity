using UnityEngine;

public class Bullet : MonoBehaviour {                             //这样是不对的 没有继承关系，应该是聚合关系
    public float damageValue = 0;

    void Start()
    {
        Destroy(gameObject, 1);                                //两秒后自动销毁子弹自己
    }


    private void OnTriggerEnter(Collider collider)      //发生碰撞的事件
    {
        Debug.Log("子弹检测到碰撞");
        var target = collider.GetComponent<Monster>();

        if (target)                 
            target.TakeDamage(damageValue);             //如果打中怪物

        if (collider.GetComponent<Player>()) { 
            Debug.Log("子弹碰撞到人物");
            return;
        }

        Destroy(gameObject);                            //碰撞完成之后清楚自身
    }
}
