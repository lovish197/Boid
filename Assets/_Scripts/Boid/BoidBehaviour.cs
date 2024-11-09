using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoidBehaviour : ScriptableObject
{
    public abstract Vector3 CalculateMovement(BoidAgent a_Agent, List<Transform> a_Neighbours, Boid a_boid);
}
