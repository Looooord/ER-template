using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-Vector3.forward * Background.moveSpeed * Time.deltaTime);
        if (transform.position.z < -160) Destroy(gameObject); 
	}
}
