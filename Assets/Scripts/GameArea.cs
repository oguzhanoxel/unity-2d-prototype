using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameArea : MonoBehaviour
{
    private Scene _scene;
    private HealthBar _healthBar;

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
        _healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _healthBar.DecreaseHealth();
        SceneManager.LoadScene(_scene.buildIndex);
    }
}
