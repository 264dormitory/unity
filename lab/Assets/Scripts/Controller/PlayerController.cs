using UnityEngine;

public class PlayerController : MonoBehaviour {
    Player player;                                  //玩家

	void Start () {
        player = GetComponent<Player>();            //获取玩家对象
	}
	
	void Update () {
        //获取用户输入的攻击
		if(Input.GetButtonDown("Fire1"))            //获取用户攻击输入
        {
            player.Attack();                        //调用玩家个攻击   
        }

        //获取用户输入的移动
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        player.Move(new Vector3(h, 0, v));          //不会有y轴的移动
       

        //获取用户输入的转向
        var lookDir = Vector3.forward * v + Vector3.right * h;      //获取用户输入的方向
        if (lookDir.magnitude != 0)                  //如果有方向的输入且有模值
            player.Rotate(lookDir);
    }
}
