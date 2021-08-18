using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NMHGameMng : MonoBehaviour
{
    public NMHSoundMng SoundMng;
    public GameObject SpaceshipObj;
    public GameObject BackgroundObj;
    NMHSpaceship Spaceship;

    public float fCurDistance = 0;

    private void Awake()
    {
        Screen.SetResolution(540, 540 / 9 * 16, false);
        BackgroundObj.transform.localScale = new Vector3((540f / 100f + 540f / 1000f) * 2, (540f / 9f * 16f / 100f + 540f / 1000f) * 2, 1);
    }

    void Start ()
    {
        InitializeObjs();
        RunBGM();
    }
	
	void Update ()
    {
        CheckDistance();
    }

    void InitializeObjs()
    {
        Spaceship = SpaceshipObj.GetComponent<NMHSpaceship>();
    } 

    void CheckDistance()
    {
        if (Spaceship.bIsAlive)
        {
            fCurDistance += Time.deltaTime * 2;
        }
    }

    void RunBGM()
    {
        if (Singleton.BGM)
        {
            SoundMng.IngameSound[(int)NMHSoundMng.SoundContext.BGM].Play();
        }
    }
}
