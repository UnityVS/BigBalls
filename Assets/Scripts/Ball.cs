using UnityEngine;

public class Ball : ActiveItem
{
    public Rigidbody _rigidbody;
    private void Start()
    {
        SetLevel(Random.Range(0, 5));
    }
}
