using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreatePopup : MonoBehaviour {

    public string message;
    public int duration;
    public Sprite image;
    
    void Start () {
        new Popup(image, message, duration);
	}
	
}
