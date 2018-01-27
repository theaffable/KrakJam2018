using System.Collections;
using Assets.Scripts.Utils;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Assets.Scripts.Input
{
    public class InputHandler : MonoBehaviour
    {
        public int RotationSegments;
        public float ReturnRotationSpeed;
        public float RotationAngle;
		public IList<IRotationPrerequisite> ClockwiseRotationPrerequisites;
		public IList<IRotationPrerequisite> CounterClockwiseRotationPrerequisites;

        private bool _isRotating = false;
        private float _startRotationZAngle;
        private Quaternion _currentDestQuaternion;

        void Start()
        {
            _startRotationZAngle = transform.eulerAngles.z;

			ClockwiseRotationPrerequisites = new List<IRotationPrerequisite>() { 
				new KeySequence(
					new[]
					{
						KeyCode.LeftArrow,
						KeyCode.UpArrow
					}
				),
				new KeySequence(
					new[]
					{
						KeyCode.UpArrow,
						KeyCode.RightArrow
					}
				),
				new KeySequence(
					new[]
					{
						KeyCode.RightArrow,
						KeyCode.DownArrow
					}
				),
				new KeySequence(
					new[]
					{
						
						KeyCode.DownArrow,
						KeyCode.LeftArrow
					}
				)
			};

			CounterClockwiseRotationPrerequisites = new List<IRotationPrerequisite> () { 
				new KeySequence(
					new[]
					{
						KeyCode.UpArrow,
						KeyCode.LeftArrow
					}
				),
				new KeySequence(
					new[]
					{
						KeyCode.RightArrow,
						KeyCode.UpArrow
					}
				),
				new KeySequence(
					new[]
					{
						KeyCode.DownArrow,
						KeyCode.RightArrow
					}
				),
				new KeySequence(
					new[]
					{
						KeyCode.LeftArrow,
						KeyCode.DownArrow
					}
				)
			};
        }

        void Update()
        {
            DoRotate();
        }

        void DoRotate()
        {
			if (ClockwiseRotationPrerequisites.Any(p => p.ConditionMet()))
            {
                StartCoroutine(Rotate());
            }
			else if (CounterClockwiseRotationPrerequisites.Any(p => p.ConditionMet()))
            {
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
            if (Mathf.Abs(transform.eulerAngles.z - _startRotationZAngle) > 1f)
            {
                transform.Rotate(0f, 0f, ReturnRotationSpeed * Time.deltaTime);
            }
        }
    }
}