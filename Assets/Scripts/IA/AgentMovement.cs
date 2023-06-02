using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    public float roamRadius = 10.0f; // radio de movimiento aleatorio
    public float roamTimer = 5.0f; // tiempo máximo de espera en cada punto
    private float timer;

    private NavMeshAgent navAgent;

    private bool isTalking = false;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        timer = roamTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTalking) return;
        timer += Time.deltaTime;

        // Si el agente ha llegado a su destino o ha pasado demasiado tiempo en un punto, asigna un nuevo destino
        if (navAgent.remainingDistance <= navAgent.stoppingDistance || timer >= roamTimer)
        {
            SetNewRandomDestination();
        }
        
    }

    void SetNewRandomDestination()
    {
        // Genera un punto aleatorio dentro del radio de movimiento y lo asigna como el nuevo destino
        Vector3 randomDirection = Random.insideUnitSphere * roamRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, roamRadius, 1);
        Vector3 finalPosition = hit.position;

        navAgent.SetDestination(finalPosition);
        gameObject.GetComponent<Animator>().SetBool("isMoving", true);
        timer = 0;
    }

    public void StopToTalk()
    {
        isTalking = true;
        gameObject.GetComponent<Animator>().SetBool("isMoving", false);
        navAgent.SetDestination(transform.position);
    }

    public void StartWalking()
    {
        isTalking = false;
    }
}