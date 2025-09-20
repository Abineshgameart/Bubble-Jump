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
        TimeFreeze();
    }

    public void StartGame()
    {
        StartScr.SetActive(false);
        TimeUnfreeze();
    }

    public void GameOver()
    {
        PlayerInput.DeactivateInput();
        TimeFreeze();
        GameOverScr.SetActive(true);
        finalScoreTxt.text = "Final Score: " + scoreSystem.currentScore.ToString();
    }

    public void ReloadGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }


    private void TimeFreeze()
    {
        Time.timeScale = 0f;
    }

    private void TimeUnfreeze()
    {
        Time.timeScale = 1f;
    }

}
