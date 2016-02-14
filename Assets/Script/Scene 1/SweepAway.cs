using UnityEngine;
using UnityEngine.UI;
using DigitalRuby.RainMaker;
using System.Collections;

public class SweepAway : MonoBehaviour {

    RainScript rain;
    public float rainSpeed = 0.06f;
    public GameObject Thunder;
    RawImage black;

    public GameObject nextPart;
    public GameObject spawn;

    bool reached = false;
    bool fade = false;

	void Start () {
        rain = GameObject.FindObjectOfType<RainScript>();
        black = GameObject.FindObjectOfType<RawImage>();
    }
	
	void FixedUpdate () {
        if (!reached) {
            if (rain.RainIntensity < 1f) {
                rain.RainIntensity += rainSpeed;
                return;
            }
            reached = true;

            rain.RainIntensity = 0f;
            black.enabled = true;
            Instantiate(Thunder);
            
            Invoke("On", 8);
        }

        if (fade)
        {
            Debug.Log(black.color.a);
            if (black.color.a > 0) {
                black.color = new Color(0f,0f,0f, black.color.a - 0.005f);
                return;
            }
            fade = false;
            Instantiate(nextPart);
            Destroy(gameObject);
        }
	}

    void On()
    {
        GameObject slug = GameObject.FindGameObjectWithTag("Player");
        slug.transform.position = spawn.transform.position;
        fade = true;
    }
}
