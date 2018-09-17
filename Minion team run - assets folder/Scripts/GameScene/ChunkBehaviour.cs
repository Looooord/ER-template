using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkBehaviour : MonoBehaviour {

    GroundStats gs; 

	// Use this for initialization
	void Start () {
        gs = GetComponentInParent<GroundStats>(); 

    }
	
	// Update is called once per frame
	void Update () {
        float moveSpeed = gs.moveSpeed;
        transform.Translate(- Vector3.forward * moveSpeed * Time.deltaTime); 
        if (transform.position.z <= -5) {
            gs.InstantiateNewChunk(); 
            Destroy(gameObject);
        } 
	}
}
