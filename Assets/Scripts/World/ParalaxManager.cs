using UnityEngine;

namespace Scripts.World
{
    public class ParalaxManager
    {
        private const float _backCoef = 0.3f;
        private const float _middleCoef = 0.5f;

        private readonly Camera _camera;
        private readonly Transform _backTransform;
        private readonly Transform _middleTransform;

        private readonly Vector3 _backStartPosition;
        private readonly Vector3 _middleStartPosition;
        private readonly Vector3 _cameraStartPositiom;

        public ParalaxManager(Camera camera, Transform backTransform, Transform middleTransform)
        {
            _camera = camera;
            _backTransform = backTransform;
            _middleTransform = middleTransform;
            _backStartPosition = backTransform.position;
            _middleStartPosition = middleTransform.position;
            _cameraStartPositiom = camera.transform.position;
        }

        public void Update()
        {
            _backTransform.position =
                _backStartPosition + (_camera.transform.position - _cameraStartPositiom) * _backCoef;
            _middleTransform.position =
                _middleStartPosition + (_camera.transform.position - _cameraStartPositiom) * _middleCoef;
        }
    }
}