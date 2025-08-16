using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class pickcolor : MonoBehaviour
{
    public string currentColor;
    public SpriteRenderer sr = default;
    bool rightcolor = false;
    bool wrongcolor = false;
    int gameisrunning;
    [SerializeField] int lastindex;
    bool tolatecolor = false;
    bool tolatecolorbool = false;

    public Color colorRED;
    public Color colorYellow;
    public Color colorBlue;
    public Color colorGreen;
    private object UnityEnRandom;


    // Start is called before the first frame update
    void Start()
    {
        setRandomColorfirst();
    }

    // Update is called once per frame
    void Update()
    {
        Colorrightorfalse();
        picktolate();
    }

    private void Colorrightorfalse()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            gameisrunning++;
            if (gameisrunning >= 2)
            {
                if (rightcolor == true)
                {
                    //rightcolor audio                                                   
                    FindObjectOfType<Audiomanager>().Play("rightcolor");
                    //right color
                    updatecolor();
                    rightcolor = false;
                    FindObjectOfType<GameSession>().countScore();
                    FindObjectOfType<Rotator>().Changedirection();
                    tolatecolorbool = false;
                    tolatecolor = false;
                    FindObjectOfType<Rotator>().Upgradespeed();

                }
                else if (wrongcolor == true)
                {
                    //wrongcolor audio                                               
                    FindObjectOfType<Audiomanager>().Play("falseColor");
                    //wrong color
                    FindObjectOfType<Rotator>().Stopspeed();
                    StartCoroutine(Waitsecond());

                }
            }

        }
    }
    public IEnumerator Waitsecond()
    {
        yield return new WaitForSeconds(0.2f);
        FindObjectOfType<SceneLoader>().gameover();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        {
            if (col.tag == currentColor)
            {
                rightcolor = true;
                tolatecolorbool = true;
            }
            else
            {
                wrongcolor = true;
                tolatecolorbool = false;
            }
        }
    }
    private void picktolate()
    {
        if(tolatecolorbool == true)
        {
            tolatecolor = true;
        }
        if(tolatecolorbool == false && tolatecolor == true)
        {
            //wrongcolor audio                                                             
            FindObjectOfType<Audiomanager>().Play("falseColor");
            // wrong color
            FindObjectOfType<Rotator>().Stopspeed();
            StartCoroutine(Waitsecond());
        }
    }

    void setRandomColorfirst()
    {
        int Index1 = UnityEngine.Random.Range(0, 2);
        

        switch (Index1)
        {
            case 0:
                currentColor = "red"; //RED
                sr.color = colorRED;
                break;
            case 1:
                currentColor = "blue"; //BLUE
                sr.color = colorBlue;
                lastindex++;
                break;
        }
        
    }

    void updatecolor()
    {
        int Index1 = UnityEngine.Random.Range(0, 4);
        if (Index1 == lastindex)
        {
            updatecolor();
        }
        else if(Index1 != lastindex)
        {
            lastindex = Index1;
            switch (Index1)
            {
                case 0:
                    currentColor = "red"; //RED
                    sr.color = colorRED;
                    break;
                case 1:
                    currentColor = "blue"; //BLUE
                    sr.color = colorBlue;
                    break;
                case 2:
                    currentColor = "yellow";  //Yellow
                    sr.color = colorYellow;
                    break;
                case 3:
                    currentColor = "green"; //GREEN
                    sr.color = colorGreen;
                    break;
            }
            
        }
    }
}
