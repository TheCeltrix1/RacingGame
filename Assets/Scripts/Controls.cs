using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public string[] controls = new string[6];

    //Velocity
    private Rigidbody _rigidBody;
    private Vector3 _newVelocity;
    public float forwardVelocity = 10;
    private float _augmentedForwardVelocity;
    private bool _speedChange;
    public float turningSpeed;
    public float horizontalVelocity;
    public float verticalVelocity;
    private Vector3 _horizontalAxis;
    private Vector3 _verticalAxis;

    //Rotation
    private Vector3 _newRot;
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
    private float perc1;
    private float perc2;
    private float perc3;
    private float perc4;
    private float lerpTime1 = 1f;
    private float lerpTime2 = 1f;
    private float lerpTime3 = 1f;
    private float lerpTime4 = 1f;
    private float lerpTime5 = 1f;
    private float lerpTime6 = 1f;

    //Camera
    public Camera cammie;
    private GameObject camPos;

    public float score;
    public Particle particle;
    public bool deleteThis;

    void Start()
    {
        camPos = this.transform.GetChild(0).gameObject;
        _augmentedForwardVelocity = 0;
        _otherEnemyInfluence = enemy.GetComponent<Controls>();
        _rigidBody = this.GetComponent<Rigidbody>();

        SetStats();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalAxis = cammie.transform.right;
        _horizontalAxis.Normalize();
        _verticalAxis = cammie.transform.up;
        _verticalAxis.Normalize();

        _newVelocity = new Vector3(0,0,0);
        //movement
        Drift();
        MinusX();
        PlusX();
        PlusY();
        MinusY();

        //speed update
        UpdateSpeed();

        CameraFOV();

        if(StartController.begin) _rigidBody.velocity = _newVelocity;
    }

    void SetStats()
    {
        int reverse = 1;
        if (particle.invert) reverse = -1;

        playerInfluence[0] = particle.cardinalStrength * reverse;
        playerInfluence[1] = particle.cardinalStrength * reverse;
        playerInfluence[2] = particle.cardinalStrength * reverse;
        playerInfluence[3] = particle.cardinalStrength * reverse;
        playerInfluence[4] = particle.rotStrength * reverse;
        playerInfluence[5] = particle.rotStrength * reverse;
    }

    #region movement
    private void Drift()
    {
        if (!Input.GetKey(controls[0]) && currentLerpTime1 > 0)
        {
            currentLerpTime1 -= Time.deltaTime;
            currentLerpTime2 = -currentLerpTime1;
            if (perc1 < 0.05f) perc1 = 0;
            _newVelocity.x = Mathf.Lerp(_newVelocity.x, -turningSpeed, perc1);
        }

        if (!Input.GetKey(controls[1]) && currentLerpTime2 > 0)
        {
            currentLerpTime2 -= Time.deltaTime;
            currentLerpTime1 = -currentLerpTime2;
            if (perc2 < 0.05f) perc2 = 0;
            _newVelocity.x = Mathf.Lerp(_newVelocity.x, turningSpeed, perc2);
        }
        if (!Input.GetKey(controls[2]) && currentLerpTime3 > 0)
        {
            currentLerpTime3 -= Time.deltaTime;
            currentLerpTime4 = -currentLerpTime3;
            if (perc4 < 0.05f) perc4 = 0;
            _newVelocity.y += Mathf.Lerp(_newVelocity.y, turningSpeed, perc4);
        }
        if (!Input.GetKey(controls[3]) && currentLerpTime4 > 0)
        {
            currentLerpTime4 -= Time.deltaTime;
            currentLerpTime3 = -currentLerpTime4;
            if (perc3 < 0.05f) perc3 = 0;
            _newVelocity.y += Mathf.Lerp(_newVelocity.y, -turningSpeed, perc3);
        }
    }

    private void PlusX()
    {
        perc1 = currentLerpTime1 / lerpTime1;

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
            _newVelocity.x = Mathf.Lerp(_newVelocity.x, -turningSpeed, perc1);
        }
    }

    private void MinusX()
    {
        perc2 = currentLerpTime2 / lerpTime2;

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
            _newVelocity.x = Mathf.Lerp(_newVelocity.x, turningSpeed, perc2);
        }
    }

    private void PlusY()
    {
        perc3 = currentLerpTime4 / lerpTime4;

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
            _newVelocity.y = Mathf.Lerp(_newVelocity.y, -turningSpeed, perc3);
        }
    }

    private void MinusY()
    {
        perc4 = currentLerpTime3 / lerpTime3;

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
            _newVelocity.y = Mathf.Lerp(_newVelocity.y, turningSpeed, perc4);
        }
    }

    #endregion

    private void UpdateSpeed()
    {
	if (StartController.begin)
        {
        _newVelocity.z += forwardVelocity;
        _newVelocity = cammie.transform.rotation * _newVelocity;
        _newVelocity += thisEnemyInfluence;

        Vector3 influence = new Vector3(0,0,0);
        //Other Enemy Influence
        if (_newVelocity.x > 0.1f)
        {
            influence += new Vector3(_newVelocity.x * playerInfluence[0], 0, 0);
        }
        else if (_newVelocity.x < -0.1f)
        {
            influence += new Vector3(_newVelocity.x * playerInfluence[1], 0, 0);
        }

        if (_newVelocity.y > 0.1f)
        {
            influence += new Vector3(0, _newVelocity.y * playerInfluence[2], 0);
        }
        else if (_newVelocity.y < -0.1f)
        {
            influence += new Vector3(0, _newVelocity.y * playerInfluence[3], 0);
        }
        _otherEnemyInfluence.thisEnemyInfluence = influence;

        score += Mathf.Abs(_newVelocity.x);
        score += Mathf.Abs(_newVelocity.y);
        _newVelocity.z += _augmentedForwardVelocity;
        }
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
        camPos.transform.localPosition = Vector3.Lerp(new Vector3(0,1.5f,-10), new Vector3(0,1.5f,-5), /*(_newVelocity.z/forwardVelocity)*/0.25f);


        if (StartController.begin)
        {

            if (Input.GetKey(controls[5]))
            {
                _newRot.z = -1;
            }
            else if (Input.GetKey(controls[4]))
            {
                _newRot.z = 1;
            }
            else _newRot.z = 0;

            if (Input.GetKey(_otherEnemyInfluence.controls[5]))
            {
                _newRot.z += -_otherEnemyInfluence.playerInfluence[5];
            }
            else if (Input.GetKey(_otherEnemyInfluence.controls[4]))
            {
                _newRot.z += _otherEnemyInfluence.playerInfluence[5];
            }

            this.transform.Rotate(Vector3.forward, _newRot.z);
        }

    }

}
