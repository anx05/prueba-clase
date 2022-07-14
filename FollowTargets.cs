using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(ConeOfSight))]
public class FollowTargets : MonoBehaviour
{
    NavMeshAgent agent;
    ConeOfSight cone;
    
    

    void Awake() {
        agent = GetComponent<NavMeshAgent>();
        cone = GetComponent<ConeOfSight>();
    }

	void Update () {
        if(cone.VisibleTargets.Count > 0){
            agent.SetDestination(cone.VisibleTargets[0].transform.position);
            
        }
	}
}