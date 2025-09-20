using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    // Private
    [SerializeField] private Transform camPos;  // Camera position
    [SerializeField] private TextMeshProUGUI scoreTxt;  // Score Text in UI

    // Public
    public int currentScore;  // Variable to store current score

    // Update is called once per frame
    void Update()
    {
        currentScore = (int)camPos.position.y; // stting current position by camera position y to represent like the distance as score
        scoreTxt.text = "SCORE: " + currentScore.ToString(); // assigin it to score text
    }
}
