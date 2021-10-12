using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Conditions : MonoBehaviour
{
    //Score Stuff
    private int Score;
    public Text ScoreText;

    //Timer Stuff
    public float TimeLeft;
    public int TimeRemaining;
    public Text TimerText;

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + Score;

        //Win Condition
        if (GameObject.FindGameObjectsWithTag("Coin").Length == 0)
        {
            if (TimeLeft > 0)
            {
                SceneManager.LoadScene("WinScene");
            }
        }
        
        //Timer Codes
        TimeLeft -= Time.deltaTime;
        TimeRemaining = Mathf.FloorToInt(TimeLeft % 60);

        TimerText.text = "Timer: " + TimeRemaining.ToString() + " seconds";
        //Second Lose Condition
        if (TimeLeft <= 0)
        {
            TimerText.text = "Timer: 0 seconds";
            SceneManager.LoadScene("LoseScene");
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Coin")
        {
            Score += 10;
            Destroy(collider.gameObject);
        }

        //Lose Condition
        if (collider.gameObject.tag == "Water")
        {
            //Currently lock not working
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            SceneManager.LoadScene("LoseScene");
        }
    }
}
