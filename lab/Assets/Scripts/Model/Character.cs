using System.Collections.Generic;
using UnityEngine;

/**
 * 抽象类 
 * 人物类 定义了人物的基本行为
 * */
public abstract class Character : MonoBehaviour {
    public const float MAX_BLOOD = 100;                  //人物的最大血量
    public float blood;                                  //人物的血量
    public float speed;                                  //人物移动的速度
    public float angularVelocity;                        //角速度
    public CharacterController characterController;      //人物的控制
    public AudioSource DeathAudioSource;                 //人物自己的声音特效
    public GameObject currnetArm;                        //当前的武器
    public List<GameObject> arms;                        //人物的武器 1: n的关系

    public void Start()
    {
        characterController = GetComponent<CharacterController>();
        blood               = MAX_BLOOD;                  //人物的血量初始化满值
    }

    /**
     * 移动
     * Verctor3 移动的方向
     * */
    public virtual void Move(Vector3 v)     
    {

        if (v.z < 0)
            transform.position -= transform.forward * speed * Time.deltaTime;
        else
            // characterController.SimpleMove(movement);
            transform.position += transform.forward * speed * Time.deltaTime;
    }

    /**
     * 人物死亡
     * */
    public virtual void Death()
    {
        Destroy(gameObject);                            //毁掉对象自己
    }

    /**
     * 人物攻击
     * */
    public virtual void Attack(Transform transform)
    {
        if (currnetArm != null)
        {
            Arms arm = currnetArm.GetComponent<Arms>();    //获取当前武器上的component
            arm.Attack(transform);                         //调用component中的攻击方法
        }
    }

    /**
     * 人物旋转
     * params 人物旋转的方向
     * */
    public virtual void Rotate(Vector3 lookDir)
    {
        transform.forward = Vector3.Lerp(transform.forward, lookDir, 2 * Time.deltaTime);
    }   

    /**
     * 任务承受伤害
     * param amount 伤害值
     * */
    public virtual void TakeDamage(float amount)
    {
        Debug.Log("人物: 血量减少" + amount);
        this.blood -= amount;

        if (blood <= 0)
        {
            AfterDeathOperate();                    //死亡后的操作
            Destroy(gameObject);                    //人物死亡
        }
            

        Debug.Log("人物具体血量: " + blood);
    }

    /**
     * 给用户预留死亡后剩余操作的钩子
     * */
    public virtual void AfterDeathOperate()
    {

    }

}
