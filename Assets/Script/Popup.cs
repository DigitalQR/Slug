using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Popup{

    public string message;
    public float duration;
    public Sprite image;

    public Popup(Sprite image, string message, float duration)
    {
        this.image = image;
        this.message = message;
        this.duration = duration;
        PopupManager.AddToQueue(this);
    }
}
