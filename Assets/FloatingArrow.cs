using UnityEngine;

public class FloatingArrow : MonoBehaviour
{
    public float floatSpeed = 1.0f;  // Speed of the floating motion
    public float floatHeight = 0.5f; // How high the arrow will float up and down
    private Vector3 startPos;        // Starting position of the arrow

    void Start()
    {
        // Store the starting position of the arrow
        startPos = transform.position;
    }

    void Update()
    {
        // Use Mathf.Sin to create smooth up and down motion
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Apply the new Y position to the arrow, keep the original X and Z position
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
