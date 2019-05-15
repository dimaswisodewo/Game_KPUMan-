using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 8f;
    
    Transform target;
    NavMeshAgent agent;
    public KPUBuilding kpuBuilding;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        kpuBuilding = FindObjectOfType<KPUBuilding>();
    }

    void Update()
    {
        if (kpuBuilding.winning == true)
        {
            lookRadius = 0f;
        }

        float distance = Vector3.Distance(target.position, transform.position);
        
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
        }
    }
        
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 40f);
    }

}
