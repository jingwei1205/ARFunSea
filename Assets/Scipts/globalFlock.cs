﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalFlock : MonoBehaviour
{

    public GameObject fishPrefab;
    public static int tankSize =5; //这个参数很重要，控制鱼群范围
    static int numFish = 1; //控制鱼群数量
    public static GameObject[] allFish = new GameObject[numFish];
    public static Vector3 goalPos = Vector3.zero;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
            Vector3 pos = new Vector3(Random.Range(-tankSize, tankSize), //这个参数很重要，控制不同鱼群不同的初始位置
                                            Random.Range(-tankSize, tankSize),
                         Random.Range(-tankSize, tankSize));
            allFish[0] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
        
        if (Random.Range(0, 10000) < 50)
        {
            goalPos = new Vector3(Random.Range(-tankSize, tankSize),
                      Random.Range(-tankSize, tankSize),
                      Random.Range(-tankSize, tankSize));

        }

    }
}
