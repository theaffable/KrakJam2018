using System.Collections;
using Assets.Scripts.Utils;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Assets.Scripts.Input
{
	public struct AxisInput{
		public float X;
		public float Y;

		public AxisInput(float X, float Y){
			this.X = X;
			this.Y = Y;
		}
	}

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
						new AxisInput(-1,0),
						new AxisInput(0,-1)
					}
				),
				new KeySequence(
					new[]
					{
						new AxisInput(0,-1),
						new AxisInput(1,0)
					}
				),
				new KeySequence(
					new[]
					{
						new AxisInput(1,0),
						new AxisInput(0,1)
					}
				),
				new KeySequence(
					new[]
					{
						
						new AxisInput(0,1),
						new AxisInput(-1,0)
					}
				)
			};

			CounterClockwiseRotationPrerequisites = new List<IRotationPrerequisite> () { 
				new KeySequence(
					new[]
					{
						new AxisInput(0,-1),
						new AxisInput(-1,0)
					}
				),
				new KeySequence(
					new[]
					{
						new AxisInput(1,0),
						new AxisInput(0,-1)
					}
				),
				new KeySequence(
					new[]
					{
						new AxisInput(0,1),
						new AxisInput(1,0)
					}
				),
				new KeySequence(
					new[]
					{
						new AxisInput(-1,0),
						new AxisInput(0,1)
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