using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LifeController : MonoBehaviour
{
    private int lifes;
    public Text lifeCount;
    public GameObject outOfLifes;
    private int activeScene;
    private bool lostLife;
    private const int maxLifes = 20;
    // Start is called before the first frame update
    void Start()
    {
        lostLife = true;
        activeScene = SceneManager.GetActiveScene().buildIndex;
        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
        {
            PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);
            PlayerPrefs.SetInt("lifes", 20);
            
        }
        lifes = PlayerPrefs.GetInt("lifes");
        Debug.Log("Vidas: " + lifes);
        lifeCount.text = lifes + " x";
        CheckLifes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LostLife()
    {
        if (lifes > 0 && lostLife)
        {
            lostLife = false;
            lifes--;
            PlayerPrefs.SetInt("lifes", lifes);
            Debug.Log("VIDA PERDIDA\nVidas: " + lifes);
        }
        
    }
    private void CheckLifes()
    {
        if(lifes <= 0)
        {
            // outOfLifes.SetActive(true);
            // GameObject.FindGameObjectWithTag("play_button").SetActive(false);
            // GameObject.FindGameObjectWithTag("pause_box").SetActive(false);
            // Time.timeScale = 0;
        }
    }
    public void AddLifes()
    {
        lifes = PlayerPrefs.GetInt("lifes");
        if(lifes < maxLifes)
        {
            lifes +=10;
        }
        if (lifes > maxLifes)
        {
            lifes = maxLifes;
        }
        PlayerPrefs.SetInt("lifes",lifes);
        Debug.Log("VIDA restaurada\nVidas: " + lifes);
        SceneManager.LoadScene(activeScene);
    }
    public void RefreshLifes()
    {
        lifes = PlayerPrefs.GetInt("lifes");
        
        Debug.Log("Vidas: " + lifes);
        lifeCount.text = lifes + " x";
        if(lifes == maxLifes)
        {
            lifeCount.text = "MAX ";
        }
        QuitRewarded();
    }
    private void QuitRewarded()
    {
        outOfLifes.SetActive(false);
    }
}
