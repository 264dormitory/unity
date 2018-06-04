using UnityEngine;

public class Player : Character {
    public float deathMonster = 0;            //人物打死的怪的总数

    public new void  Start()
    {
        base.Start();                         //调用父类的Start()
    }

    /**
     * 捡血包
     * */
    public void PickBloodBag(float bloodValue)
    {
        blood += bloodValue;
        Debug.Log("血量增加");
    }

    /**
     * 人物承受伤害
     * params amount 伤害值
     * */
    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
    }

    /**
     * 玩家换武器
     * 参数是对象的标签
     * */
    public void ChangeArms(GameObject @object)
    {
        Debug.Log("玩家捡到武器");

        currnetArm = @object;                           //赋值当前武器
    }

    /**
     * 玩家检测碰撞
     * */
    private void OnTriggerEnter(Collider collider)      //发生碰撞的事件
    {
        Debug.Log("玩家检测到碰撞");
        var target = collider.GetComponent<Arms>();

        if (target)
        {
            arms.Add(currnetArm);                      //将原来的武器存储起来
            ChangeArms(collider.gameObject);           //玩家捡起武器                                    
        }
    }
}
