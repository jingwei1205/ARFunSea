using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changestatus : MonoBehaviour
{
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.touchCount == 1)
            {
                if (Input.touches[0].phase == TouchPhase.Began) {
                    if (text.activeSelf == true)
                    {
                        text.SetActive(false);
                    }
                    else
                    {   
                        text.SetActive(true);
                    }
                }
            }
        }
        
    }
}
