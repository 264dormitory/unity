using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 武器类
 * */
public abstract class Arms : MonoBehaviour {
    public float damageValue;                  //武器的伤害值
    public float damageRange;                  //武器的攻击范围
    public float sendPower;                    //武器发射多远
    public AudioSource audioSource;            //武器的攻击音效

    /**
     * 武器攻击
     * */
    public virtual void Attck()
    {

    }
}
