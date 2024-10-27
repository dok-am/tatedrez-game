using Tatedrez.View.BoardView;
using UnityEngine;
using VContainer;

namespace Tatedrez.View
{
    [RequireComponent(typeof(Camera))]
    public class CameraBehaviour : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _minimalOrthographicSize = 2.5f;

        [Inject]
        public void InjectDependencies(BoardViewController boardViewController)
        {
            boardViewController.OnBoardBuilded += OnBoardBuilded;
        }

        private void OnBoardBuilded(BoardViewController boardViewController)
        {
            boardViewController.OnBoardBuilded -= OnBoardBuilded;
            RecalculateOrthograthicSize(boardViewController.BoardTotalSize);
        }

        private void RecalculateOrthograthicSize(float boardSize)
        {
            float newOrthoSize = boardSize / 2.0f / _camera.aspect;
            if (newOrthoSize < _minimalOrthographicSize)
                newOrthoSize = _minimalOrthographicSize;

           _camera.orthographicSize = newOrthoSize;
        }

        private void Reset()
        {
            _camera = GetComponent<Camera>();
        }

        private void OnValidate()
        {
            if (_camera == null)
                _camera = GetComponent<Camera>();
        }
    }
}