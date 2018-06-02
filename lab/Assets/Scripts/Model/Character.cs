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
    public CharacterController characterController;      //人物的控制
    public List<Arms> arms;                              //人物的武器 1: n的关系

    public void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    /**
     * 移动
     * Verctor3 移动的方向
     * */
    public virtual void Move(Vector3 v)     
    {
        Vector3 movement = v * speed;

        characterController.SimpleMove(movement);
    }

    /**
     * 人物死亡
     * */
    public virtual void Death()
    {

    }

    /**
     * 人物攻击
     * */
    public virtual void Attack()
    {

    }

    /**
     * 人物旋转
     * params 人物旋转的方向
     * */
    public virtual void Rotate(Vector3 lookDir)
    {

    }

    /**
     * 人物承受伤害
     * params amount 伤害值
     * */
    public virtual void TakeDamage(float amount)
    {

    }
}
