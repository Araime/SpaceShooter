using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private GameObject[] _backgroundEffects;
    [SerializeField] private GameObject _background;
    [SerializeField] private float _speed;
    [SerializeField] private float _startPoint;
    [SerializeField] private float _endPoint;

    private void Update()
    {
        if (_backgroundEffects.Length > 0)
        {
            for (int i = 0; i < _backgroundEffects.Length; i++)
            {
                _backgroundEffects[i].transform.Translate(Vector3.down * _speed * Time.deltaTime);

                if (_backgroundEffects[i].transform.position.y <= _endPoint)
                {
                    _backgroundEffects[i].transform.position = new Vector3(0f, _startPoint, 0f);
                }
            }
        }

        _background.transform.Rotate(Vector3.forward * Time.deltaTime);
    }
}
