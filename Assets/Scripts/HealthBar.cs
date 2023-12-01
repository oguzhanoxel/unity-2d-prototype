using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image[] _hearts;
    [SerializeField] private Sprite _fullHeart;
    [SerializeField] private Sprite _emptyHeart;

    private int _numOfHealth = 3;

    private void Update()
    {
        for (int i = 0; i < _hearts.Length; i++)
        {
            if(i < StaticVariables.Lives)
            {
                _hearts[i].sprite = _fullHeart;
            } else {
                _hearts[i].sprite = _emptyHeart;
            }

            if (i < _numOfHealth)
            {
                _hearts[i].enabled = true;
            } else {
                _hearts[i].enabled = false;
            }
        }
    }

    public void DecreaseHealth()
    {
        if (StaticVariables.Lives > 0) {
            StaticVariables.Lives--;
        } 
    }
}
