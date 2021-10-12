using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Conditions : MonoBehaviour
{
    private int Score;
    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + Score;

        //Win Condition
        if (GameObject.FindGameObjectsWithTag("Coin").Length == 0)
        {
            //Need to unlock cursor here too
            SceneManager.LoadScene("WinScene");
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
