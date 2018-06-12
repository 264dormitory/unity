using System.Collections;
using UnityEngine;

public class Player : Character {
    public float deathMonster = 0;                  //人物打死的怪的总数

    public Hashtable hashArms = new Hashtable();    //设置玩家手拿着武器的hash表

    public new void  Start()
    {
        base.Start();                         //调用父类的Start()

        InitShowArms();                       //初始人物使用的武器

        setArmShow();                         //设置武器显示
    }

    /**
     * 获取任务应该有的所有武器
     * */
    private void InitShowArms()
    {
        foreach (GameObject game in arms)
            hashArms.Add(game.GetComponent<Arms>().GetType().Name, GameObject.FindGameObjectWithTag(game.GetComponent<Arms>().GetType().Name));
    }

    private void setArmShow()
    {
        foreach (GameObject game in arms) {
            string name = game.GetComponent<Arms>().GetType().Name;

            Debug.Log("Player: 显示--" + name);

            GameObject @object = (GameObject)hashArms[name];

            if (name.Equals(currnetArm.GetComponent<Arms>().GetType().Name))
                @object.SetActive(true);

            else
                @object.SetActive(false);
        }
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
        GameObject hideObject = (GameObject)hashArms[currnetArm.GetComponent<Arms>().GetType().Name];       //隐藏武器
        hideObject.SetActive(false);

        var pickArmClassName = @object.GetComponent<Arms>().GetType().Name;       //获取碰撞到类的武器

        foreach (GameObject gameObject in arms)
            if (gameObject.GetComponent<Arms>().GetType().Name.Equals(pickArmClassName))
                currnetArm = gameObject;

        GameObject showObject = (GameObject)hashArms[currnetArm.GetComponent<Arms>().GetType().Name];       //显示武器
        showObject.SetActive(true);
    }

    /**
     * 玩家检测碰撞
     * */
    private void OnTriggerEnter(Collider collider)      //发生碰撞的事件
    {
        var target = collider.gameObject.GetComponent<Arms>();

        if (!target)
            return;

        if(target.GetType().Name == currnetArm.GetComponent<Arms>().GetType().Name)
            return;                                             //如果碰撞到的武器与原来武器相同则直接返回

        if (target.GetType() != typeof(FireBall))               //碰撞到武器且不是火球
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
