using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    // Private
    [SerializeField] private GameObject GameOverScr;
    [SerializeField] private GameObject StartScr;
    [SerializeField] private PlayerInput PlayerInput;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private TextMeshProUGUI finalScoreTxt;

    private void Awake()
    {
        TimeFreeze(); // Setting time freeze on awake
    }

    // Method fro start btn
    public void StartGame()
    {
        StartScr.SetActive(false);  // deactivating start screen
        TimeUnfreeze();  // Deactivating time freeze
    }

    // method for Game Over
    public void GameOver()
    {
        PlayerInput.DeactivateInput(); // Disabling Player Input system
        TimeFreeze(); // Freezing Time
        GameOverScr.SetActive(true); // acitivating the Game Over screen
        finalScoreTxt.text = "Final Score: " + scoreSystem.currentScore.ToString(); // Setting the final Score
    }


    // Method for reloading the game
    public void ReloadGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // getting Current scene index
        SceneManager.LoadScene(currentSceneIndex); // Reloading the current Scene to restart game
    } 

    // Method to freeze time
    private void TimeFreeze()
    {
        Time.timeScale = 0f; // Freezing time by assing 0 to time scale
    }

    // Method to Unfreeze time
    private void TimeUnfreeze()
    {
        Time.timeScale = 1f; // Unfreezing time by assing 1 to time scale
    }

}
