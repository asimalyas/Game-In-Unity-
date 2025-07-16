using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] GameObject[] target;
    Rigidbody[] rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = new Rigidbody[target.Length];
        for (int i = 0; i < target.Length; i++) {
            rb[i] = target[i].GetComponent<Rigidbody>();
            rb[i].useGravity = false;
    }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) { 
        for (int i = 0; i < rb.Length; i++)
        {

            rb[i].useGravity = true;
        } }
    }
    
}
