using UnityEngine;

public class Bubble : MonoBehaviour
{
    // Private
    public int playerCollideCount = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerCollideCount > 6)
            {
                playerCollideCount = 0;
                gameObject.SetActive(false);
            }
            playerCollideCount++;
        }
    }
}
