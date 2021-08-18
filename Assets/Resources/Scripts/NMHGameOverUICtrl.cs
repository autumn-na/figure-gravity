using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NMHGameOverUICtrl : MonoBehaviour
{
    public NMHShootingStarMng ShootingStarMng;
    public NMHPlanetMng PlanetMng;
    public NMHGameMng GameMng;
    public NMHSoundMng SoundMng;

    public GameObject SpaceshipObj;
    public Text BoosterText;

    public Text ScoreText;

    NMHSpaceship Spaceship;
    SpriteRenderer SpaceshipSprRend;

	void Start ()
    {
        InitializeObjs();
    }

	void Update ()
    {
		
	}

    void InitializeObjs()
    {
        Spaceship = SpaceshipObj.GetComponent<NMHSpaceship>();
        SpaceshipSprRend = Spaceship.GetComponent<SpriteRenderer>();
    }

    public void SetScore()
    {
        ScoreText.text = (int)GameMng.fCurDistance + "KM";
    }

    public void RestartGameAtFirst()
    {
        SpaceshipObj.SetActive(true);
        Spaceship.bIsAlive = true;
        Spaceship.transform.localPosition = new Vector3(0, -2f, 0);
        Spaceship.transform.localRotation = Quaternion.identity;

        switch (Singleton.SkinNum)
        {
            case 0:
                SpaceshipSprRend.sprite = Spaceship.SpaceshipSpr[0];
                break;
            case 1:
                SpaceshipSprRend.sprite = Spaceship.SpaceshipSpr[4];
                break;
            case 2:
                SpaceshipSprRend.sprite = Spaceship.SpaceshipSpr[8];
                break;
            default:
                Debug.Log("undefined skin pack!");
                break;
        }


        Spaceship.nType = 0;

        GameMng.fCurDistance = 0f;

        PlanetMng.RemovePlanet();
        ShootingStarMng.RemoveShootingStar();

        BoosterText.gameObject.SetActive(true);

        this.gameObject.SetActive(false);

        if (Singleton.SFX)
        {
            SoundMng.IngameSound[(int)NMHSoundMng.SoundContext.CLICK_BUTTON].Play();
        }
    }

    public void EndGame()
    {
        PlanetMng.RemovePlanet();
        ShootingStarMng.RemoveShootingStar();

        if (Singleton.SFX)
        {
            SoundMng.IngameSound[(int)NMHSoundMng.SoundContext.CLICK_BUTTON].Play();
        }

        Application.LoadLevel(1);
    }
}
