using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinteTrack : MonoBehaviour
{
    public GameObject instance;
    public GameObject obstacle;
    private Vector3 _bounds;
    private float _obstacleSpawnDistance;
    private float obstacles = 10;
    private bool testicles = true;

    private void Start()
    {
        _obstacleSpawnDistance = (instance.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().bounds.size.z / obstacles);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (testicles)
        {
            var track = Instantiate(instance, new Vector3(0, 0, this.transform.position.z + 1000), this.transform.rotation);
            testicles = false;
        }
        Obstacles();
    }

    private void Obstacles()
    {
        _bounds = this.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().bounds.size;
        //nya nya object pooling not arsed rn.
        for (int i = 0; i < obstacles; i++)
        {
            Instantiate(obstacle, new Vector3(Random.Range(_bounds.x, -_bounds.x), Random.Range(_bounds.x, -_bounds.x), this.transform.position.z + (_obstacleSpawnDistance * obstacles)), this.transform.rotation);
            obstacles--;
        }
        Destroy(this);
    }
}
