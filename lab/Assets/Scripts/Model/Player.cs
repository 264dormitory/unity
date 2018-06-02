using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
    public new void  Start()
    {
        base.Start();           //调用父类的Start()
        blood = MAX_BLOOD;      //人物的血量初始化满值
    }
}
