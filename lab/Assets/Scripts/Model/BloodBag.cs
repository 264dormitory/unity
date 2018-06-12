using UnityEngine;

public class BloodBag : MonoBehaviour {
    public float bloodBagValue = 10;                    //血包的容量

    void Start()
    {
        Destroy(gameObject, (float)DisappearTime.bloodBagDisappearTime);
    }

    private void OnTriggerEnter(Collider collider)      //发生碰撞的事件
    {
        Debug.Log("检测到碰撞");
        var target = collider.GetComponent<Player>();

        if (target)
        {
            target.PickBloodBag(bloodBagValue);
            Destroy(gameObject);                        //销毁自己
        }
            
    }
}
