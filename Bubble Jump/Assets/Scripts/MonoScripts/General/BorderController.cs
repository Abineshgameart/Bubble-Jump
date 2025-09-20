using UnityEngine;

public class BorderController : MonoBehaviour
{
    // Private
    [SerializeField] private Transform camPos;  // Camera position
    [SerializeField] private Transform bubbleCrasher; // bubbleCrasher position


    private void FixedUpdate()
    {
        Vector3 newPos = new Vector3(camPos.position.x, camPos.position.y, 0);  // new position to omit z axis of camera
        transform.position = newPos; // assiging the new position
        bubbleCrasher.position = newPos; // assigning new position also for the bubble crasher
    }

}
