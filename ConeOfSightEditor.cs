using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (ConeOfSight))]
public class ConeOfSightEditor : Editor {

	void OnSceneGUI(){
        ConeOfSight cone = (ConeOfSight)target;
		Handles.color = Color.white;
		Handles.DrawWireArc (cone.transform.position, Vector3.up, Vector3.forward, 360, cone.ViewRadius);
		Vector3 viewAngleA = cone.DirFromAngle (-cone.ViewAngle / 2f, false);
		Vector3 viewAngleB = cone.DirFromAngle (cone.ViewAngle / 2f, false);

		Handles.DrawLine (cone.transform.position, cone.transform.position + viewAngleA * cone.ViewRadius);
		Handles.DrawLine (cone.transform.position, cone.transform.position + viewAngleB * cone.ViewRadius);

		Handles.color = Color.red;
		foreach (Transform visibleTarget in cone.VisibleTargets){
			Handles.DrawLine (cone.transform.position, visibleTarget.position);
		}
	}
}
