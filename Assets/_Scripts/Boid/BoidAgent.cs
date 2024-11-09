using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidAgent : MonoBehaviour
{
    [SerializeField] Collider m_AgentCollider;

    public Collider AgentCollider { get => m_AgentCollider; }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Move(Vector3 a_Velocity)
    {
        transform.forward = a_Velocity;
        transform.position += a_Velocity * Time.deltaTime;
    }
}
