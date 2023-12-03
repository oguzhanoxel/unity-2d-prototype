using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private Scene _currentScene;
    private int _firstEpisodeSceneIndex = 1;
    private int _loseSceneIndex = 4;

    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene();
        if (_scoreText != null )
        {
            _scoreText.text = $"Score: {StaticVariables.TotalScore}";
        }
    }

    public void LoadScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(_currentScene.buildIndex + 1);
    }

    public void IncreaseScore(int score)
    {
        if (_scoreText != null)
        {
            StaticVariables.TotalScore += score;
            _scoreText.text = $"Score: {StaticVariables.TotalScore}";
        }
    }

    public void DecreaseHealth()
    {
        if (StaticVariables.Lives > 0)
        {
            StaticVariables.Lives--;
            SceneManager.LoadScene(_currentScene.buildIndex);
        } else if (StaticVariables.Lives == 0) {
            StaticVariables.LastSceneIndex = _currentScene.buildIndex;
            SceneManager.LoadScene(_loseSceneIndex);
        }
    }

    public void PlayAgain()
    {
        StaticVariables.TotalScore = 0;
        StaticVariables.Lives = 3;
        LoadScene(_firstEpisodeSceneIndex);
    }

    public void Restart()
    {
        StaticVariables.TotalScore = (StaticVariables.TotalScore == 0)? 0 : StaticVariables.TotalScore;
        StaticVariables.Lives = 3;
        LoadScene(StaticVariables.LastSceneIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}