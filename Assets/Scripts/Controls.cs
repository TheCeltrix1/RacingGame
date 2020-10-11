﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public string[] controls = new string[6];

    //Velocity
    private Rigidbody _rigidBody;
    private Vector3 _newVelocity;
    private Vector3 _newRot;
    public float forwardVelocity = 10;
    private float _augmentedForwardVelocity;
    private bool _speedChange;
    public float turningSpeed;
    public float rotSpeed;

    //Enemy Influence Variables.
    public GameObject enemy;
    public float[] playerInfluence = new float[6];
    private Controls _otherEnemyInfluence;
    public Vector3 thisEnemyInfluence;
    public Vector3 thisEnemyCamInfluence;

    //Controls Variables
    private float currentLerpTime1;
    private float currentLerpTime2;
    private float currentLerpTime3;
    private float currentLerpTime4;
    private float currentLerpTime5;
    private float currentLerpTime6;
    private float lerpTime1 = 1f;
    private float lerpTime2 = 1f;
    private float lerpTime3 = 1f;
    private float lerpTime4 = 1f;
    private float lerpTime5 = 1f;
    private float lerpTime6 = 1f;

    //Camera
    public Camera cammie;
    private GameObject camPos;

    void Start()
    {
        camPos = this.transform.GetChild(0).gameObject;
        _augmentedForwardVelocity = 0;
        _otherEnemyInfluence = enemy.GetComponent<Controls>();
        _rigidBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _newVelocity = new Vector3(0,0,0);
        //movement
        PlusX();
        MinusX();
        PlusY();
        MinusY();

        RotLeft();
        RotRight();
        //speed update
        UpdateSpeed();

        CameraFOV();
        _rigidBody.velocity = _newVelocity;
    }

    #region movement
    private void PlusX()
    {
        float perc = currentLerpTime1 / lerpTime1;

        if (currentLerpTime1 > lerpTime1)
        {
            currentLerpTime1 = lerpTime1;
        }

        if (Input.GetKeyDown(controls[0]))
        {
            currentLerpTime1 = 0f;
        }

        if (Input.GetKey(controls[0]))
        {
            currentLerpTime1 += Time.deltaTime;
            _newVelocity.x = Mathf.Lerp(_newVelocity.x, -turningSpeed, perc);
        }
        else if (currentLerpTime1 > 0)
        {
            currentLerpTime1 -= Time.deltaTime;
            currentLerpTime2 = -currentLerpTime1;
            if (perc < 0.05f) perc = 0;
            _newVelocity.x = Mathf.Lerp(_newVelocity.x, -turningSpeed, perc);
        }
        else if (currentLerpTime1 < 0) currentLerpTime1 = 0;
    }

    private void MinusX()
    {
        float perc = currentLerpTime2 / lerpTime2;

        if (currentLerpTime2 > lerpTime2)
        {
            currentLerpTime2 = lerpTime2;
        }

        if (Input.GetKeyDown(controls[1]))
        {
            currentLerpTime2 = 0f;
        }

        if (Input.GetKey(controls[1]))
        {
            currentLerpTime2 += Time.deltaTime;
            _newVelocity.x = Mathf.Lerp(_newVelocity.x, turningSpeed, perc);
        }
        else if (currentLerpTime2 > 0)
        {
            currentLerpTime2 -= Time.deltaTime;
            currentLerpTime1 = -currentLerpTime2;
            if (perc < 0.05f) perc = 0;
            _newVelocity.x = Mathf.Lerp(_newVelocity.x, turningSpeed, perc);
        }
        else if (currentLerpTime2 < 0) currentLerpTime2 = 0;
    }

    private void PlusY()
    {
        float perc = currentLerpTime4 / lerpTime4;

        if (currentLerpTime4 > lerpTime4)
        {
            currentLerpTime4 = lerpTime4;
        }

        if (Input.GetKeyDown(controls[3]))
        {
            currentLerpTime4 = 0f;
        }

        if (Input.GetKey(controls[3]))
        {
            currentLerpTime4 += Time.deltaTime;
            _newVelocity.y = Mathf.Lerp(_newVelocity.y, -turningSpeed, perc);
        }
        else if (currentLerpTime4 > 0)
        {
            currentLerpTime4 -= Time.deltaTime;
            currentLerpTime3 = -currentLerpTime4;
            if (perc < 0.05f) perc = 0;
            _newVelocity.y = Mathf.Lerp(_newVelocity.y, -turningSpeed, perc);
        }
        else if (currentLerpTime4 < 0) currentLerpTime4 = 0;
    }

    private void MinusY()
    {
        float perc = currentLerpTime3 / lerpTime3;

        if (currentLerpTime3 > lerpTime3)
        {
            currentLerpTime3 = lerpTime3;
        }

        if (Input.GetKeyDown(controls[2]))
        {
            currentLerpTime3 = 0f;
        }

        if (Input.GetKey(controls[2]))
        {
            currentLerpTime3 += Time.deltaTime;
            _newVelocity.y = Mathf.Lerp(_newVelocity.y, turningSpeed, perc);
        }
        else if (currentLerpTime3 > 0)
        {
            currentLerpTime3 -= Time.deltaTime;
            currentLerpTime4 = -currentLerpTime3;
            if (perc < 0.05f) perc = 0;
            _newVelocity.y = Mathf.Lerp(_newVelocity.y, turningSpeed, perc);
        }
        else if (currentLerpTime3 < 0) currentLerpTime3 = 0;
    }

    private void RotLeft()
    {
        float perc = currentLerpTime5 / lerpTime5;

        if (currentLerpTime5 > lerpTime5)
        {
            currentLerpTime5 = lerpTime5;
        }

        if (Input.GetKeyDown(controls[5]))
        {
            currentLerpTime5 = 0f;
        }

        if (Input.GetKey(controls[5]))
        {
            currentLerpTime5 += Time.deltaTime;
            _newRot.z = Mathf.Lerp(_newRot.z, -rotSpeed, perc);
        }
        else if (currentLerpTime5 > 0)
        {
            currentLerpTime5 -= Time.deltaTime;
            currentLerpTime6 = -currentLerpTime5;
            if (perc < 0.05f) perc = 0;
            _newRot.z = Mathf.Lerp(_newRot.z, -rotSpeed, perc);
        }
        else if (currentLerpTime5 < 0) currentLerpTime5 = 0;
    }

    private void RotRight()
    {
        float perc = currentLerpTime6 / lerpTime6;

        if (currentLerpTime6 > lerpTime6)
        {
            currentLerpTime6 = lerpTime6;
        }

        if (Input.GetKeyDown(controls[4]))
        {
            currentLerpTime5 = 0f;
        }

        if (Input.GetKey(controls[4]))
        {
            currentLerpTime6 += Time.deltaTime;
            _newRot.z = Mathf.Lerp(_newRot.z, rotSpeed, perc);
        }
        else if (currentLerpTime6 > 0)
        {
            currentLerpTime6 -= Time.deltaTime;
            currentLerpTime5 = -currentLerpTime6;
            if (perc < 0.05f) perc = 0;
            _newRot.z = Mathf.Lerp(_newRot.z, rotSpeed, perc);
        }
        else if (currentLerpTime6 < 0) currentLerpTime6 = 0;
    }


    #endregion

    private void UpdateSpeed()
    {
        _newVelocity.z += forwardVelocity;
        _newVelocity += thisEnemyInfluence;
        _otherEnemyInfluence.thisEnemyInfluence = new Vector3(_newVelocity.x * playerInfluence[0], _newVelocity.y * playerInfluence[2], 0);
        _newVelocity.z += _augmentedForwardVelocity;
    }

    #region Triggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpeedBoost") {

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "SpeedBoost")
        {
            _speedChange = true;
            _augmentedForwardVelocity = Mathf.Lerp(_augmentedForwardVelocity,forwardVelocity * 15f, 0.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SpeedBoost")
        {
            _speedChange = false;
            _augmentedForwardVelocity = 0;
        }
    }
    #endregion

    private void CameraFOV()
    {
        cammie.fieldOfView = Mathf.Lerp(60,120, (_newVelocity.z / forwardVelocity));
        camPos.transform.localPosition = Vector3.Lerp(new Vector3(0,1.5f,-10), new Vector3(0,1.5f,-5), (_newVelocity.z/forwardVelocity));

        _newRot += thisEnemyCamInfluence;
        _otherEnemyInfluence.thisEnemyCamInfluence = new Vector3(0,0,_newRot.z * playerInfluence[5]);

        cammie.transform.Rotate(Vector3.forward, _newRot.z * Time.deltaTime);
        // _otherEnemyInfluence.thisEnemyInfluence = new Vector3(_newVelocity.x * playerInfluence[0], _newVelocity.y * playerInfluence[2], 0);
    }



}