using System.Collections.Generic;
using UnityEngine;

public class FireZone : MonoBehaviour
{
    List<Collider> _listOfColliderObjects = new List<Collider>();
    string _tagOfMainBox = "LevelBox";
    private void Start()
    {
        Collider[] listOfColliderObjectsInScene;
        listOfColliderObjectsInScene = FindObjectsOfType<Collider>();
        for (int i = 0; i < listOfColliderObjectsInScene.Length; i++)
        {
            if (!listOfColliderObjectsInScene[i].CompareTag(_tagOfMainBox))
            {
                _listOfColliderObjects.Add(listOfColliderObjectsInScene[i]);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_listOfColliderObjects.Contains(other))
        {
            _listOfColliderObjects.Remove(other);
            Destroy(other.gameObject);
        }
        else
        {
            _listOfColliderObjects.Add(other);
        }
    }
}
