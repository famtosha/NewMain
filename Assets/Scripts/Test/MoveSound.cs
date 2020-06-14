using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSound : MonoBehaviour
{
    [SerializeField] private List<AudioClip> stepSounds;
    [SerializeField] private float stepCoolDownLeft;
    private AudioSource stepSoundSource;

    public float StepCoolDown = 0.5f;

    private void Start()
    {
        Movement.OnPlayerMove += PlayerStepHandler;
        stepSoundSource = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (stepCoolDownLeft >= 0)
        {
            stepCoolDownLeft -= Time.deltaTime;
        }
    }

    private void PlayerStepHandler()
    {
        if (stepCoolDownLeft <= 0)
        {
            PlayStepSound();
            stepCoolDownLeft = StepCoolDown;
        }
    }

    private void PlayStepSound()
    {
        AudioClip randomClipSound = stepSounds[Random.Range(0, stepSounds.Count)];

        if (stepSoundSource)
        {
            stepSoundSource.PlayOneShot(randomClipSound);
        }
    }
}
