using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMHSpaceshipMng : MonoBehaviour
{
    public NMHGameOverUICtrl GameOverUI;
    public NMHGameMng GameMng;
    public GameObject SpaceshipParent;
    public GameObject SpaceshipPrefab;
    GameObject CloneSpaceship;
    SpriteRenderer CloneSpaceshipSprRend;
    void Awake ()
    {
        CreateSpaceship();
    }
	
	void Update ()
    {
        CheckIsSpaceshipAlive();
    }

    void CreateSpaceship()
    {
        CloneSpaceship = Instantiate(SpaceshipPrefab, new Vector3(0, -2f), Quaternion.identity, SpaceshipParent.transform);
        GameMng.SpaceshipObj = CloneSpaceship;
        GameOverUI.SpaceshipObj = CloneSpaceship;

        CloneSpaceshipSprRend = CloneSpaceship.GetComponent<SpriteRenderer>();

        switch (Singleton.SkinNum)
        {
            case 0:
                CloneSpaceshipSprRend.sprite = CloneSpaceship.GetComponent<NMHSpaceship>().SpaceshipSpr[0];
                break;
            case 1:
                CloneSpaceshipSprRend.sprite = CloneSpaceship.GetComponent<NMHSpaceship>().SpaceshipSpr[4];
                break;
            case 2:
                CloneSpaceshipSprRend.sprite = CloneSpaceship.GetComponent<NMHSpaceship>().SpaceshipSpr[8];
                break;
            default:
                Debug.Log("undefined skin pack!");
                break;
        }
    }

    void CheckIsSpaceshipAlive()
    {
        if(CloneSpaceship.GetComponent<NMHSpaceship>().bIsAlive)
        {

        }
        else
        {
            GameOverUI.gameObject.SetActive(true);
            GameOverUI.SetScore();
        }
    }
}
