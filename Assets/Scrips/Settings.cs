using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    public GameObject settingsUI;
    public GameObject buttonsUI;
    Transform _rotates;
     int sspeed = 100;
     Direction _directions = Direction.Clockwise;



    // Start is called before the first frame update
    void Start()
    {
        _rotates = GameObject.FindGameObjectWithTag("scircle").transform;
       
    }
    private void Update()
    {
        transform.RotateAround(_rotates.position, Vector3.forward, sspeed * Time.deltaTime * -(int)_directions);
    }


    public void buttonopen()
    {
        settingsUI.SetActive(true);
        buttonsUI.SetActive(false);
        
}
public void buttonclose()
    {
        settingsUI.SetActive(false);
        buttonsUI.SetActive(true);
    }

}
public enum Direction
{
    Clockwise = 1   
        }
