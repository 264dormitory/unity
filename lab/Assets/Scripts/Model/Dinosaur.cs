using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : Monster {
    public float distance = 100;                        //怪物与玩家之间的距离

    public float rateTime = 20;                         //生成怪物的速率
    public float myTime;

    public static float dinosaurCount = 0;              //恐龙的数量             

    new void Start()
    {
        base.Start();
    }

    void Update()
    {

        if (gameObject.GetComponent<Dinosaur>().BeyondDistance())
            Track();

        transform.LookAt(playerTransform);                               //TODO 大哥 朝向玩家

        myTime += Time.deltaTime;

        if (myTime > rateTime)
        {
            AutoAttack();
            myTime -= rateTime;
        }
    }

    public bool BeyondDistance()
    {
        Debug.Log("计算距离");
        float temp = (playerTransform.position - transform.position).magnitude;     //计算怪物与玩家的距离

        if (temp > distance)
            return true;

        return false;
    }

    public void AutoAttack()
    {
        base.Attack(transform);
    }

    public void Track()
    {
        Vector3 targetDir = playerTransform.position - transform.position;

        float step = angularVelocity * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }


    public override void AfterDeathOperate()
    {
        dinosaurCount--;
    }
}
