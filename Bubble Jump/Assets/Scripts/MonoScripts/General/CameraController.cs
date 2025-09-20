using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Private
    [SerializeField] Transform playerPos;
    
    
    
    private void FixedUpdate()
    {
        CameraMovement();
    }

    private void CameraMovement()
    {
        Vector3 cameraPos = new Vector3(transform.position.x, playerPos.position.y, transform.position.z);
        if (playerPos.position.y > transform.position.y)
        {
            transform.position = Vector3.Lerp(transform.position, cameraPos, 0.2f);
        }
    }
}
