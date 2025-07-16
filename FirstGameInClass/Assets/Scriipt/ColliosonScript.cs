using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliosonScript : MonoBehaviour
{
    MeshRenderer ar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {


            ar = GetComponent<MeshRenderer>();
            Debug.Log("Your game object" + transform.name + "with the" + collision.transform.name);
            ar.material.color = Color.yellow;
            Destroy(gameObject);
           

        }
    }
}
