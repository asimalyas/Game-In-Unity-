using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowingObject : MonoBehaviour
{
    MeshRenderer ar;
    Rigidbody rb;
    public GameObject target;
    bool hasActivated = false; // To ensure activation happens only once

    void Start()
    {
        ar = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        ar.enabled = false; // Initially disable rendering
        rb.useGravity = false; // Initially disable gravity
    }

    void EnableRenderer()
    {
        ar.enabled = true; // Make the object visible
    }

    void EnableGravity()
    {
        rb.useGravity = true; // Make the object fall
    }

    private void Update()
    {
        if (!hasActivated) // Ensure it activates only once
        {
            float distance = Vector3.Distance( transform.position, target.transform.position);
          
            if (distance < 7f) // Compare distance properly
            {
                Debug.Log("distance is : " + distance);
                hasActivated = true; // Mark as activated
                Invoke("EnableRenderer", 0.1f); // Enable renderer after 2 seconds
                Invoke("EnableGravity", 1.2f); // Enable gravity after 3 seconds
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
