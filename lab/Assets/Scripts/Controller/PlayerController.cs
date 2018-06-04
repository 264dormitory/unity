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
            player.Attack(player.transform);        //调用玩家个攻击
        }

        //获取用户输入的移动
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        if (v != 0f)
            player.Move(new Vector3(h, 0, v));          //不会有y轴的移动
    
        if (Input.GetKey(KeyCode.A))                    //旋转
            transform.Rotate(Vector3.up * Time.deltaTime * - player.angularVelocity);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * Time.deltaTime * player.angularVelocity);

    }
}
