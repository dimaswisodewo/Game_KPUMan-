using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{

    public AudioSource jump;
    public AudioSource dash;
    public AudioSource berhasil;
    public AudioSource background;

    public void PlayJump()
    {
        jump.Play();
    }

    public void PlayDash()
    {
        dash.Play();
    }

    public void PlayBerhasil()
    {
        berhasil.Play();
    }

    public void PlayBackground()
    {
        background.Play();
    }

}
