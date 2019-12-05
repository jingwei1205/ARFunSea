using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTheEND : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool exit=false;
    private Transform Target;
    public float MoveSpeed = 0.1f;
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("end").transform;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = new Vector3(
Mathf.Lerp(transform.position.x, Target.position.x, MoveSpeed * Time.deltaTime),
Mathf.Lerp(transform.position.y, Target.position.y, MoveSpeed * Time.deltaTime),
Mathf.Lerp(transform.position.z, Target.position.z, MoveSpeed * Time.deltaTime));
        if (Vector3.Distance(this.transform.position, Target.transform.position) < 3.5f)
        {
            exit = true;
        }
        else
        {
            exit = false;
        }
    }
}
