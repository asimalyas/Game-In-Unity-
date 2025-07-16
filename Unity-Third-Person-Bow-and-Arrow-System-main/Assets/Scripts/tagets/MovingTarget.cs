using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public float speed = 2f;
    public float range = 5f;
    private bool move = true;
    private float startX;
    private float timeCounter;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        if (move)
        {
            timeCounter += Time.deltaTime * speed;
            float newX = startX + Mathf.Sin(timeCounter) * range;
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
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
