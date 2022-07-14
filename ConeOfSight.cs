using UnityEngine;
using System.Collections.Generic;

public class ConeOfSight : MonoBehaviour
{
    [SerializeField]float timespan;
    [SerializeField]float currentTime=0;
    [Range(0, 360)]
    [SerializeField] float viewAngle = 90f;
    public float ViewAngle{get => viewAngle;}
    [SerializeField] float viewRadius = 5f;
    public float ViewRadius{get => viewRadius;}

    [SerializeField] LayerMask targetMask;
    public LayerMask TargetMask{get => targetMask;}
    [SerializeField] LayerMask obstacleMask;
    public LayerMask ObstacleMask{get => obstacleMask;}

    [SerializeField] List<Transform> visibleTargets = new List<Transform>();
    public List<Transform> VisibleTargets{get => visibleTargets;}
    private void Awake(){
          
    }
    private void Update(){
        CleanTargets();
        
        
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        foreach(Collider c in targetsInViewRadius){
            Transform target = c.transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2f){
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask)){
                    visibleTargets.Add(target);
                    
                }
            }
        }
    }
    void CleanTargets(){
    
        if(visibleTargets.Count>0 ){
            Debug.Log("lista mayor que 0");
            if(currentTime<timespan){
                Debug.Log("contando tiempo");
                currentTime += Time.deltaTime;
                    
            }
            else{
                Debug.Log(visibleTargets.Count);
                visibleTargets.Clear();
                currentTime = 0;
            }
        }
    } 
            
    

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal){
        if (!angleIsGlobal){
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}