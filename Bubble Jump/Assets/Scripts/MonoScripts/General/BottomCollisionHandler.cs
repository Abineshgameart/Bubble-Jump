using UnityEngine;

public class BottomCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bubble")
        {
            Bubble bubbleScript = collision.gameObject.GetComponent<Bubble>();
            bubbleScript.playerCollideCount = 0;
            collision.gameObject.SetActive(false);
        }
    }
}
