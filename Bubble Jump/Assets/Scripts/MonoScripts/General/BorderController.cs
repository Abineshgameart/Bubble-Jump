using UnityEngine;

public class BorderController : MonoBehaviour
{
    // Private
    [SerializeField] private Transform camPos;
    [SerializeField] private Transform bubbleCrasher;


    private void FixedUpdate()
    {
        Vector3 newPos = new Vector3(camPos.position.x, camPos.position.y, 0);
        transform.position = newPos;
        bubbleCrasher.position = newPos;
    }

}
