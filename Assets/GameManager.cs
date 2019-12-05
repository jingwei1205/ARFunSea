using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TweenAlpha label;//标签
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ChaseTheEND.exit)
        {
            label.gameObject.SetActive(false);
        }
    }
}
