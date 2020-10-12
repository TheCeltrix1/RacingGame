using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrift : MonoBehaviour
{
    public GameObject target;

    private void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position,target.transform.position,0.5f);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, target.transform.rotation, 0.5f);
    }
}
