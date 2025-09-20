using UnityEngine;

public class BottomCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // checking for the collision of bubble
        if (collision.gameObject.tag == "Bubble")
        {
            Bubble bubbleScript = collision.gameObject.GetComponent<Bubble>();  // getting bubble script
            bubbleScript.playerCollideCount = 0;  // assigning 0 to player collision count
            collision.gameObject.SetActive(false);  // deactivating bubble that collided
        }
    }
}
