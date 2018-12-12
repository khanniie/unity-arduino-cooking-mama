using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;

public class arduinoController : MonoBehaviour {
	SerialPort arduino = new SerialPort("/dev/cu.usbmodem1411", 9600);

	public int photocell_one = 0;
	public int photocell_two = 0;
	public int but_one = 0;
	public int but_two = 0;
	public int but_three = 0;
	public int but_four = 0;
	public int but_five = 0;
	public int but_six = 0;


	void Start () {
		try{
			arduino.Open ();
		} catch {
			arduino = null;
		}
	}

	// Update is called once per frame
	void Update () {
		//arduino.WriteLine("1"); //this will send a 1 to the arduino letting it know that we are ready to recieve data
		//arduino.BaseStream.Flush(); //this ensures that the data has gotten to the arduino
		if(arduino != null) {
			string data = arduino.ReadLine();
			serialParse(data);
		}
	}
		
	public void serialParse(string incoming)
	{
		string[] result = incoming.Split(new Char[]{','}, StringSplitOptions.RemoveEmptyEntries);  
//		for (int i = 0; i < result.Length; i++) {
//			Debug.Log (i + ":  " + result [i] + "  ");
//		}
		try{
			photocell_one = int.Parse(result[0]);
			photocell_two = int.Parse(result[1]);
			but_one = int.Parse(result[2]);
			but_two = int.Parse(result[3]);
			but_three = int.Parse(result[4]);
			but_four = int.Parse(result[5]);
			but_five = int.Parse(result[6]);
			but_six = int.Parse(result[7]);

		}catch{
		}

	}


}

