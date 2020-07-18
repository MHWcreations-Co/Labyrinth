using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthVisualization : MonoBehaviour
{
    private GameObject _bigBrother;
    private static GameObject[] _healthIndicators;

    private void Awake()
    {
        _bigBrother = transform.GetChild(1).gameObject;

        for (int i = 0; i < _healthIndicators.Length; i++)
        {
            _healthIndicators[i] = _bigBrother.transform.GetChild(i).gameObject;
        }
    }

    public static void HealthRefresher(int health)
    {
        switch (health)
        {
            case 3:
            {
                _healthIndicators[0].SetActive(true);
                _healthIndicators[1].SetActive(true);
                _healthIndicators[2].SetActive(true);
            }
                break;
            case 2:
            {
                _healthIndicators[0].SetActive(true);
                _healthIndicators[1].SetActive(true);
                _healthIndicators[2].SetActive(false);
            }
                break;
            case 1:
            {
                _healthIndicators[0].SetActive(true);
                _healthIndicators[1].SetActive(false);
                _healthIndicators[2].SetActive(false);
            }
                break;
            case 0:
            {
                _healthIndicators[0].SetActive(false);
                _healthIndicators[1].SetActive(false);
                _healthIndicators[2].SetActive(false);
            }
                break;
        }
    }
}