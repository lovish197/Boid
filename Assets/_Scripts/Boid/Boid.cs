using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    [SerializeField] BoidAgent m_AgentPrefab;
    [SerializeField] BoidBehaviour m_BoidBehaviour;

    [Range(10, 500)][SerializeField] int m_AgentCountInStart;
    [Range(1f, 100f)][SerializeField] float m_DriveFactor;
    [Range(1f, 100f)][SerializeField] float m_MaxSpeed;
    [Range(1f, 10f)][SerializeField] float m_NeighbourRadius;
    [Range(0f, 5f)][SerializeField] float m_AvoidenceRadiusMul = 2f;

    private List<BoidAgent> m_AllAgents = new List<BoidAgent>(); // for now I am adding it to list will use the object pooling later
    private float m_SqrMaxSpeed;
    private float m_SqrNeighbourRad;
    private float m_SqrAvoidenceRadMul;
    private const float m_AgentDensity = 0.08f;
    public float SqrAvoidenceRadMul => m_SqrAvoidenceRadMul;
    // Start is called before the first frame update
    void Start()
    {
        m_SqrMaxSpeed = m_MaxSpeed * m_MaxSpeed;
        m_SqrNeighbourRad = m_NeighbourRadius * m_NeighbourRadius;
        m_SqrAvoidenceRadMul = m_AvoidenceRadiusMul * m_AvoidenceRadiusMul;

        for (int i = 0; i < m_AgentCountInStart; i++)
        {
            BoidAgent l_Agent = Instantiate(
                m_AgentPrefab,
                Random.insideUnitSphere * m_AgentCountInStart * m_AgentDensity,
                Quaternion.identity,
                transform
                );
            l_Agent.name = $"Agent {i}";
            m_AllAgents.Add(l_Agent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < m_AgentCountInStart; i++)
        {
            List<Transform> l_Neighbours = GetNeignbours(m_AllAgents[i]);

            Vector3 l_MoveVelocity = m_BoidBehaviour.CalculateMovement(m_AllAgents[i], l_Neighbours, this);

            l_MoveVelocity *= m_DriveFactor;
            if (l_MoveVelocity.sqrMagnitude > m_SqrMaxSpeed)
            {
                l_MoveVelocity = l_MoveVelocity.normalized * m_MaxSpeed;
            }
            m_AllAgents[i].Move(l_MoveVelocity);
        }
    }

    private List<Transform> GetNeignbours(BoidAgent a_BoidAgent)
    {
        List<Transform> l_Neighbours = new List<Transform>();
        Collider[] l_NeighbourColliders = Physics.OverlapSphere(a_BoidAgent.transform.position, m_NeighbourRadius);

        for (int i = 0; i < l_NeighbourColliders.Length; i++)
        {
            if (l_NeighbourColliders[i] != a_BoidAgent.AgentCollider)
            {
                l_Neighbours.Add(l_NeighbourColliders[i].transform);
            }
        }
        return l_Neighbours;
    }
}
