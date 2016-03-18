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

    void Start()
    {
        on_location = popup.transform.position;
        off_location = on_location + new Vector3(0,100,0);
        popup.transform.position = off_location;
    }

    void FixedUpdate()
    {
        //Animation
        Vector3 desired_location = on_location;
        if (!active)
            desired_location = off_location;

        const float bias = 0.95f;
        popup.transform.position = popup.transform.position * bias + desired_location * (1f - bias);


        if (!active && !ready)
        {
            if((int)(popup.transform.position.x * 10) == (int)(off_location.x * 10) &&
                (int)(popup.transform.position.y * 10) == (int)(off_location.y * 10) &&
                (int)(popup.transform.position.z * 10) == (int)(off_location.z * 10)
                )
                ready = true;
        }

        if (queue.Count != 0 && ready)
        {
            image.sprite = queue[0].image;
            text.text = queue[0].message;
            active = true;
            ready = false;
            Invoke("NextPopup", queue[0].duration);
        }
    }

    void NextPopup()
    {
        queue.RemoveAt(0);
        active = false;
    }
}
