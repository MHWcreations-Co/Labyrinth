using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthVisualization : MonoBehaviour
{
    private GameObject _bigBrother;

    private static List<GameObject> _healthIndicators = new List<GameObject>();

//_bigBrother
    private void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            _healthIndicators.Add(gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform
                .GetChild(i).gameObject);
        }
    }

    public static void HealthRefresher(int health)
    {
        for (int i = 0; i < _healthIndicators.Count; i++)
        {
            bool value = i < health;
            _healthIndicators[i].SetActive(value);
        }
    }
}