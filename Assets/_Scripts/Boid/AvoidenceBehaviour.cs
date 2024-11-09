using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boid/Behaviour/AvoidenceBehaviour")]
public class AvoidenceBehaviour : BoidBehaviour
{
    public override Vector3 CalculateMovement(BoidAgent a_Agent, List<Transform> a_Neighbours, Boid a_Boid)
    {
        // no neigbours to adjust the movement for
        if (a_Neighbours.Count == 0)
            return Vector3.zero;

        Vector3 l_AvoidenveMove = Vector3.zero;
        int l_NeighboursToAvoid = 0;
        foreach (Transform t in a_Neighbours)
        {
            if (Vector3.SqrMagnitude(t.position - a_Agent.transform.position) < a_Boid.SqrAvoidenceRadMul)
            {
                l_NeighboursToAvoid++;
                l_AvoidenveMove += (a_Agent.transform.position - t.position);
            }
        }
        if (l_NeighboursToAvoid > 0)
            l_AvoidenveMove /= l_NeighboursToAvoid;

        return l_AvoidenveMove;
    }
}
