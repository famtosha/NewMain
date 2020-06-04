using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class MoveSound : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _stepSounds;
    [SerializeField] private AudioSource _stepSoundSource;
    [SerializeField] private float _stepCoolDownLeft;
    public float StepCoolDown = 0.5f;

    private void Start()
    {
        Movement.OnPlayerMove += PlayerStepHandler;
    }

    private void Update()
    {
        if (_stepCoolDownLeft >= 0)
        {
            _stepCoolDownLeft -= Time.deltaTime;
        }
    }

    private void PlayerStepHandler()
    {
        if (_stepCoolDownLeft <= 0)
        {
            PlayStepSound();
            _stepCoolDownLeft = StepCoolDown;
        }
    }

    private void PlayStepSound()
    {
        AudioClip randomClipSound = _stepSounds[Random.Range(0, _stepSounds.Count)];
        _stepSoundSource.PlayOneShot(randomClipSound);
    }
}
