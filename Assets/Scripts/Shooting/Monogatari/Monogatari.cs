using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Everything is a story.
public class Monogatari : MonoBehaviour
{
    float shotWaitTime = 1f;
    Curtain curtain;

    // Start is called before the first frame update
    void Start()
    {
        curtain = GameObject.Find("Curtain").GetComponent<Curtain>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
