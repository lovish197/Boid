using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boid/Behaviour/AlignmentBehaviour")]
public class AlignmentBehaviour : BoidBehaviour
{
    public override Vector3 CalculateMovement(BoidAgent a_Agent, List<Transform> a_Neighbours, Boid a_boid)
    {
        // no neigbours to adjust the alignment for
        if (a_Neighbours.Count == 0)
            return a_Agent.transform.forward;

        Vector3 l_Alignment = Vector3.zero;
        foreach (Transform t in a_Neighbours)
        {
            l_Alignment += t.forward;
        }
        l_Alignment /= a_Neighbours.Count;
        return l_Alignment;
    }
}
