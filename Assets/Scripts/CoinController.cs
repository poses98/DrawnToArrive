using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinController : MonoBehaviour
{

    public GameObject game;
    private Rigidbody2D coin;
    private bool gravityChange = true;
    Animator animator;
    private bool ended = false;
    public GameObject lifes;
    public GameObject stars;
    private int starNum;
    private int activeScene;
    // Start is called before the first frame update
    void Start()
    {
        coin = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        starNum = 0;
        activeScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (ended)
        {
            coin.Sleep();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colision detectada");
        if (collision.tag == "Finish")
        {
            if (PlayerPrefs.GetInt("lastLevel") < activeScene + 1)
            {
                PlayerPrefs.SetInt("lastLevel", activeScene + 1);

            }
            game.SendMessage("ShowUIFinalLevel", "Finish");
            ended = true;
            stars.SendMessage("AddStars", starNum);
            game.SendMessage("ShowStars", starNum);


        }
        if (collision.tag == "Respawn")
        {
            game.SendMessage("ShowUIFinalLevel", "Respawn");
            lifes.SendMessage("LostLife");
            ended = true;
        }
        if(collision.tag == "Gravity")
        {
            Debug.Log("gravityChange = " + gravityChange);
            if (gravityChange)
            {
                coin.velocity = new Vector2(coin.velocity.x, coin.velocity.y*-0.25f);
                coin.gravityScale *= -1;
                gravityChange = false;
                Invoke("ChangeGravity", 0.5f);
            }
        }
        if(collision.tag == "Teleport_enter")
        {
            Teleport();
        }
        if (collision.tag == "Starter")
        {
            collision.attachedRigidbody.Sleep();
        }
    
        if (collision.GetComponent<Animator>())
        {
            collision.GetComponent<Animator>().SetBool("active", true);
        }
        if (collision.tag == "point")
        {
            starNum++;
            collision.gameObject.SetActive(false);
            Debug.Log("Puntos:" + starNum);

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Acceleration")
        {

            coin.velocity = new Vector2(coin.velocity.x + 0.05f, coin.velocity.y);
        }
        if (collision.tag == "reverse_acceleration")
        {

            coin.velocity = new Vector2(coin.velocity.x - 0.05f, coin.velocity.y);
        }
        if (collision.tag == "Acceleration_super")
        {
       
            coin.velocity = new Vector2(coin.velocity.x + 0.5f, coin.velocity.y);
        }
        if (collision.tag == "Sticky_y")
        {

            coin.gravityScale *= -1;
        }
        if (collision.tag == "Gravity")
        {
    
            if (gravityChange)
            {
                coin.gravityScale *= -1;
                gravityChange = false;
                Invoke("ChangeGravity", 0.5f);
            }
        }
    }
    private void ChangeGravity()
    {
       
        gravityChange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Sticky_y")
        {
            Debug.Log("Desacoplar plataforma pegajosa detectado.");
            coin.gravityScale *= -1;
        }
        if (collision.GetComponent<Animator>())
        {
            collision.GetComponent<Animator>().SetBool("active", false);
        }
        if (collision.tag == "Gravity")
        {
            Debug.Log("gravityChange = " + gravityChange);
            if (gravityChange)
            {
                coin.gravityScale *= -1;
                gravityChange = false;
                Invoke("ChangeGravity", 0.5f);
            }
        }
    }
    void Teleport()
    {
        GameObject[] teleportDoors = GameObject.FindGameObjectsWithTag("Teleport_exit");
        coin.transform.position = teleportDoors[0].transform.position;
    }

}
