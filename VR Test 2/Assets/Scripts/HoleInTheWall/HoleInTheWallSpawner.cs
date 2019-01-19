using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleInTheWallSpawner : MonoBehaviour {

    public GameObject[] holeInTheWallPrefabs;
    public float holeSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnHole()
    {
        GameObject currentHole = holeInTheWallPrefabs[Random.Range(0, holeInTheWallPrefabs.Length)];
        GameObject currentHoleInstance = Instantiate(currentHole, transform.position, currentHole.transform.rotation);
        currentHoleInstance.GetComponent<Rigidbody>().AddForce(transform.forward * holeSpeed, ForceMode.Impulse);
    }
}
