using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    
    [SerializeField] float speed = 5;
    [SerializeField] float jumpF = 10; 
    [Space]
    [SerializeField] float[] lane_Xs = { -1, 0, 1 };
    [SerializeField] float raycastOffset = 0.6f; 
    int actualLane = 0;
    Rigidbody rb;

    bool jumping; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Left") && actualLane != -1) 
        {
            StartCoroutine(MoveToLeft()); 
        }
        else if (Input.GetButtonDown("Right") && actualLane != 1)
        {
            StartCoroutine(MoveToRight()); 
        }
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump(); 
        }
	}

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, raycastOffset);
    }

    IEnumerator MoveToLeft()
    {
        actualLane--;
        Debug.Log("moving left to actualLane: " + actualLane);

        while (transform.position.x >= lane_Xs[actualLane + 1])
        {
            rb.velocity = Vector3.left * speed * Time.fixedDeltaTime;
            yield return new  WaitForFixedUpdate(); 
        }

        rb.velocity = Vector3.zero; 
        yield break; 
    }

    IEnumerator MoveToRight()
    {
        actualLane++;
        Debug.Log("moving left to actualLane: " + actualLane);

        while (transform.position.x <= lane_Xs[actualLane + 1])
        {
            rb.velocity = Vector3.right * speed * Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        rb.velocity = Vector3.zero;
        yield break;
    }

    void Jump ()
    {
        rb.AddForce(Vector3.up * jumpF); 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * raycastOffset);
    }

}
