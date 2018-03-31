using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private Transform startPoint;
    private Transform spawnPoint;
    private Pin currentPin;

    public GameObject pinPrefab;


	// Use this for initialization
	void Start () {
        startPoint = GameObject.Find("StartPoint").transform;
        spawnPoint = GameObject.Find("SpawnPoint").transform;
        SpawnPin();
	}

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentPin.StartFly();
            SpawnPin();
        }
    }

    void SpawnPin()//instance a pin
    {
        currentPin=GameObject.Instantiate(pinPrefab, spawnPoint.position, pinPrefab.transform.rotation).GetComponent<Pin>();
    }
}
