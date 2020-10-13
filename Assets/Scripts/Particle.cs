using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Particle", menuName = "Particle")]
public class Particle : ScriptableObject
{

    public int type;
    public new string name;

    public float cardinalStrength;
    public float rotStrength;
    public bool invert;


}
