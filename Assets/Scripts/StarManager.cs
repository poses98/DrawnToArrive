using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    private int stars;
    // Start is called before the first frame update
    void Start()
    {
        stars = PlayerPrefs.GetInt("stars");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void AddStars(int num)
    {
        stars += num;
        PlayerPrefs.SetInt("stars", stars);
    }
}
