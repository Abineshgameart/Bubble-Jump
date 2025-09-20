using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Private
    [SerializeField] Transform playerPos;  // Player position
    
    
    
    private void FixedUpdate()
    {
        CameraMovement();  // Calling camera movement method
    } 

    private void CameraMovement()
    {
        // setting new camera position only to get the y axis from player position
        Vector3 cameraPos = new Vector3(transform.position.x, playerPos.position.y, transform.position.z);
        
        // for only to move upward, if the player position is higher that current camera position, then excecute
        if (playerPos.position.y > transform.position.y)
        {
            // smoothly transitioning the current position to new upward position
            transform.position = Vector3.Lerp(transform.position, cameraPos, 0.2f); 
        }
    }
}
