using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinteTrack : MonoBehaviour
{
    public GameObject trackInstance;
    public GameObject speedBoost;
    public GameObject sides;
    public GameObject obstacle;
    private Vector3 _bounds;
    private float _iNeedAVariable;
    private float _obstacleSpawnDistance;
    private static float _totalObstacles;
    private int _obstacles = 10;
    private bool _testicles = true;

    private void Start()
    {
        //_totalObstacles = obstacles;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_testicles)
        {
            var track = Instantiate(trackInstance, new Vector3(0, 0, this.transform.position.z + (trackInstance.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Renderer>().bounds.size.z * 15)), this.transform.rotation);
            _testicles = false;
        }
        //obstacles = totalObstacles;
        _iNeedAVariable = trackInstance.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Renderer>().bounds.size.z * 15;
        _obstacleSpawnDistance = _iNeedAVariable / _obstacles;
        _bounds = this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Renderer>().bounds.size;

        SpeedBoostSpawn();
        Obstacles();
    }

    private void Obstacles()
    {
        //nya nya object pooling not arsed rn.
        int totalObstacles = _obstacles;
        for (int i = 0; i < totalObstacles; i++)
        {
            // need to generate a random number for hypotenuse length for a circle. 20 radius for circle
            float distance = Random.Range(0, 20 - (obstacle.transform.GetComponent<Renderer>().bounds.size.x / 2));
            float angle = Random.Range(0,360);

            Instantiate(obstacle, new Vector3(Mathf.Sin(angle) * distance, Mathf.Cos(angle) * distance, this.transform.position.z + _iNeedAVariable + (_obstacleSpawnDistance * _obstacles)), this.transform.rotation);
            _obstacles--;
        }
        //_totalObstacles++;
        Destroy(this);
    }

    private void SpeedBoostSpawn()
    {
        int penisSauce = (int)Random.Range(1,3);
        for (int i = 0; i < penisSauce; i++)
        {
            int no = (int)Random.Range(0,5);
            float Angle = sides.transform.GetChild(no).transform.rotation.eulerAngles.z;
            GameObject gay = Instantiate(speedBoost, sides.transform.GetChild(no));
            gay.transform.position = new Vector3(gay.transform.position.x, gay.transform.position.y, gay.transform.position.z + Random.Range(-_iNeedAVariable,_iNeedAVariable));
        }
    }
}
