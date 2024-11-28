using System.Collections;
using UnityEngine;

public abstract class JumpScare : MonoBehaviour
{
    public AudioClip jumpScareSound; 
    protected AudioSource audioSource;
    public float duration;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("Failed to add AudioSource component.");
            }
        }
    }


    public virtual void TriggerJumpScare()
    {
        PlayJumpScareSound();
        StartCoroutine(JumpScareCoroutine());
    }

    protected void PlayJumpScareSound()
    {
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource is not assigned.");
            return;
        }
        if (jumpScareSound == null)
        {
            Debug.LogWarning("Jump scare sound is not assigned.");
            return;
        }

        Debug.Log("Playing jump scare sound.");
        audioSource.PlayOneShot(jumpScareSound);
    }

    protected virtual IEnumerator JumpScareCoroutine()
    {
        yield return new WaitForSeconds(duration);
        EndJumpScare();
    }

    protected virtual void EndJumpScare()
    {
    
    }
}
