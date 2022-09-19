using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class SFX_management : MonoBehaviour
{
 [SerializeField] AudioClip audioClip;
    [SerializeField] float volume;
    public void PlaySound(AudioClip sfx, Vector3 position, float volume)
    {
        AudioSource.PlayClipAtPoint(sfx,position,volume);
    }















}
