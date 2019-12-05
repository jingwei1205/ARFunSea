using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnim : MonoBehaviour
{
    public TweenAlpha label;//标签
    public GameObject fish;//prefab
    public GameObject myself;//imagement
    public GameObject end;
    GameObject newFish;
    private bool big = false;
    private bool small = false;
    private bool yes = false;
    private bool now=true;

    //private Animation fishAnimation;
    // Use this for initialization
    void Start()
    {
        //fishAnimation = fish.GetComponent<Animation>();
        newFish = GameObject.Instantiate(fish, this.transform.position, Quaternion.identity);
        newFish.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (yes&&now)
        {
            if (small)
            {
                newFish.transform.position = new Vector3(0, 0, 2);
            }
            if (big)
            {
                newFish.transform.position = new Vector3(-2, 0, 2);
            }
            newFish.transform.LookAt(end.transform);
            newFish.SetActive(true);
            now = false;
        }
        if (now==false)
        {
            if (Vector3.Distance(newFish.transform.position, end.transform.position) < 3.5f)
            {
                afterChasing();
            }
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (string.Compare(this.tag, col.tag) <0)
        {
            beginEffect();
            big = true;
            yes = true;
        }
        else if(string.Compare(this.tag,col.tag)>0)
        {
            beginEffect();
            small = true;
            yes = true;
        }
        else
        {
            yes = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        afterChasing();
    } 
    private void afterChasing()
    {
        myself.SetActive(true);
        yes = false;
        newFish.SetActive(false);
        now = true;
        label.gameObject.SetActive(false);
    }
    private void beginEffect()
    {
        label.gameObject.SetActive(true);
        myself.SetActive(false);
        label.PlayForward();
    }
}
