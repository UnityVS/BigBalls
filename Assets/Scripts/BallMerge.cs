using System.Collections.Generic;
using UnityEngine;

public class BallMerge : MonoBehaviour
{
    [field: SerializeField] public Ball _ball { get; private set; }
    public bool _alreadyEnter { get; private set; }
    List<Ball> _closeBallsList = new List<Ball>();
    float _timer;
    float _maxSearchTimer = 3f;
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            Rigidbody parentRigidbody = other.attachedRigidbody;
            if (parentRigidbody != null)
            {
                if (other.attachedRigidbody.GetComponent<Ball>() is Ball otherBall && other != null)
                {
                    if (!otherBall.GetComponent<ActiveItem>()._trigger.GetComponent<BallMerge>()._alreadyEnter && other != null && otherBall != null)
                    {
                        if (_ball.GetCurrentLevel() == otherBall.GetCurrentLevel() && otherBall != null && otherBall != null)
                        {
                            _alreadyEnter = true;
                            Destroy(other.gameObject);
                            _ball.IncreaseLevel();
                            Invoke(nameof(OpenEnter), 0.005f);
                            return;
                        }
                        else
                        {
                            _closeBallsList.Add(otherBall);
                        }
                    }
                    else if (otherBall.GetComponent<ActiveItem>()._trigger.GetComponent<BallMerge>()._alreadyEnter && other != null)
                    {
                        Destroy(gameObject.GetComponent<Collider>().attachedRigidbody.gameObject);
                    }
                }
            }
        }
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _maxSearchTimer)
        {
            if (_closeBallsList.Count != 0)
            {
                for (int i = 0; i < _closeBallsList.Count; i++)
                {
                    if (_closeBallsList[i].GetCurrentLevel() == _ball.GetCurrentLevel() && _closeBallsList[i] != null)
                    {
                        _alreadyEnter = true;
                        Destroy(_closeBallsList[i].gameObject);
                        _ball.IncreaseLevel();
                        Invoke(nameof(OpenEnter), 0.005f);
                        _timer = 0;
                        return;
                    }
                }
                _timer = 0;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other != null)
        {
            Rigidbody parentRigidbody = other.attachedRigidbody;
            if (parentRigidbody != null)
            {
                if (other.attachedRigidbody.GetComponent<Ball>() is Ball otherBall && other != null)
                {
                    for (int i = 0; i < _closeBallsList.Count; i++)
                    {
                        if (_closeBallsList[i] == otherBall)
                        {
                            _closeBallsList.RemoveAt(i);
                        }
                    }
                }
            }
        }
    }
    void OpenEnter()
    {
        _alreadyEnter = false;
    }
}
