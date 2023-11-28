using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private int _sceneIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(_sceneIndex);
    }
}
