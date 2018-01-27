using System.Collections;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Input
{
    public class InputHandler : MonoBehaviour
    {
        public int RotationSegments;
        public float ReturnRotationSpeed;
        public float RotationAngle;
        public IRotationPrerequisite ClockwiseRotationPrerequisite;
        public IRotationPrerequisite CounterClockwiseRotationPrerequisite;

        private bool _isRotating = false;
        private float _startRotationZAngle;
        private Quaternion _currentDestQuaternion;

        void Start()
        {
            _startRotationZAngle = transform.eulerAngles.z;

            ClockwiseRotationPrerequisite = new KeySequence(
                new[]
                {
                    KeyCode.UpArrow,
                    KeyCode.RightArrow,
                    KeyCode.DownArrow,
                    KeyCode.LeftArrow,
                }
            );

            CounterClockwiseRotationPrerequisite = new KeySequence(
                new[]
                {
                    KeyCode.UpArrow,
                    KeyCode.LeftArrow,
                    KeyCode.DownArrow,
                    KeyCode.RightArrow
                }
            );
        }

        void Update()
        {
            DoRotate();
        }

        void DoRotate()
        {
            if (ClockwiseRotationPrerequisite.ConditionMet())
            {
                print("forward");
                StartCoroutine(Rotate());
            }
            else if (CounterClockwiseRotationPrerequisite.ConditionMet())
            {
                print("backward");
                StartCoroutine(Rotate(false));
            }
            else
            {
                TryReturnToZero();
            }
        }

        IEnumerator Rotate(bool clockwise = true)
        {
            var rotationCoefficient = clockwise ? -1 : 1;

            if (!_isRotating)
            {
                _isRotating = true;
                for (int i = 0; i < RotationSegments; i++)
                {
                    transform.Rotate(new Vector3(0f, 0f, rotationCoefficient * RotationAngle / RotationSegments));
                    yield return new WaitForSeconds(1f / RotationSegments);
                }
            }

            _isRotating = false;
        }

        void TryReturnToZero()
        {
            if (!_isRotating && Mathf.Abs(transform.eulerAngles.z - _startRotationZAngle) > 1f)
            {
                transform.Rotate(0f, 0f, ReturnRotationSpeed * Time.deltaTime);
            }
        }
    }
}