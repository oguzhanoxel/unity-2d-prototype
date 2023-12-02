using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameArea : MonoBehaviour
{
    private Scene _scene;
    private HealthBar _healthBar;
    private BoxCollider2D _boxCollider;
    private GameObject _player;

    private float _upperBound;
    private float _lowerBound;
    private float _leftBound;
    private float _rightBound;

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
        _healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _player = GameObject.Find("Player");
    }

    private void Start()
    {
        _upperBound = _boxCollider.bounds.center.y + _boxCollider.bounds.extents.y;
        _lowerBound = _boxCollider.bounds.center.y - _boxCollider.bounds.extents.y;

        _leftBound = _boxCollider.bounds.center.x - _boxCollider.bounds.extents.x;
        _rightBound = _boxCollider.bounds.center.x + _boxCollider.bounds.extents.x;

        Debug.Log($"{_upperBound}, {_lowerBound}, {_leftBound}, {_rightBound}");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 playerPos = _player.transform.position;
            Debug.Log(playerPos);
            if (playerPos.y > _upperBound || playerPos.y < _lowerBound || playerPos.x > _rightBound || playerPos.x < _leftBound)
            {
                _healthBar.DecreaseHealth();
                SceneManager.LoadScene(_scene.buildIndex);
            }
        }
    }
}
