using UnityEngine;

/**
 * 武器类
 * */
public abstract class Arms : MonoBehaviour {
    public float damageValue;                  //武器的伤害值
    public float damageRange;                  //武器的攻击范围
    public float sendPower;                    //武器发射的力
    public AudioSource audioSource;            //武器的攻击音效
    public Transform muzzle;                   //位置


    public virtual void Attack() { }           //攻击
    public virtual void Attack(Transform transform) { }           //带有位置的攻击
}
