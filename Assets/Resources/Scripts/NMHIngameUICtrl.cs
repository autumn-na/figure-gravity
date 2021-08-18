using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NMHIngameUICtrl : MonoBehaviour
{
    public NMHSoundMng SoundMng;
    public GameObject BackgroundObj;
    public NMHGameMng GameMng;
    public GameObject PauseUi;
    GameObject Spaceship;

    public Text BestDistanceText;
    public Text CurDistanceText;

    Renderer BackgroundRenderer;

    Vector2 BackgroundVec2;

    public float fScrollSpeed;

	void Start ()
    {
        initializeObjs();
    }
	
	void Update ()
    {
        scrollBackground();
        ChangeDistance();
    }

    void initializeObjs()
    {
        fScrollSpeed = 1f;

        BackgroundRenderer = BackgroundObj.GetComponent<Renderer>();

        Spaceship = GameObject.Find("Spaceship(Clone)");

        BestDistance();
    }

    void scrollBackground()
    {
        BackgroundVec2 = new Vector2(0, Time.time * fScrollSpeed);
        BackgroundRenderer.material.mainTextureOffset = BackgroundVec2;
    }

    public void changeSpaceship(int _nType)
    {
        Spaceship.GetComponent<SpriteRenderer>().sprite = Spaceship.GetComponent<NMHSpaceship>().SpaceshipSpr[_nType + (Singleton.SkinNum * 4)];
        Spaceship.GetComponent<NMHSpaceship>().nType = _nType;

        for (int i = 0; i < 4; i++)
        {
            Spaceship.GetComponent<NMHSpaceship>().SpaceshipCol[i].enabled = false;
        }

        Spaceship.GetComponent<NMHSpaceship>().SpaceshipCol[_nType].enabled = true;

        if (Singleton.SFX)
        {
            SoundMng.IngameSound[(int)NMHSoundMng.SoundContext.CHANGE_SPACESHIP].Play();
        }

        Spaceship.GetComponent<NMHSpaceship>().ChangeSpaceshipAnimation();
    }

    void ChangeDistance()
    {
        CurDistanceText.text = "NOW : " + (int)GameMng.fCurDistance + "KM";
    } 

    public void BestDistance()
    {
        BestDistanceText.text = "BEST : " + Singleton.Score + "KM";
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseUi.SetActive(true);

        if (Singleton.SFX)
        {
            SoundMng.IngameSound[(int)NMHSoundMng.SoundContext.CLICK_BUTTON].Play();
        }
    }
}
