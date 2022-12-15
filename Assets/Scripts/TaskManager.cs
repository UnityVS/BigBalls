using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _ballsCounts;
    public static TaskManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateUIBallsCount(int count, int maxCount)
    {
        _ballsCounts.text = "Шаров использовано: " + count + "/" + maxCount + " шт";
    }
}
