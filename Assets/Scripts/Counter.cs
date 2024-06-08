using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
	public int eggCount = 0;
	public int chickCount = 0;
	public int henCount = 0;
	public int cattoCount = 0;
	
	public Text eggText;
	public Text chickText;
	public Text henText;
	public Text cattoText;
	public Text clockText;

    private float elapsedTime = 0f;

    private void Update()
    {
        // Update the counters
        eggText.text = "Eggs: " + eggCount;
        chickText.text = "Chicks: " + chickCount;
        henText.text = "Hens: " + henCount;
        cattoText.text = "Cattos: " + cattoCount;

        // Update the clock
        elapsedTime += Time.deltaTime;
        DisplayTime(elapsedTime);
    }

    void DisplayTime(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        clockText.text = string.Format("Clock: {0:00}:{1:00}", minutes, seconds);
    }
}
