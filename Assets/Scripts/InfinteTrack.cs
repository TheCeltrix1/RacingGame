using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinteTrack : MonoBehaviour
{
    public GameObject instance;
    public GameObject obstacle;
    private Vector3 _bounds;
    private float _iNeedAVariable;
    private float _obstacleSpawnDistance;
    private static float totalObstacles;
    private float obstacles = 10;
    private bool testicles = true;

    private void Start()
    {
        //totalObstacles = obstacles;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (testicles)
        {
            var track = Instantiate(instance, new Vector3(0, 0, this.transform.position.z + (instance.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Renderer>().bounds.size.z * 15)), this.transform.rotation);
            testicles = false;
        }
        //obstacles = totalObstacles;
        _iNeedAVariable = instance.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Renderer>().bounds.size.z * 25;
        _obstacleSpawnDistance = _iNeedAVariable / obstacles;
        _bounds = this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Renderer>().bounds.size;
        Obstacles();
    }

    private void Obstacles()
    {
        //nya nya object pooling not arsed rn.
        for (int i = 0; i < obstacles; i++)
        {
            Instantiate(obstacle, new Vector3(Random.Range(_bounds.x * 7, -_bounds.x * 7), Random.Range(_bounds.x * 5, -_bounds.x * 5), (this.transform.position.z -( _iNeedAVariable/2)) + (_obstacleSpawnDistance * obstacles)), this.transform.rotation);
            obstacles--;
        }
        //totalObstacles++;
        Destroy(this);
    }
}
