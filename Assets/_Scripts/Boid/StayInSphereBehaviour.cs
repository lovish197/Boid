using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boid/Behaviour/StayInSphereBehaviour")]
public class StayInSphereBehaviour : BoidBehaviour
{
    [SerializeField] Vector3 m_Center = Vector3.zero;
    [SerializeField] float m_Radius = 2f;
    public override Vector3 CalculateMovement(BoidAgent a_Agent, List<Transform> a_Neighbours, Boid a_boid)
    {
        Vector3 l_CenterOffset = m_Center - a_Agent.transform.position;
        float t = l_CenterOffset.magnitude / m_Radius ;
        if (t < 0.9)
        {
            return Vector3.zero;
        }

        return l_CenterOffset * t * t;
    }
}
