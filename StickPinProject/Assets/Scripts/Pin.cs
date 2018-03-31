using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float speed = 5;

    private bool isFly = false;
    private bool isReach = false;
    private Transform startPoint;
    private Transform circle;

    private Vector3 targetCirclePos;

	// Use this for initialization
	void Start () {
        startPoint = GameObject.Find("StartPoint").transform;
        circle = GameObject.Find("Circle").transform;
        targetCirclePos = circle.position;
        targetCirclePos.y -= 1.45f;
	}
	
	// Update is called once per frame
	void Update () {
        if (isFly == false)//not reach circle
        {
            if (isReach == false)//not reach startPoint
            {
                transform.position = Vector3.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, startPoint.position) < 0.05f)
                {
                    isReach = true;
                }
            }
           //if reach startPoint ,nothing to do 
        }
        else//reach circle
        {
            transform.position = Vector3.MoveTowards(transform.position, targetCirclePos, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetCirclePos) < 0.05f)
            {
                transform.position = targetCirclePos;
                transform.parent = circle;
                isFly = false;
            }
        }
	}

    public void StartFly()
    {
        isFly = true;
        isReach = true;
    }
}
