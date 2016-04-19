using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExplosiveEnding : MonoBehaviour {

    public GameObject explosion_sound;
    public GameObject juke_box;
    Text end_text;
    RawImage black;
    bool fade_to_black = false;
    bool fade_text = false;

    void Start ()
    {
        foreach (AudioSource source in GameObject.FindObjectsOfType<AudioSource>())
        {
            Destroy(source);
        }
        Instantiate(explosion_sound);

        end_text = GameObject.FindObjectOfType<Text>();
        end_text.color = new Color(0, 0, 0, 1);
        black = GameObject.FindObjectOfType<RawImage>();

        black.color = new Color(1, 1, 1, 1);
        Invoke("BlackFade", 3);
    }
	
	void Update()
    {
        if (fade_to_black)
        {
            if (black.color.r > 0)
            {
                black.color = new Color(black.color.r - 0.01f, black.color.r - 0.01f, black.color.r - 0.01f, 1);
            }
            else
            {
                fade_to_black = false;
                fade_text = true;
                Instantiate(juke_box);
            }
        }

        if (fade_text)
        {
            end_text.enabled = true;
            if (black.color.r < 1)
            {
                end_text.color = new Color(end_text.color.r + 0.001f, end_text.color.r + 0.001f, end_text.color.r + 0.001f, 1);
            }
        }
	}

    void BlackFade()
    {
        fade_to_black = true;
    }
}
