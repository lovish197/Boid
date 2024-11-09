using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boid/Behaviour/CohesionBehaviour")]
public class CohesionBehaviour : BoidBehaviour
{
    [SerializeField] float m_SmoothTime = 1f;

    Vector3 m_CurrentVelocity;
    public override Vector3 CalculateMovement(BoidAgent a_Agent, List<Transform> a_Neighbours, Boid a_boid)
    {
        // no neigbours to adjust the movement for
        if(a_Neighbours.Count == 0)
            return Vector3.zero;

        Vector3 l_MoveVelocity = Vector3.zero;
        foreach (Transform t in a_Neighbours)
        {
            l_MoveVelocity += t.position;
        }
        l_MoveVelocity /= a_Neighbours.Count;

        // to create a offset from the agent
        l_MoveVelocity -= a_Agent.transform.position;
        l_MoveVelocity = Vector3.SmoothDamp(a_Agent.transform.forward, l_MoveVelocity, ref m_CurrentVelocity, m_SmoothTime);
        return l_MoveVelocity;
    }
}
