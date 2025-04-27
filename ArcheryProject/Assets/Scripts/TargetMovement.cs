using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float speed = 2f;
    private int directionX = 1;
    private bool move = true;
    void Update()
    {
        if (move)
        {
            // Move left and right
            transform.Translate(Vector3.right * speed * directionX * Time.deltaTime);

            if (transform.position.x > 4f || transform.position.x < -4f)
                directionX *= -1;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            move = false;
        }
    } 
}
