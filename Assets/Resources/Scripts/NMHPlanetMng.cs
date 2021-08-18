using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMHPlanetMng : MonoBehaviour
{
    public GameObject PlanetPrefab;
    public GameObject PlanetParent;

    int nBeforeType = 0;
    int nRandType;
    int nRandNum;

    public float fCreatingPlanetTime;
    float fBeforeVecX = 0f;
    float fRandVectorX;
    float fRandVectorY;

    void Start ()
    {
       InvokeRepeating("CreatePlanet", 2f, 6f);
    }
	
	void Update ()
    {
		
	}

    public void RemovePlanet()
    {
        foreach(Transform child in PlanetParent.transform)
        {
            if (child.name != "Planets" && child.name != "ShootingStars")
            {
                Destroy(child.gameObject);

                Debug.Log(child.name);
            }
        }
    }

    void CreatePlanet()
    {
        nRandNum = Random.Range(1, 3);

        for (int i = 0; i < nRandNum; i++)
        {
            nRandType = Random.Range(0, 4);

            for(;;)
            {
                if(nRandType != nBeforeType)
                {

                    RandVector();

                    GameObject ClonePlanet = Instantiate(PlanetPrefab, new Vector3(fRandVectorX, 10f), Quaternion.identity, PlanetParent.transform);
                    ClonePlanet.GetComponent<NMHPlanet>().nType = nRandType;
                    ClonePlanet.GetComponent<SpriteRenderer>().sprite = ClonePlanet.GetComponent<NMHPlanet>().PlanetSpr[nRandType];

                    for (int j = 0; j < 4; j++)
                    {
                        ClonePlanet.GetComponent<NMHPlanet>().PlanetCol[j].enabled = false;
                    }

                    ClonePlanet.GetComponent<NMHPlanet>().PlanetCol[nRandType].enabled = true;

                    nBeforeType = nRandType;

                    break;
                }
                else
                {
                    nRandType = Random.Range(0, 4);
                }
            }
        }
    }

    void RandVector()
    {
        for(;;)
        {
            fRandVectorX = Random.Range(-3f, 3f);

            if(Mathf.Abs(fBeforeVecX - fRandVectorX) >= 1.25f)
            {
                fBeforeVecX = fRandVectorX;
                break;
            }
        }
    }
}
