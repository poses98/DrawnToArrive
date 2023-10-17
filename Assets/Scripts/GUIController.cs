using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour
{
    private GameObject uiFinal;
    public GameObject pauseBox;
    public GameObject endLevelBox;
    private Button[] buttons;

    private int activeScene;
    // Start is called before the first frame update
    void Start()
    {
        activeScene = SceneManager.GetActiveScene().buildIndex;
        buttons = endLevelBox.GetComponentsInChildren<Button>();
        Debug.Log("Boton: " + buttons.Length);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowUIFinalLevel(string collision)
    {
        endLevelBox.SetActive(true);
        
        if (collision == "Finish")
        {
            SetEndText(true);
            SetNextButton(true);
        }
        if (collision == "Respawn")
        {
            SetNextButton(false);
            SetEndText(false);
        }

    }
    private void SetNextButton(bool check)
    {

        foreach (Button button in buttons)
        {
            Debug.Log("Boton: " + button.ToString());
            if (button.tag == "nextLevel")
            {
                button.interactable = check;
            }
        }
    }
    private void SetEndText(bool check)
    {
        foreach (Text text in endLevelBox.GetComponentsInChildren<Text>())
        {
            if (text.tag == "End_Text")
            {
                if (check)
                {
                    text.text = "LEVEL COMPLETED!";
                }
                else
                {
                    text.text = "TRY AGAIN!";
                }
            }
        }
    }
    public void Pause(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;
            pauseBox.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseBox.SetActive(false);
        }
    }
    private void ShowStars(int stars)
    {
        GameObject.FindGameObjectWithTag("stars_count").GetComponent<Text>().text = stars + " x";
    }

}
