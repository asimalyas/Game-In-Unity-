using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour
{
    public float rotationSpeed = 5f; 
    public float launchForce = 15f;    
    private Rigidbody rb;
    private LineRenderer lr;
    private bool isAiming;
    private bool isFired;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.enabled = false;
        rb.useGravity = false;
        isFired = false;
        isAiming = false;
    }
    private void Update()
    {
        if (isFired) return;
        if (Input.GetMouseButtonDown(0))
        {
            isAiming = true;
            lr.enabled = true;
        }
        if (isAiming)
        {              
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");       
            transform.Rotate(-mouseY * rotationSpeed, mouseX * rotationSpeed, 0);
            Vector3 p0 = transform.position;
            Vector3 p1 = p0 + transform.forward * 10f;
            lr.SetPosition(0, p0);
            lr.SetPosition(1, p1);
        }
        if (isAiming && Input.GetMouseButtonUp(0))
            Fire();
    }
    private void Fire()
    {
        isFired = true;
        isAiming = false;
        lr.enabled = false;

        rb.AddRelativeForce(Vector3.forward*launchForce , ForceMode.VelocityChange);
    }


    void OnCollisionEnter(Collision collision)
    {
        if (!isFired) return;

        if (collision.collider.CompareTag("Target"))
        {
            rb.linearVelocity = Vector3.zero;
            rb.isKinematic = true;


            Vector3 hitPoint = collision.GetContact(0).point;
            Vector3 targetCenter = collision.collider.bounds.center;
            Debug.Log("hitpoint: " + hitPoint);
            Debug.Log("hitpoint: " + targetCenter);

            float distance = Vector3.Distance(hitPoint, targetCenter);

            Debug.Log("distance: " + distance);

            if (distance < 1f)
            {
                Debug.Log("Good hit");
                Invoke("LoadNextLevel", 2f);
            }
            else
            {
                Invoke("againTry", 2f);
            }
        }
        else
        {
            Invoke("againTry", 2f);
        }
    }

void LoadNextLevel()
{
    int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
    else
    {
            SceneManager.LoadScene(0);
            Debug.Log("No more levels");
    }
}

    void againTry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
