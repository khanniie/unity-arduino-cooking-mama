using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Beef : MonoBehaviour
{
	public GameObject arduinoScriptContainer;
	arduinoController arduino;

	public Sprite beef1;
	public Sprite beef2;
	public Sprite beef3;
	public Sprite beef4;
	public Sprite beef5;
	public Sprite beef6;

	public GameObject good;
	public GameObject verygood;
	public GameObject fail;

	public GameObject beefImage;

	public GameObject cutline;

	private int num_mistakes = 0;
	private int cutnum = 0;

	private int pressedButton = -1;
	private int prevButton = -1;

	private double[] cutpos = {-1.65, -1.3, -0.85, -0.16, 0.4, 1, 1.6, 2.3};

	void Start ()
	{
		arduino = arduinoScriptContainer.GetComponent<arduinoController>();
	
	}

	private void updateButton(){
		prevButton = pressedButton;
		pressedButton = -1;
		if(arduino.but_one == 1 && prevButton != 1){
			pressedButton = 1;
		} else if(arduino.but_two == 1 && prevButton != 2){
			pressedButton = 2;
		} else if(arduino.but_three == 1 && prevButton != 3){
			pressedButton = 3;
		} else if(arduino.but_four == 1 && prevButton != 4){
			pressedButton = 4;
		} else if(arduino.but_five == 1 && prevButton != 5){
			pressedButton = 5;
		} else if(arduino.but_six == 1 && prevButton != 6){
			pressedButton = 6;
		}
	}

	void Update ()
	{

		if (Input.GetKeyDown("space"))
		{
			slice();
		}
		updateButton();
		if(cutnum == pressedButton - 1){
			slice();
		} else if (pressedButton != -1){
			Debug.Log("previous button is: " + prevButton);
			Debug.Log("currently pressed button is:" + pressedButton);
			num_mistakes++;
		}
		
	}

	public void slice (){
		cutnum++;
		if (cutnum == 1) {
			beefImage.GetComponent<SpriteRenderer>().sprite = beef1;
			cutline.transform.position = new Vector2 ((float)cutpos [cutnum + 1], -2.19f);
			Debug.Log(cutnum + 1);
			Debug.Log(cutpos [cutnum + 1]);
		} else if (cutnum == 2) {
			beefImage.GetComponent<SpriteRenderer>().sprite = beef2;
			cutline.transform.position = new Vector2 ((float)cutpos [cutnum + 1], -2.19f);
		} else if (cutnum == 3) {
			beefImage.GetComponent<SpriteRenderer>().sprite = beef3;
			cutline.transform.position = new Vector2 ((float)cutpos [cutnum + 1], -2.19f);
		} else if (cutnum == 4) {
			beefImage.GetComponent<SpriteRenderer>().sprite = beef4;
			cutline.transform.position = new Vector2 ((float)cutpos [cutnum + 1], -2.19f);
		} else if (cutnum == 5) {
			beefImage.GetComponent<SpriteRenderer>().sprite = beef5;
			cutline.transform.position = new Vector2 ((float)cutpos [cutnum + 1], -2.19f);
		} else if (cutnum == 6) {
			beefImage.GetComponent<SpriteRenderer>().sprite = beef6;
			cutline.SetActive(false);
			finishScene ();
		}
	}

	private void finishScene (){
		Debug.Log(num_mistakes);
		if (num_mistakes < 5) {
			verygood.SetActive (true);
		} else if (num_mistakes < 10) {
			good.SetActive (true);
		} else {
			fail.SetActive (true);
		}
		Invoke ("loadNext", 4);
	}

	private void loadNext(){
		SceneManager.LoadScene("SPAM");
	}
		
}

