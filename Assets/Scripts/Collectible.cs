using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int _score = 1;

    private GameManager _gameManager;
    private PlayerController _playerController;

    private void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _playerController.PlayCollectibleAudio();
        _gameManager.IncreaseScore(_score);
        Destroy(gameObject);
    }
}
