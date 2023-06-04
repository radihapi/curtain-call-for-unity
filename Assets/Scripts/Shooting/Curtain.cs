using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curtain : MonoBehaviour
{  
    List<LinkedList<MonoBehaviour>> CurtainsList = new List<LinkedList<MonoBehaviour>>();
    long bulletNumber = 4444; // 弾同士が相互作用する場合は動的に制限できるようにした方が良いかも
    // インターフェースのリストは怪しい為避ける、結果Bulletを多機能なクラスにしてPartialで実装
    public LinkedList<Bullet> reserveList, activeList;

    void Start()
    {
        Call();
    }

    void Update()
    {
        LinkedListNode<Bullet> node = activeList.First;
        LinkedListNode<Bullet> prevNode = null;
        int index = 0;
        while (node != null){
            Bullet bl = node.Value;
            bl.Observe(index);
            prevNode = node;
            node = node.Next;
            index++;
        }
    }

    // initialize
    void Call()
    {
    
        reserveList = new LinkedList<Bullet>();
        activeList = new LinkedList<Bullet>();

        // CurtainsList.Add(activeList);
        GameObject pr = Resources.Load<GameObject>("BulletBlueBig");

        for(long i = 0; i < bulletNumber;i++){
            GameObject obj = Object.Instantiate(pr);
            obj.SetActive(false);
            Bullet bl = obj.GetComponent<Bullet>();
            reserveList.AddLast(bl);
        }
    }

    // make bullet
    void Cast() // (GameObject go, long bulletNumber)
    {

    }

    // vanish bullets
    void Exeunt()
    {

    }
}
