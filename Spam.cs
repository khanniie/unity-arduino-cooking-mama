using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spam : MonoBehaviour
{
    public GameObject arduinoScriptContainer;
    arduinoController arduino;

    public GameObject verygood;
    public GameObject good;
    public GameObject fail;

    public Text countdown;
	private bool countingdown = true;
	int stage = 0;

    float currCountdownValue;
    public IEnumerator StartCountdown(float countdownValue = 10)
    {
		Debug.Log(currCountdownValue);
        currCountdownValue = countdownValue;
		while (currCountdownValue > 0 && countingdown)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
			countdown.text = (int)currCountdownValue + "";
        }
    }

    void Start ()
    {
        arduino = arduinoScriptContainer.GetComponent<arduinoController>();
		StartCoroutine(StartCountdown());
    
    }

    void Update ()
    {
		if (Input.GetKeyDown("space"))
		{
			countingdown = false;
			finishScene ();
		}
		if (stage == 0 && arduino.photocell_one == 1) {
			stage = 1;
		} else if (stage == 1 && arduino.photocell_two == 1) {
			countingdown = false;
			finishScene ();
		}
		if (currCountdownValue <= 0) {
			finishScene ();
		}
        
        
    }


    private void finishScene (){
        if (currCountdownValue > 5) {
            verygood.SetActive (true);
        } else if (currCountdownValue > 0) {
            good.SetActive (true);
        } else {
            fail.SetActive (true);
        }
        Invoke ("loadNext", 4);
    }

    private void loadNext(){
        SceneManager.LoadScene("final");
    }
        
}

