using UnityEngine;
using UnityEngine.AI;

public class Monster : Character {
    public Transform playerTransform;       //玩家的位置
    public float damageValue = 10;          //怪兽自身的伤害值
    public GameObject bloodBag;             //血包
    public static float monsterAcount = 0;

    new void Start()
    {
        base.Start();                   //调用父类的Start
        playerTransform = MonsterController.monsterController.playerTransform;
    }

    void Update()
    {
        Vector3 targetDir = playerTransform.position - transform.position;

        float step = angularVelocity * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void GenerateSlef()
    {
        Vector2 v = Random.insideUnitCircle.normalized * 10;            //在一定范围内随机生成一个二维向量
        if (playerTransform == null)
            playerTransform = MonsterController.monsterController.playerTransform;

        Instantiate(gameObject, playerTransform.position + new Vector3(v.x, 0, v.y), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));   //生成一个怪物对象
        monsterAcount++;                                                //怪物的数量+1
    }

    private void OnTriggerEnter(Collider collider)      //发生碰撞的事件
    {
        Debug.Log("检测到碰撞");
        var target = collider.GetComponent<Player>();

        if (target)
            target.TakeDamage(this.damageValue);
    }

    /**
     * 怪物掉落血包的行为
     * */
    private void FallDownBloodBag()
    {
        Instantiate(bloodBag, new Vector3(transform.position.x + 2, 0, transform.position.z), Quaternion.identity);      //生成一个血包
    }

    private void FallDownArm()
    {
        Debug.Log("掉落了  一个武器");
        //从怪物拥有的武器中随便掉落一个武器
        int num = Random.Range(0, arms.Count);

        Debug.Log("Monster: " + num);
        ///Instantiate( arms[num], new Vector3(transform.position.x + 2, 0, transform.position.z), Quaternion.identity);

        arms[num].GetComponent<Arms>().GenerateSelf(arms[num], transform);        //当前武器生成自己
    }

    /**
     * 实现父类预留的死后操作的钩子
     * */
    public override void AfterDeathOperate()
    {
        Debug.Log("怪物死亡后的操作");
        monsterAcount--;                                //怪物数量减少

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        float num = player.GetComponent<Player>().deathMonster++;  //人物杀死的怪物++

        if (num % 10 == 0)
            FallDownBloodBag();                         //掉落血包

        //if (num % 20 == 0)
            //FallDownArm();                              //掉落武器

        FallDownArm();
    }
}
