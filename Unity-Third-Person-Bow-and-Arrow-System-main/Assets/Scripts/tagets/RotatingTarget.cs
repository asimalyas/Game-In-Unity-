using UnityEngine;

public class RotatingTarget : MonoBehaviour
{
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0f, 100f, 0f); // Degrees per second

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
