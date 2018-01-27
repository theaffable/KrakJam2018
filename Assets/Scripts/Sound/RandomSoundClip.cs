using UnityEngine;

namespace Assets.Scripts.Sound
{
    public class RandomSoundClip : MonoBehaviour
    {
        public AudioClip[] Clips;

        public AudioClip GetClip()
        {
            return  Clips[Random.Range(0, Clips.Length)];
        }
    }
}