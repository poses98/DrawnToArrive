using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        int activeScene = SceneManager.GetActiveScene().buildIndex;
        if (activeScene == 0)
        {
            GameObject.FindGameObjectWithTag("stars_count").GetComponent<Text>().text = PlayerPrefs.GetInt("stars") + " x";
            if (PlayerPrefs.GetInt("lastLevel") == 0)
            {
                GameObject.FindGameObjectWithTag("level_text").GetComponent<Text>().text = "1";
            }
            else
            {
                GameObject.FindGameObjectWithTag("level_text").GetComponent<Text>().text = "" + (PlayerPrefs.GetInt("lastLevel") - 2);
            }
        }else if (activeScene != 1)
        {
            GameObject.FindGameObjectWithTag("level_text").GetComponent<Text>().text = ""+(activeScene - 2);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadSelector()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLevel (int level)
    {
        SceneManager.LoadScene(level);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadLastLevel()
    {
      
        if(PlayerPrefs.GetInt("lastLevel") == 0)
        {
        
            SceneManager.LoadScene(3);
        }else{
            SceneManager.LoadScene(PlayerPrefs.GetInt("lastLevel"));
        }
        
    }
    public void ResetGame()
    {
        PlayerPrefs.SetInt("lastLevel", 0);
        SceneManager.LoadScene(0);
    }
}
