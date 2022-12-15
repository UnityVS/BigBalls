using UnityEngine;

public class BallMerge : MonoBehaviour
{
    [field: SerializeField] public Ball _ball { get; private set; }
    public bool _alreadyEnter { get; private set; }
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            Rigidbody parentRigidbody = other.attachedRigidbody;
            if (parentRigidbody != null)
            {
                if (other.attachedRigidbody.GetComponent<Ball>() is Ball otherBall && other != null)
                {
                    if (!otherBall.GetComponent<ActiveItem>()._trigger.GetComponent<BallMerge>()._alreadyEnter && other != null)
                    {
                        if (_ball.GetCurrentLevel() == otherBall.GetCurrentLevel() && otherBall != null)
                        {
                            _alreadyEnter = true;
                            Destroy(other.gameObject);
                            _ball.IncreaseLevel();
                            Invoke(nameof(OpenEnter), 0.005f);
                            return;
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
    void OpenEnter()
    {
        _alreadyEnter = false;
    }
}
