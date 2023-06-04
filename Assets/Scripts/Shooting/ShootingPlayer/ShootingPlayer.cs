using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{
    const float FastSpeed = 4.0f;
    const float SlowSpeed = 1.5f;
    float speed;

    int BulletMax = 100;
    LinkedList<PlayerBulletMain> reserveList, activeList;
    float shotWaitTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        speed = FastSpeed;

        reserveList = new LinkedList<PlayerBulletMain>();
        activeList = new LinkedList<PlayerBulletMain>();

        GameObject pr;
        pr = Resources.Load<GameObject>("PlayerBulletSizukaMain");
        for(long i = 0; i < BulletMax;i++){
            GameObject obj = Object.Instantiate(pr);
            obj.SetActive(false);
            PlayerBulletMain bl = obj.GetComponent<PlayerBulletMain>();
            reserveList.AddLast(bl);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = WorldTime.fixedDeltaTime;

        // 上下左右操作
        if (Input.GetKey (KeyCode.UpArrow)) {
          transform.position += transform.up * speed * WorldTime.fixedDeltaTime;
        }
        if (Input.GetKey (KeyCode.DownArrow)) {
            transform.position -= transform.up * speed * WorldTime.fixedDeltaTime;
        }
        if (Input.GetKey (KeyCode.RightArrow)) {
            transform.position += transform.right * speed * WorldTime.fixedDeltaTime;
        }
        if (Input.GetKey (KeyCode.LeftArrow)) {
            transform.position -= transform.right * speed * WorldTime.fixedDeltaTime;
        }

        // 低速移動切り替え
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            speed = SlowSpeed;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            speed = FastSpeed;
        }

        // 弾丸
        if(Input.GetKeyDown (KeyCode.Z)){
            shotWaitTime = elapsedTime * 10;
        }

        if(Input.GetKey (KeyCode.Z)){
            shotWaitTime -= elapsedTime;
            if(shotWaitTime < 0f){
                for(int i = 0; i < 2; i++){
                    if(this.reserveList.Count == 0) break;

                    PlayerBulletMain bl = reserveList.First.Value;
                    activeList.AddLast(bl);
                    reserveList.RemoveFirst();

                    Vector3 pos = transform.position;
                    pos.x -= 0.2f;
                    pos.x += 0.4f * i;
                    pos.y += 0.4f;
                    Quaternion rot = Quaternion.identity;
                    bl.Shoot(pos,rot,2);
                }

                shotWaitTime += 3f / 60f;
            }
        }

        LinkedListNode<PlayerBulletMain> node = activeList.First;
        LinkedListNode<PlayerBulletMain> prevNode = null;
        int index = 0;
        while (node != null){
            PlayerBulletMain bl = node.Value;
            bool act = bl.Run(index, elapsedTime);
            prevNode = node;
            node = node.Next;
            if(!act){
                reserveList.AddLast(bl);
                activeList.Remove(prevNode);
                bl.Vanish();
            }
            index++;
        }
    }
}
