using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class DrumVBHandler : MonoBehaviour, IVirtualButtonEventHandler
{
    private static int MAX_VALID_NUM_VB = 5;
    private static int RESET_PERIOD = 1000;
    private static int HIT_DURATION = 400;

    private bool[] statusCode = {   false,false,false,false,
                                    false,false,false,false,
                                    false,false,false,false};

    private System.DateTime lastResetTime;
    private System.DateTime lastHitTime;

    GameObject drumA;
    GameObject drumAx;
    GameObject drumAy;
    GameObject drumAw;
    GameObject drumB;
    GameObject drumBx;
    GameObject drumBy;
    GameObject drumBw;
    GameObject drumC;
    GameObject drumCx;
    GameObject drumCy;
    GameObject drumCw;

    GameObject scoreBoard;
    Material sphere;

    

    // Use this for initialization
    void Start()
    {
        sphere = transform.GetChild(0).GetComponent<MeshRenderer>().material;
        
        drumA = GameObject.Find("DrumA");
        drumAx = GameObject.Find("DrumAx");
        drumAy = GameObject.Find("DrumAy");
        drumAw = GameObject.Find("DrumAw");
        drumB = GameObject.Find("DrumB");
        drumBx = GameObject.Find("DrumBx");
        drumBy = GameObject.Find("DrumBy");
        drumBw = GameObject.Find("DrumBw");
        drumC = GameObject.Find("DrumC");
        drumCx = GameObject.Find("DrumCx");
        drumCy = GameObject.Find("DrumCy");
        drumCw = GameObject.Find("DrumCw");

        scoreBoard = GameObject.Find("ScoreBoard");

        drumA.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        drumAx.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        drumAy.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        drumAw.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        drumB.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        drumBx.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        drumBy.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        drumBw.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        drumC.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        drumCx.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        drumCy.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        drumCw.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        scoreBoard.GetComponent<TextMesh>().text = "";
        invalidHit();
        lastResetTime = System.DateTime.Now;
        lastHitTime = System.DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        System.DateTime tmp = System.DateTime.Now;
        if ((tmp - lastHitTime).TotalMilliseconds > HIT_DURATION)
            if ((tmp - lastResetTime).TotalMilliseconds > RESET_PERIOD)
                invalidHit();        
        string s = "";
        for (int i = 0; i < 12; i++)
            if (statusCode[i])
                s = s + "1";
            else
                s = s + "0";

        scoreBoard.GetComponent<TextMesh>().text = s;

    }

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        switch(vb.VirtualButtonName)
        {
            case "DrumA":
                //sphere.color = Color.red;
                if (statusCode[3])
                    statusCode[0] = true;
                break;
            case "DrumAx":
                statusCode[1] = true;
                if (statusCode[2])
                    invalidHit();
                break;
            case "DrumAy":
                statusCode[2] = true;
                if (statusCode[1])
                    invalidHit();
                break;
            case "DrumAw":
                statusCode[3] = true;
                lastHitTime = System.DateTime.Now;
                break;
            case "DrumB":
                if (statusCode[7])
                    statusCode[4] = true;
                //sphere.color = Color.green;
                break;
            case "DrumBx":
                statusCode[5] = true;
                if (statusCode[6])
                    invalidHit();
                break;
            case "DrumBy":
                statusCode[6] = true;
                if (statusCode[5])
                    invalidHit();
                break;
            case "DrumBw":
                statusCode[7] = true;
                lastHitTime = System.DateTime.Now;
                break;
            case "DrumC":
                if (statusCode[11])
                    statusCode[8] = true;
                //sphere.color = Color.blue;
                break;
            case "DrumCx":
                statusCode[9] = true;
                if (statusCode[10])
                    invalidHit();
                break;
            case "DrumCy":                
                statusCode[10] = true;
                if (statusCode[9])
                    invalidHit();
                break;
            case "DrumCw":
                statusCode[11] = true;
                lastHitTime = System.DateTime.Now;
                break;
            default:
                //sphere.color = Color.black;
                break;
        }
        int statusCodeSum = 0;
        for (int i = 0; i < 12; i++)
            if (statusCode[i])
                statusCodeSum++;
        if (statusCodeSum <= MAX_VALID_NUM_VB)
            validHit();
        else
            invalidHit();

    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        //sphere.color = Color.white;
        /*
        switch (vb.VirtualButtonName)
        {
            case "DrumA":
                //sphere.color = Color.red;
                statusCode[0] = false;
                break;
            case "DrumAx":
                statusCode[1] = false;
                break;
            case "DrumAy":
                statusCode[2] = false;
                break;
            case "DrumAw":
                statusCode[3] = false;
                break;
            case "DrumB":
                statusCode[4] = false;
                //sphere.color = Color.green;
                break;
            case "DrumBx":
                statusCode[5] = false;
                break;
            case "DrumBy":
                statusCode[6] = false;
                break;
            case "DrumBw":
                statusCode[7] = false;
                break;
            case "DrumC":
                statusCode[8] = false;
                //sphere.color = Color.blue;
                break;
            case "DrumCx":
                statusCode[9] = false;
                break;
            case "DrumCy":
                statusCode[10] = false;
                break;
            case "DrumCw":
                statusCode[11] = false;
                break;
            default:
                //sphere.color = Color.black;
                break;
        }
        */        

    }

    private void validHit()
    {
        if (statusCode[0] && statusCode[3])
            sphere.color = Color.red;
        else if (statusCode[4] && statusCode[7])
            sphere.color = Color.blue;
        else if (statusCode[8] && statusCode[11])
            sphere.color = Color.yellow;
    }

    private void invalidHit()
    {
        lastResetTime = System.DateTime.Now;
        sphere.color = Color.white;
        for (int i = 0; i < 12; i++)
            statusCode[i] = false;
    }
}
