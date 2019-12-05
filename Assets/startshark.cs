using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startshark : MonoBehaviour
{
    public Animator shark;
    public float m_speed = 2f;
    public float eatDistance = 2f;
    private int count = 0;


    // Use this for initialization
    void Start()
    {
        shark = this.GetComponent<Animator>();
    }
    private void Update()
    {
        count++;
        if (count == 100)
        {
            count = 99;
            shark.SetBool("bite", true);
        }
    }
}