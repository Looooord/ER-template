using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideGroundBehaviour : MonoBehaviour {


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = GetComponentInParent<GroundStats>().moveSpeed;
        transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        if (transform.position.z <= -15)
        {
            Destroy(gameObject);
        }
    }
}
