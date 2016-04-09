using UnityEngine;
using System.Collections;

public class SpawnOnCreate : MonoBehaviour {

    public GameObject spawnObject;
    public GameObject createdObject;

	// Use this for initialization
	void Awake () {
        createdObject = Instantiate(spawnObject, transform.position,Quaternion.identity)as GameObject;
	
	}
}
