using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boid/Behaviour/CompositeBehaviour")]
public class CompositeBehaviour : BoidBehaviour
{
    [SerializeField] BoidBehaviour[] m_AllBehaviours;
    [SerializeField] float[] m_Bias;
    public override Vector3 CalculateMovement(BoidAgent a_Agent, List<Transform> a_Neighbours, Boid a_boid)
    {
        Vector3 l_Move = Vector3.zero;
        for (int i = 0; i < m_AllBehaviours.Length; i++) 
        {
            Vector3 l_PartialMove = m_AllBehaviours[i].CalculateMovement(a_Agent, a_Neighbours, a_boid);

            if (l_PartialMove.sqrMagnitude > m_Bias[i] * m_Bias[i])
            {
                l_PartialMove.Normalize();
                l_PartialMove *= m_Bias[i];
            }
            l_Move += l_PartialMove;
        }
        return l_Move;
    }
}
