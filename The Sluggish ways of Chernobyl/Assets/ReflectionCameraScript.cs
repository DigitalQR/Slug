using UnityEngine;
using System.Collections;

public class ReflectionCameraScript : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject waterBody;
    
	void Update () {
        float difference = waterBody.transform.position.y - mainCamera.transform.position.y;

        transform.position = mainCamera.transform.position + new Vector3(0, difference * 2, 0);

        transform.rotation = transform.rotation;
        transform.Rotate(new Vector3(-transform.rotation.x, 0,0));
    }
}
