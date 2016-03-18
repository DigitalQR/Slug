using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreatePopup : MonoBehaviour {

    public string message;
    public float duration;
    public Sprite image;
    
    void Start () {
        new Popup(image, message, duration);
	}
	
}
