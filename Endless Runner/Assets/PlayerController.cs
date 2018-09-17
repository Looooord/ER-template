using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] float[] lane_Xs = { -1, 0, 1 };
    [SerializeField] float speed = 5; 
    int actualLane = 0;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>(); 
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Left") && actualLane != -1) 
        {
            StartCoroutine(MoveToLeft()); 
        }
	}

    IEnumerator MoveToLeft()
    {
        actualLane--;
        Debug.Log("moving left to actualLane: " + actualLane);

        while (transform.position.x >= lane_Xs[actualLane + 1])
        {
            rb.velocity += Vector3.left * speed * Time.fixedDeltaTime;
            yield return new  WaitForFixedUpdate(); 
        }

        yield break; 
    }

    
}
