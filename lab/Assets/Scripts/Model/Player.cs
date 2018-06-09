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
        var pickArmClassName = @object.GetComponent<Arms>().GetType().Name;       //获取碰撞到类的武器

        foreach (GameObject gameObject in arms)
            if (gameObject.GetComponent<Arms>().GetType().Name.Equals(pickArmClassName))
                currnetArm = gameObject;
    }

    /**
     * 玩家检测碰撞
     * */
    private void OnTriggerEnter(Collider collider)      //发生碰撞的事件
    {
        Debug.Log("Player: 玩家检测到碰撞");

        var target = collider.gameObject.GetComponent<Arms>();

        if(target && target.GetType().Name == currnetArm.GetComponent<Arms>().GetType().Name)
            return;                                             //如果碰撞到的武器与原来武器相同则直接返回

        Debug.Log("Player: " + target.GetType().Name);

        if (target && target.GetType() != typeof(FireBall))     //碰撞到武器且不是火球
            ChangeArms(collider.gameObject);                    //玩家捡起武器 

        Destroy(collider.gameObject);
    }

    /**
     * 碰撞持续状态 每帧都会调用
     * */
    private void OnTriggerStay(Collider collider) { }

    /**
     * 碰撞结束状态
     * */
    private void OnTriggerExit(Collider collider)               
    {
    }
}
