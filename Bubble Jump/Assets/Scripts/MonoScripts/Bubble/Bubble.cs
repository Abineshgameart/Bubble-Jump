using UnityEngine;

public class Bubble : MonoBehaviour
{
    // Private
    public int playerCollideCount = 0;  // To check how many times the player collided

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // to check if the collided object is player or not
        if (collision.gameObject.tag == "Player")
        {
            // the player can able to collide with bubble for 6 time
            if (playerCollideCount > 6)
            {
                playerCollideCount = 0; // Setting player count to 0
                gameObject.SetActive(false);  // setting bubble to active false
            }
            playerCollideCount++;  // increase the player collision count
        }
    }
}
