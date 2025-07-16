using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;
    private float control;
    private float b;


    [SerializeField] float speed = 3f;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            rb.AddForce(Vector3.up * 6f, ForceMode.VelocityChange);

        }
        control = Input.GetAxis("Horizontal");
        b = Input.GetAxis("Vertical");
        rb.linearVelocity = new Vector3(control * speed, rb.linearVelocity.y, b*speed);
    }
    
    }



