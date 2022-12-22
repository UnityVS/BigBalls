using UnityEngine;

public class Ball : ActiveItem
{
    public Rigidbody _rigidbody;
    [SerializeField] BallSettings _ballSettings;
    [SerializeField] Renderer _renderer;
    private void Start()
    {
        SetLevel(Random.Range(0, 5));
    }
    public override void SetLevel(int level)
    {
        base.SetLevel(level);
        _renderer.material = _ballSettings.BallMaterials[level];
    }
}
