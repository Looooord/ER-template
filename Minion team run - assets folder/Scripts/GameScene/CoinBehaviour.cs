using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour {

    [SerializeField] float rotSpeed = 5f;
    int scoreAmount = 100;
    bool valid = true; 
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed); 
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            Debug.Log("In here"); 
            if (valid)
            GameMaster.IncreaseScore(scoreAmount);
            valid = false; 
            Destroy(gameObject); 
        }
    }
}
