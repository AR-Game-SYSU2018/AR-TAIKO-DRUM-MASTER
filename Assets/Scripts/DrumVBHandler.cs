using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class DrumVBHandler : MonoBehaviour, IVirtualButtonEventHandler
{
    GameObject drumA, drumB, drumC, scoreBoard;
    Material sphere;

    // Use this for initialization
    void Start()
    {
        sphere = transform.GetChild(0).GetComponent<MeshRenderer>().material;
        
        drumA = GameObject.Find("DrumA");
        drumB = GameObject.Find("DrumB");
        drumC = GameObject.Find("DrumC");

        scoreBoard = GameObject.Find("ScoreBoard");

        drumA.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        drumB.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        drumC.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        scoreBoard.GetComponent<TextMesh>().text = "Score:100";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        switch(vb.VirtualButtonName)
        {
            case "DrumA":
                sphere.color = Color.red;

                break;
            case "DrumB":
                sphere.color = Color.green;
                break;
            case "DrumC":
                sphere.color = Color.blue;
                break;
            default:
                sphere.color = Color.black;
                break;
        }
        

    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        sphere.color = Color.white;
    }
}
