using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondMove : MonoBehaviour
{
    private float _speed = 5.0f;
    private float _height = 0.5f;
    private float _startY;

    private void Start()
    {
        _startY = transform.position.y;
        InvokeRepeating("RandomSpeed", 0.1f, 7.0f);
        InvokeRepeating("RandomHeight", 0.1f, 3.0f);
    }

    private void Update()
    {

        float newY = _startY + Mathf.Sin(Time.time * _speed) * _height;

        transform.position = new Vector2(transform.position.x, newY);
    }

    private void RandomSpeed()
    {
        _speed = Random.Range(3.0f, 7.0f);
    }

    private void RandomHeight()
    {
        _height = Random.Range(0.3f, 0.7f);
    }
}
