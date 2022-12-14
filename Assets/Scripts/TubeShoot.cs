using UnityEngine;

public class TubeShoot : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    float _distance;
    [SerializeField] Vector2 _xClamp;
    [SerializeField] Vector2 _zClamp;
    [SerializeField] Ball _ballPrefab;
    void Update()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        if (plane.Raycast(ray, out _distance))
        {
            Vector3 point = ray.GetPoint(_distance);
            Debug.Log(point);
            Vector3 pointClamp = new Vector3(Mathf.Clamp(point.x, _xClamp.x, _xClamp.y), 0f, Mathf.Clamp(point.z, _zClamp.x, _zClamp.y));
            transform.rotation = Quaternion.LookRotation(pointClamp - transform.position);
        }
        if (Input.GetMouseButtonDown(0))
        {
            //Instantiate();
        }
    }
}
