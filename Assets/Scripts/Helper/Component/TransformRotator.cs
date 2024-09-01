using UnityEngine;

namespace Sapiscow.UnityTemplate
{
    public class TransformRotator : MonoBehaviour
    {
        [SerializeField] private Vector3 _rotateSpeed;

        private void Update()
            => transform.Rotate(-_rotateSpeed * Time.deltaTime);
    }
}