using UnityEngine;

public class Chunk : MonoBehaviour {

    Ground ground;
    [SerializeField] float boundary; 

    private void Awake()
    {
        ground = GetComponentInParent<Ground>();
    }

    private void Update()
    {
        transform.Translate(Vector3.back * ground.moveSpeed * Time.deltaTime); 
        if (transform.position.z <= boundary)
        {
            GroundGenerator.instance.GenerateNewChunk(); 
            Destroy(gameObject);
        }
    }
}
