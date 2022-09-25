using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip confirm, moveCamera, moveChar, dices, damage, upgrade;
    AudioSource source;

    public void Start(){
        source = GetComponent<AudioSource>();
    }

    public void PlayConfirm(){
        source.PlayOneShot(confirm);
    }

    public void PlayCamera(){
        source.PlayOneShot(moveCamera);
    }

    public void PlayMove(){
        source.PlayOneShot(moveChar);
    }

    public void PlayDices(){
        source.PlayOneShot(dices);
    }

    public void PlayDamage(){
        source.PlayOneShot(damage);
    }

    public void PlayUpgrade(){
        source.PlayOneShot(upgrade);
    }
}
