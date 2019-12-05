using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtEachOther : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform middle;
    //public float rotationSpeed = 0.1f;
    void Start()
    {
        middle = GameObject.FindGameObjectWithTag("middle").transform;   
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(middle);
        //Vector3 rotateVector = middle.position - this.transform.position;
        //Quaternion newRotation = Quaternion.LookRotation(rotateVector);
        //this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
    }
}
