using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Rigidbody2D starter;
    public GameObject playButton;
    public GameObject roadController;
    public GameObject lifes;

    public enum GameState {Idle,Playing,Ended};
    public GameState gameState = GameState.Idle;

    public int activeScene;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        activeScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Cargando escena " + activeScene);
        roadController.SetActive(false);
        gameState = GameState.Idle;
        Debug.Log("Estado de juego "+gameState.ToString());
        playButton.transform.SetAsLastSibling();
        roadController.SetActive(true);

    }

    void StartGame()
    {
        Debug.Log("Comenzando el juego..");
        if (gameState == GameState.Idle)
        {
            gameState = GameState.Playing;
            Debug.Log("Estado de juego " + gameState.ToString());
            starter.WakeUp();
            playButton.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
   
    void Restart()
    {
        lifes.SendMessage("LostLife");
        Time.timeScale = 1;
        SceneManager.LoadScene(activeScene);
    }
    public void RestartWithLife()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(activeScene);
    }
    void NextLevel()
    {

        Debug.Log("Cargando escena " + activeScene + 1);
        gameState = GameState.Idle;
        SceneManager.LoadScene(activeScene + 1);
    }
    void ResetGame()
    {
        Debug.Log("Reseteando el juego...");
        SceneManager.LoadScene(0);
    }
   
    
}
