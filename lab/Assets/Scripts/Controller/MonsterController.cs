using UnityEngine;
using UnityEngine.AI;

public class MonsterController : AIController {
    public static MonsterController monsterController;      //单例
    public GameObject monster;                              //怪物
    public Transform playerTransform;                       //玩家的位置

    void Awake()
    {
        monsterController = this;
    }

	void Start () {
        agent = GetComponent<NavMeshAgent>();        //获取代理

    }

    void Update ()
    {
        AutoGenerateMonster();                      //自动生成
    }
    
    public override void GenerateMonster()      //实现钩子操作
    {
        Debug.Log("MonsterControllel: generate");
        Monster monsterShell = monster.GetComponent<Monster>();
        monsterShell.GenerateSlef();
    }
}
