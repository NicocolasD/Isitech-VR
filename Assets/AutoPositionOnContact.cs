using UnityEngine;

public class AutoPositionOnContact : MonoBehaviour
{
    public Transform objectToPosition;

    public Transform finalPosition;

    public float snapDistance = 0.1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == objectToPosition)
        {
            float distanceToFinal = Vector3.Distance(objectToPosition.position, finalPosition.position);
            if (distanceToFinal <= snapDistance)
            {
                objectToPosition.position = finalPosition.position;
                objectToPosition.rotation = finalPosition.rotation;
            }
        }
    }
}