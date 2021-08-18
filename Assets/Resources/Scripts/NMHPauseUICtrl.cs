using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMHPauseUICtrl : MonoBehaviour
{
    public NMHSoundMng SoundMng;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void RestartGame()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;

        if (Singleton.SFX)
        {
            SoundMng.IngameSound[(int)NMHSoundMng.SoundContext.CLICK_BUTTON].Play();
        }
    }
}
