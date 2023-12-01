using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void LoadScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void IncreaseScore(int score)
    {
        StaticVariables.TotalScore += score;
        _scoreText.text = $"Score: {StaticVariables.TotalScore}";
    }

    public void Restart()
    {
        StaticVariables.Lives = 3;
        LoadScene(StaticVariables.LastSceneIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}