using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; // The target vehicle to follow

    [Header("Position Settings")]
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Offset from the target
    public float positionDamping = 5f; // Damping for smooth position transition

    [Header("Rotation Settings")]
    public float rotationDamping = 5f; // Damping for smooth rotation transition

    private void LateUpdate()
    {
        if (target == null)
            return;

        // Smoothly interpolate to the target position
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, positionDamping * Time.deltaTime);

        // Smoothly interpolate to the target rotation
        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationDamping * Time.deltaTime);
    }
}
