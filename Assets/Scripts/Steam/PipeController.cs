using System.Collections;
using Assets.Scripts.Sound;
using UnityEngine;

public class PipeController : MonoBehaviour {

	public enum ColliderLocalization {
		Top, Right, Bottom, Left
	}

	public struct AxisInput{
		public float X;
		public float Y;

		public AxisInput(float X, float Y) {
			this.X = X;
			this.Y = Y;
		}
	}

	public int RotationSegments;
	public float ReturnRotationSpeed;
	public float RotationAngle;

	private bool _isRotating = false;
	private float _startRotationZAngle;

	private AudioSource _audioSource;
	private RandomSoundClip _clipManager;

	private ColliderLocalization previous = ColliderLocalization.Top;

	void Start()
	{
		_audioSource = GetComponent<AudioSource>();
		_clipManager = GetComponent<RandomSoundClip>();
		
		_startRotationZAngle = transform.eulerAngles.z;
	}

	void Update()
	{
		TryReturnToZero ();
	}

	private void EmitSounds()
	{
		if (_audioSource.isPlaying) return;
		_audioSource.clip = _clipManager.GetClip();
		print(_audioSource.clip);
		_audioSource.Play();
	}

	IEnumerator Rotate(bool clockwise = true)
	{
		var rotationCoefficient = clockwise ? -1 : 1;
		if (!_isRotating)
		{
			_isRotating = true;
			EmitSounds();
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

	public void TopHit() {
		if (previous == ColliderLocalization.Left) {
			StartCoroutine (Rotate ());
		} else if (previous == ColliderLocalization.Right) {
			StartCoroutine (Rotate (false));
		} else {
			TryReturnToZero ();
		}
		previous = ColliderLocalization.Top;
	}

	public void RightHit() {
		if (previous == ColliderLocalization.Top) {
			StartCoroutine (Rotate ());
		} else if (previous == ColliderLocalization.Bottom) {
			StartCoroutine (Rotate (false));
		} else {
			TryReturnToZero ();
		}
		previous = ColliderLocalization.Right;
	}

	public void BottomHit() {
		if (previous == ColliderLocalization.Right) {
			StartCoroutine (Rotate ());
		} else if (previous == ColliderLocalization.Left) {
			StartCoroutine (Rotate (false));
		} else {
			TryReturnToZero ();
		}
		previous = ColliderLocalization.Bottom;
	}

	public void LeftHit() {
		if (previous == ColliderLocalization.Bottom) {
			StartCoroutine (Rotate ());
		} else if (previous == ColliderLocalization.Top) {
			StartCoroutine (Rotate (false));
		} else {
			TryReturnToZero ();
		}
		previous = ColliderLocalization.Left;
	}

}