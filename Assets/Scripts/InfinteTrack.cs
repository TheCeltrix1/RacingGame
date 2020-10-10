using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinteTrack : MonoBehaviour
{
    public GameObject instance;
    private bool testicles = true;

    private void OnTriggerEnter(Collider other)
    {
        if (testicles)
        {
            var track = Instantiate(instance, new Vector3(0, 0, this.transform.position.z + 1000), this.transform.rotation);
            testicles = false;
        }
        Destroy(this);
    }
}
