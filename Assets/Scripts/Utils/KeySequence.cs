using UnityEngine;
using UnityInput = UnityEngine.Input;
using Assets.Scripts.Input;

namespace Assets.Scripts.Utils
{
    public class KeySequence : IRotationPrerequisite
    {
		public AxisInput[] Sequence;
        private int _sequenceIndex;
        private bool _isDetected;
		float _tolerance = 0.2f;

		public KeySequence(AxisInput[] seq)
        {
			Sequence = new AxisInput[seq.Length];
            seq.CopyTo(Sequence, 0);
        }

        public bool ConditionMet()
        {
            if (Sequence.Length > 0)
            {
				if (Mathf.Abs(UnityInput.GetAxis("Horizontal")-(Sequence[_sequenceIndex].X))<_tolerance && Mathf.Abs(UnityInput.GetAxis("Vertical")-(Sequence[_sequenceIndex].Y))<_tolerance)
                {
                    _sequenceIndex++;
                }
				else if (AnySeqMatch())
                {
                    _sequenceIndex = 0;
                }

                _isDetected = _sequenceIndex == Sequence.Length;
                if (_isDetected)
                {
                    _sequenceIndex = 0;
                }
            }
            else
            {
                _isDetected = false;
            }

            return _isDetected;
        }
		private bool AnySeqMatch(){
			return (Mathf.Abs (UnityInput.GetAxis ("Horizontal") - (Sequence [0].X)) < _tolerance && Mathf.Abs (UnityInput.GetAxis ("Vertical") - (Sequence [0].Y)) < _tolerance) ||
			(Mathf.Abs (UnityInput.GetAxis ("Horizontal") - (Sequence [1].X)) < _tolerance && Mathf.Abs (UnityInput.GetAxis ("Vertical") - (Sequence [1].Y)) < _tolerance);
		}
    }
}