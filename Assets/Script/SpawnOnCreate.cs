using UnityEngine;
using System.Collections;

public class SpawnOnCreate : MonoBehaviour {

    public GameObject spawnObject;

	// Use this for initialization
	void Start () {
        Instantiate(spawnObject, transform.position,Quaternion.identity);
	
	}
	

}
