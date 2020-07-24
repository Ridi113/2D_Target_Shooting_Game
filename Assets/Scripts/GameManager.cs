using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Globalization;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject target;

    public GameObject winText;

    int score = 0;

    public Text scoreText;

    bool win = false;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn();
        InvokeRepeating("Spawn",1f,1f);  //  function,  first time it start, and then after how much it will  keep calling
    }

    // Update is called once per frame
    void Update()
    {
        if(win == true)
        {
            CancelInvoke("Spawn");
        }

        if(Input.GetMouseButtonDown(0)) //  0 is  the  left mouse button
        {
            GetComponent<AudioSource>().Play();
        }
        
    }

    void Spawn()
    {
        // Create two random position value
        float randomX = UnityEngine.Random.Range(-7f, 7f); // give the min and max  value  of  our screen
        float randomY = UnityEngine.Random.Range(-3.5f, 3.5f);

        // random position is  created
        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        //  new target is spawned in random positions
        Instantiate(target, randomPosition, Quaternion.identity); //   Quaternion.indentity  means  no rotation at all

    }

    public void IncrementScore()
    {
        score++;
        print(score);

        scoreText.text = score.ToString();

        if(score >= 10)
        {
            win = true;

            winText.SetActive(true);
        }
    }
}
