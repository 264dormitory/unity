using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurController : AIController {
    public GameObject dinosaur;

    void Start()
    {
        rateTime = 3000;
    }

    void Update()
    {
        // AutoGenerateMonster();                      //自动生成
    }

    public override void GenerateMonster()          //实现钩子操作
    {
        if (Dinosaur.dinosaurCount <= 3)
        {
            Debug.Log("DinosaurController: generate");
            Dinosaur dinosaurShell = dinosaur.GetComponent<Dinosaur>();
            dinosaurShell.GenerateSlef();

            Dinosaur.dinosaurCount++;                //恐龙的数量 +1
        }
    }
}
