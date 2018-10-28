using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour {
	public Transform target;
	public float radius; 
	// Use this for initialization
	void Start () {
        target = Camera.main.transform;
    }
	
	// Update is called once per frame
	void Update () {

        transform.LookAt(target);

        //radius = transform.position.x * transform.position.x + transform.position.y * transform.position.y + transform.position.z * transform.position.z; 
        //radius = Mathf.Sqrt (radius);  
        //if (target == null) {
        //          if (GameObject.Find("DomeCamera"))
        //          {

        //	target = GameObject.Find ("DomeCamera").transform;
        //          }
        //}
        //if (target != null) {
        //	transform.LookAt (target);
        //} 

        //      // We want to Enable the Boxcollider because Raycast need collider to intract with object.
        //if (Input.GetMouseButtonUp(0)) {
        //          if (transform.GetComponent<BoxCollider>())
        //          {
        //              transform.GetComponent<BoxCollider>().enabled = true;
        //          }
        //}
    }
}
