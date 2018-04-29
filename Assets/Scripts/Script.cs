using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Script : MonoBehaviour, IVirtualButtonEventHandler
{
    GameObject vbObj;
    Material cube;

    // Use this for initialization
    void Start()
    {
        cube = transform.GetChild(0).GetComponent<MeshRenderer>().material;
        vbObj = GameObject.Find("VirtualButton");
        vbObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        cube.color = Color.red;
    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        cube.color = Color.white;
    }
}
