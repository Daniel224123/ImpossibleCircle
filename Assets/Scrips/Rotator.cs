using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Rotator : MonoBehaviour
{
    //config params
    [SerializeField] double speed = 100;
    [SerializeField] Direction _direction = Direction.Clockwise;
    [SerializeField] TextMeshProUGUI taptoStart = default;

    //state params
    Transform _rotate;
    bool _isRunning = false;



    void Start()
    {
        _rotate = GameObject.FindGameObjectWithTag("circle").transform;


    }
    // Update is called once per frame
    void Update()
    {
        pushtostart();

    }
    //Aktivate the rotation
    private void pushtostart()
    {
        if (_isRunning)
        {
            transform.RotateAround(_rotate.position, Vector3.forward, (float)speed * Time.deltaTime * -(int)_direction);

        }
        else if (!_isRunning)
        {
            if (Input.GetMouseButtonDown(0))
            {

                taptoStart.enabled = false;
                _isRunning = true;
                return;
            }
        }
    }



    public void Changedirection()
    {
        switch (_direction)
        {
            case Direction.Clockwise:
                _direction = Direction.AntiClockwise;
                break;

            case Direction.AntiClockwise:
                _direction = Direction.Clockwise;
                break;
        }
    }
    //Arrow direction
    public enum Direction
    {
        Clockwise = 1,
        AntiClockwise = -1
    }
    public void Upgradespeed()
    {
        if (speed < 170)
        {
            speed += 1;
        }
    }
    public void Stopspeed()
    {
        speed = 0;
    }
 
}
