using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OSCMessageSender : MonoBehaviour {

    public OSC osc;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            OscMessage message = new OscMessage();
            message.address = "/foo1";
            osc.Send(message);
            print(message.ToString());
            //message.address = "/IncreaseVolume";
            //message.values.Add(0.1f);
            //osc.Send(message);
           
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            OscMessage message = new OscMessage();
            message.address = "/foo2";
            osc.Send(message);
            print(message.ToString());
            //message.address = "/IncreaseVolume";
            //message.values.Add(0.1f);
            //osc.Send(message);

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            OscMessage message = new OscMessage();
            message.address = "/foo3";
            osc.Send(message);
            print(message.ToString());
            //message.address = "/IncreaseVolume";
            //message.values.Add(0.1f);
            //osc.Send(message);

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            OscMessage message = new OscMessage();
            message.address = "/foo4";
            osc.Send(message);
            print(message.ToString());
            //message.address = "/IncreaseVolume";
            //message.values.Add(0.1f);
            //osc.Send(message);

        }







    }
		
	}

