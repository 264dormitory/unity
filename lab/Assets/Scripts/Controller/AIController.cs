using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour {
    public float rateTime = 5;          //生成怪物的速率
    public float myTime;

    public NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();        //获取代理
    }

    /**
     * 定义自动生成怪物的算法模板 
     * TODO　代码需要重构 c层只负责转发数据　生成怪物的算法有多种　所有应该用策略
     * */
    public virtual void AutoGenerateMonster()
    {
        myTime += Time.deltaTime;

        if (myTime > rateTime)
        {
            GenerateMonster();
            myTime -= rateTime;
        }

        if (Monster.monsterAcount > 10)             //如果怪物的数量太多，减少速率
            rateTime = 10;
        else
            rateTime = 5;

        
    }

    public virtual void GenerateMonster() { }       //给子类留的钩子
}
