using UnityEngine;

public class CanvasInfo : MonoBehaviour
{
    Transform _transform;
    Quaternion _rotateAngle;
    Vector3 _rotateVector = new Vector3(50, -90, 0);
    private void Start()
    {
        _rotateAngle = Quaternion.Euler(_rotateVector);
        _transform = GetComponent<Transform>();
        _transform.rotation = _rotateAngle;
    }
    private void Update()
    {
        _transform.rotation = _rotateAngle;
    }
}
