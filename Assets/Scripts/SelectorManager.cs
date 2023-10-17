using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectorManager : MonoBehaviour
{
    private GameObject[] niveles;
    GameObject menuManager;
    public GameObject prefabButton;
    public GameObject levelContainer;
    int scenesNumber;
   // public Sprite normal, gravity, speed, portal, mixed;
    // Start is called before the first frame update
    void Start()
    {
        scenesNumber = SceneManager.sceneCountInBuildSettings - 3;
        Debug.Log("Escenas: " + scenesNumber);
        CreateLevels();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    private void CreateLevels()
    {
        Vector2 iniPos = new Vector3(-249, -1010);
        int levels = 0;
        
        for(int i=0;i < (scenesNumber/6); i++)
        {
            for (int j=0;j < 6; j++)
            {
                Vector3 copy_of_pos = iniPos;
                GameObject buttonGO = Instantiate(prefabButton, copy_of_pos, Quaternion.identity);
                buttonGO.transform.parent = levelContainer.transform;
                buttonGO.transform.localScale= new Vector2(1,1);
                buttonGO.transform.localPosition = copy_of_pos;

                int copy_lvl = levels;
                Button button = buttonGO.GetComponent<Button>();
                button.onClick.AddListener(() => LoadLevel(copy_lvl + 3));
                button.GetComponentInChildren<Text>().text = "" + (levels + 1);

                if (levels > PlayerPrefs.GetInt("lastLevel") - 2)
                {
                    // DISABLE THIS LINE IN PRODUCTION
                    // button.interactable = false;
                }
                levels++;
                Debug.Log("Moviendo boton a la posicion:" + iniPos.x + " "+iniPos.y);
                Debug.Log("Posicion del boton:" + buttonGO.transform.position.x + " " + buttonGO.transform.position.y);
                iniPos.x += 100;
            }
            iniPos.x -= 600;
            iniPos.y += 100;
        }
        RestOfLevels(scenesNumber%6,levels,iniPos);
    }

    private void RestOfLevels(int lvls,int levels,Vector3 iniPos)
    {
        Debug.Log("Creando el resto de niveles:" + lvls);
        for(int i=0;i < lvls; i++)
        {
            Vector3 copy_of_pos = iniPos;
            GameObject buttonGO = Instantiate(prefabButton, copy_of_pos, Quaternion.identity);
            buttonGO.transform.parent = levelContainer.transform;
            buttonGO.transform.localScale = new Vector2(1, 1);
            buttonGO.transform.localPosition = copy_of_pos;

            int copy_lvl = levels;
            Button button = buttonGO.GetComponent<Button>();
            button.onClick.AddListener(() => LoadLevel(copy_lvl + 3));
            button.GetComponentInChildren<Text>().text = "" + (levels + 1);

            if (levels > PlayerPrefs.GetInt("lastLevel") - 2)
            {
                // DISABLE THIS LINE IN PRODUCTION
                // button.interactable = false;
            }
            levels++;
            Debug.Log("Moviendo boton a la posicion:" + iniPos.x + " " + iniPos.y);
            Debug.Log("Posicion del boton:" + buttonGO.transform.position.x + " " + buttonGO.transform.position.y);
            iniPos.x += 100;
        }
    }

    /*private void SetImage(Button boton)
    {
        if(boton.tag == "Normal")
        {
            boton.image.sprite = normal;
        }
        if (boton.tag == "Gravity")
        {
            boton.image.sprite = gravity;
        }
        if (boton.tag == "Portal")
        {
            boton.image.sprite = portal;
        }
        if (boton.tag == "Speed")
        {
            boton.image.sprite = speed;
        }
        if (boton.tag == "Mixed")
        {
            boton.image.sprite = mixed;
        }
    }*/
    /*
            for(int i=0;i < niveles.Length; i++)
            {
            // SetImage(boton);
            int copy_i = i;
                niveles[copy_i].GetComponent<Button>().onClick.AddListener(()=>LoadLevel(copy_i+2));
                niveles[copy_i].GetComponentInChildren<Text>().text =""+ (copy_i+1);
                if (i > PlayerPrefs.GetInt("lastLevel")-2)
                {
                    niveles[copy_i].GetComponent<Button>().interactable = false;
                }
            }
        
        int i = 0;
        foreach(GameObject nivel in niveles)
        {
            nivel.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(i + 1));
            nivel.GetComponentInChildren<Text>().text = "" + (i + 1);
            if (i > PlayerPrefs.GetInt("lastLevel") - 2)
            {
                nivel.GetComponent<Button>().interactable = false;
            }
            Debug.Log("Estrellas: " + nivel.GetComponentsInChildren<RawImage>().Length);
            Debug.Log("Atribuyendo el nivel: " + (i + 1));
            i++;
        }
        */


}
