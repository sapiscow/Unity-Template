using UnityEngine;

namespace Sapiscow.UnityTemplate
{
    public class TransformScaler : MonoBehaviour
    {
        [SerializeField] private float _scaleAddition = 0.25f;
        [SerializeField] private float _scaleSpeed = 4f;

        private float _scaleTimer;

        private void OnEnable()
            => _scaleTimer = 0f;

        private void Update()
        {
            _scaleTimer += Time.deltaTime * _scaleSpeed;
            transform.localScale = Vector3.one + Vector3.one * (Mathf.PingPong(_scaleTimer, 1f) * _scaleAddition);
        }
    }
}