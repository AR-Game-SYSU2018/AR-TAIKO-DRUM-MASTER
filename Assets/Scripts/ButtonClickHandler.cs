using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ARGameTaiko;

public class ButtonClickHandler : MonoBehaviour {
	// Use this for initialization
    private AudioSource aud;
	void Start () {
        GameObject btnObj = GameObject.Find("Button");
        aud = GameObject.Find("ImageTarget").GetComponent<AudioSource>();
        Button button = (Button) btnObj.GetComponent<Button>();
        button.onClick.AddListener(delegate()
        {
            onClick(btnObj);
        });
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void onClick(GameObject btnObj)
    {
        if (TrackableEventHandler.IfFound() && !InstantiateHandler.Instance.IsPlaying() && btnObj != null)
        {
            InstantiateHandler.Instance.StartInstantiate();
            FindObjectOfType<DrumVBHandler>().SetStartTrue();
            aud.Play();
            Destroy(btnObj);
        }
    }
}
