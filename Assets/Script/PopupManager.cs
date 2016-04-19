using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PopupManager : MonoBehaviour {

    private static List<Popup> queue = new List<Popup>();

    public static void AddToQueue(Popup popup)
    {
        queue.Add(popup);
    }

    public GameObject popup;
    public Image image;
    public Text text;

    private bool active = false;
    private bool ready = false;
    private Vector3 on_location;
    private Vector3 off_location;

    public Transform Canvas;

    void Start()
    {
        
        on_location = popup.transform.position;
        off_location = on_location; // + new Vector3(0,0,0);
        popup.transform.position = off_location;
    }

    void FixedUpdate()
    {
        on_location.x = Canvas.position.x;
        on_location.z = Canvas.position.z;
        PopupAnimation();

        //Is the last popup finished?
        if (!active && !ready)
        {
            if((int)(popup.transform.position.x) == (int)(off_location.x) &&
                (int)(popup.transform.position.y) == (int)(off_location.y) &&
                (int)(popup.transform.position.z) == (int)(off_location.z)
                )
                ready = true;
        }

        //If there is a popup waiting and none playing play the first popup in the queue
        if (queue.Count != 0 && ready)
        {
            image.sprite = queue[0].image;
            text.text = queue[0].message;
            active = true;
            ready = false;
            Invoke("NextPopup", queue[0].duration);
        }

    }

    void PopupAnimation()
    {
        Vector3 desired_location = on_location;
        if (!active)
            desired_location = off_location;
        Debug.Log(desired_location.y);
        Debug.Log(off_location.y);
        const float bias = 0.95f;
        popup.transform.position = popup.transform.position * bias + desired_location * (1f - bias);
        Debug.Log(popup.transform.position);
    }

    void NextPopup()
    {
        queue.RemoveAt(0);
        active = false;
    }
}
