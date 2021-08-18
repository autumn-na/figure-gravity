using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMHShootingStarMng : MonoBehaviour
{
    public NMHSoundMng SoundMng;
    
    public GameObject ShootingStarPrefab;
    public GameObject ShootingStarParent;

    Vector3 fCreateVec3;

    float fRandCreateX;
    float fRandCreateY;


    public int RandLR;

    void Start ()
    {
        InvokeRepeating("CreateShootingStar", 5f, 7f);
	}
	
	void Update ()
    {
		
	}

    void CreateShootingStar()
    {
        RandCreateVec3();

        GameObject CloneShootingStar = Instantiate(ShootingStarPrefab, fCreateVec3, Quaternion.identity, ShootingStarParent.transform);

        if(RandLR == 0)
        {
            CloneShootingStar.GetComponent<SpriteRenderer>().flipX= true;
        }

        if (Singleton.SFX)
        {
            SoundMng.IngameSound[(int)NMHSoundMng.SoundContext.SHOOTING_STAR].Play();
        }
    }

    public void RemoveShootingStar()
    {
        foreach (Transform child in ShootingStarParent.transform)
        {
            if (child.name != "Planets" && child.name != "ShootingStars")
            {
                Destroy(child.gameObject);

                Debug.Log(child.name);
            }
        }
    }

    void RandCreateVec3()
    {
        fRandCreateY = Random.Range(4f, 6f);

        if (fRandCreateY >= 5.7f)
        {
            fRandCreateX = Random.Range(-4f, 4f);
        }
        else
        {
            RandLR = 1;

            switch(RandLR)
            {
                case 0:
                    fRandCreateX = Random.Range(-4f, -3.5f);
                    break;
                case 1:
                    fRandCreateX = Random.Range(3.5f, 4f);

                    break;
                default:
                    Debug.Log("Shooting Star Create Vec3 is undefined!");
                    break;
            }
        }

        fCreateVec3 = new Vector3(fRandCreateX, fRandCreateY);
    }
}
