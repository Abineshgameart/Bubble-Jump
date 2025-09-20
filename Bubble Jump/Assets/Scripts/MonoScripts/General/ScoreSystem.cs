using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    // Private
    [SerializeField] private Transform camPos;
    [SerializeField] private TextMeshProUGUI scoreTxt;

    // Public
    public int currentScore;

    // Update is called once per frame
    void Update()
    {
        currentScore = (int)camPos.position.y;
        scoreTxt.text = "SCORE: " + currentScore.ToString();
    }
}
