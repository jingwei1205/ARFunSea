using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initializeTheFish : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fish;
    public GameObject fishParent;
    void Start()
    {
        GameObject fishInitialization= Instantiate(fish,new Vector3(0,0,3), Quaternion.identity);//实例化物体
        fishInitialization.transform.parent = fishParent.transform;//把实例化的物体放到父物体之下
    }

    // Update is called once per frame
    void Update()
    {

    }
}
