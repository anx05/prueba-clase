using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCScript : MonoBehaviour {

    private NavMeshAgent nav;
    private GameObject randomTarget = null;
    [SerializeField] float walkRadius = 2f;

    void Awake () {
        nav = GetComponent<NavMeshAgent>();
	}
	
	void Update () {
        nav.isStopped = false;
        if (randomTarget == null){
            randomTarget = new GameObject();
            randomTarget.AddComponent<DebugDrawSphere>();
            randomTarget.name = gameObject.name + "Destination";
            var ranDestination = Random.insideUnitSphere * walkRadius;
            randomTarget.transform.position = new Vector3(
                transform.position.x + ranDestination.x,
                transform.position.y - Mathf.Abs(ranDestination.y),
                transform.position.z + ranDestination.z
            );
            NavMeshPath randpath = new NavMeshPath();
            if(NavMesh.CalculatePath(transform.position, randomTarget.transform.position, NavMesh.AllAreas, randpath)){
                nav.SetDestination(randomTarget.transform.position);
            }
            else{
                DestroyTarget();
            }
        }
        else if(nav.remainingDistance < 1f && nav.velocity.magnitude < 1f){
            DestroyTarget();
        }
	}

    void DestroyTarget(){
        Destroy(randomTarget, 1f);
        randomTarget = null;
    }
    
    public GameObject FindClosestTarget(List<GameObject> targets)
    {
        NavMeshPath path = new NavMeshPath();
        float shortestDistance = Mathf.Infinity;
        float currentDistance = 0;
        GameObject ClosestTarget = targets[0];

        foreach (GameObject c in targets){
            NavMesh.CalculatePath(transform.position, c.transform.position, NavMesh.AllAreas, path);
            currentDistance = 0;
            for (int i = 1; i < path.corners.Length; ++i){
                currentDistance += Vector3.Distance(path.corners[i - 1], path.corners[i]);
            }
            if (currentDistance < shortestDistance){
                shortestDistance = currentDistance;
                ClosestTarget = c;
            }
        }
        return ClosestTarget;
    }

}



            // NavMeshHit hit;
            // NavMesh.SamplePosition(
            //     randomTarget.transform.position,
            //     out hit,
            //     walkRadius,
            //     NavMesh.AllAreas
            // );
            // randomTarget.transform.position = hit.position;