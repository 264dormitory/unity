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
    public float disappearTime = 2;            //默认武器出现后的消失时间是2秒

    public virtual void Attack() { }           //攻击
    public virtual void Attack(Transform transform) { }           //带有位置的攻击

    public virtual void GenerateSelf(GameObject @object, Transform tran)           //生成一个武器
    {
        disappearTime = 10;                    //怪物掉落后的武器默认是10秒后消失
        //初始化一个武器 并取消物体的重力设置
        Instantiate(@object, new Vector3(tran.position.x, tran.position.y + 2, tran.position.z), Quaternion.identity).GetComponent<Rigidbody>().useGravity = false;
    }      
}
