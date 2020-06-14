using System.Collections.Generic;
using UnityEngine;

public class InteractebleItem : MonoBehaviour
{
    protected TextMesh textMesh;
    [SerializeField] private List<AudioClip> useSounds;
    [SerializeField] private AudioSource audioSource;

    protected virtual void Start()
    {
        textMesh = gameObject.GetComponentInChildren<TextMesh>();
    }

    public virtual void UseObj(GameObject interacter)
    {
        PlayUseSound();
    }

    public virtual void TouchObj(bool thing)
    {

    }

    private void PlayUseSound()
    {
        if (useSounds != null)
        {
            if (useSounds.Count > 0)
            {
                AudioClip randomClip = useSounds[Random.Range(0, useSounds.Count)];
                audioSource.PlayOneShot(randomClip);
            }
        }
    }
}
