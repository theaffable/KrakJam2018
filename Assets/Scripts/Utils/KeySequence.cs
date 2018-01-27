using UnityEngine;
using UnityInput = UnityEngine.Input;
using Assets.Scripts.Input;

namespace Assets.Scripts.Utils
{
    public class KeySequence : IRotationPrerequisite
    {
        public KeyCode[] Sequence;
        private int _sequenceIndex;
        private bool _isDetected;

        public KeySequence(KeyCode[] seq)
        {
            Sequence = new KeyCode[seq.Length];
            seq.CopyTo(Sequence, 0);
        }

        public bool ConditionMet()
        {
            if (Sequence.Length > 0)
            {
                if (UnityInput.GetKeyDown(Sequence[_sequenceIndex]))
                {
                    _sequenceIndex++;
                }
                else if (UnityInput.anyKeyDown)
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
    }
}