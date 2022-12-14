using UnityEngine;

public class TubeShoot : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    float _distance;
    [SerializeField] Vector2 _xClamp;
    [SerializeField] Vector2 _zClamp;
    [SerializeField] Ball _ballPrefab;
    [SerializeField] Transform _shootPoint;
    [SerializeField] float _forcePower = 20f;
    void Update()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        if (plane.Raycast(ray, out _distance))
        {
            Vector3 point = ray.GetPoint(_distance);
            Vector3 pointClamp = new Vector3(Mathf.Clamp(point.x, _xClamp.x, _xClamp.y), 0f, Mathf.Clamp(point.z, _zClamp.x, _zClamp.y));
            transform.rotation = Quaternion.LookRotation(pointClamp - transform.position);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ball newBall = Instantiate(_ballPrefab, _shootPoint.position, Quaternion.identity);
            newBall.GetComponent<Rigidbody>().AddForce(_shootPoint.forward * _forcePower, ForceMode.Impulse);
        }
    }
}
