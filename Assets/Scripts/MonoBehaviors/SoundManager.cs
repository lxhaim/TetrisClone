using System;
using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviors
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour, IPausable
    {

        [SerializeField]
        private AudioClip _moveAudio;
        [SerializeField]
        private AudioClip _rotateAudio;
        [SerializeField]
        private AudioClip _landAudio;
        [SerializeField]
        private AudioClip _moveFailedAudio;

        [SerializeField]
        private AudioClip _lineClearedAudio;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        #region IPausable Implementation

        public void Pause()
        {
            _audioSource.Pause();
        }

        public void Resume()
        {
            if(!_audioSource.isPlaying)
            {
                _audioSource.UnPause();
            }
        }

        #endregion

        #region Play sound methods

        public void PlayTetrominoLandSound(int numOfMoves)
        {
            _audioSource.PlayOneShot(_landAudio);
        }

        public void PlayTetrominoRotateSound()
        {
            _audioSource.PlayOneShot(_rotateAudio);
        }

        public void PlayTetrominoMoveFailedSound()
        {
            _audioSource.PlayOneShot(_moveFailedAudio);
        }

        public void PlayTetrominoMoveSound()
        {
            _audioSource.PlayOneShot(_moveAudio);
        }

        public void PlayLineClearedSound()
        {
            _audioSource.PlayOneShot(_lineClearedAudio);
        }

        #endregion
    }
}
