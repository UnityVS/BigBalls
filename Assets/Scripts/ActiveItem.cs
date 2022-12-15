using TMPro;
using UnityEngine;

public class ActiveItem : MonoBehaviour
{
    int _level;
    float _radius;
    [SerializeField] Transform _visualTransform;
    [SerializeField] SphereCollider _collider;
    public SphereCollider _trigger;
    [SerializeField] TextMeshProUGUI _textNumber;

    [ContextMenu("IncreaseLevel")]
    public void IncreaseLevel()
    {
        _level++;
        SetLevel(_level);
    }
    [ContextMenu("DecreaseLevel")]
    public void DecreaseLevel()
    {
        _level--;
        SetLevel(_level);
    }
    public int GetCurrentLevel()
    {
        return _level;
    }
    public void SetLevel(int level)
    {
        _level = level;
        int number = (int)Mathf.Pow(2, _level + 1);
        _textNumber.text = number.ToString("0");
        _radius = Mathf.Lerp(0.4f, 0.7f, _level / 10f);
        Vector3 ballScale = Vector3.one * _radius * 2f;
        _visualTransform.localScale = ballScale;
        //_collider.radius = _radius;
        _trigger.radius = _radius + 0.1f;
    }
}
