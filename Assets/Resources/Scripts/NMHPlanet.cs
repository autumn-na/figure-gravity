using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NMHPlanet : MonoBehaviour
{
    public Sprite[] PlanetSpr;

    public int nType;
    public float fMoveDownSpeed;

    public PolygonCollider2D[] PlanetCol;

    Vector3 CurPlanetVec3;
    Vector3 MoveToPlanetVec3;

	void Start ()
    {
        InitializeObjs();

    }
	
	void Update ()
    {
        MoveDown();
        DestroyPlanet();
    }

    void InitializeObjs()
    {
        fMoveDownSpeed = 1f;
        CurPlanetVec3 = transform.localPosition;
        MoveToPlanetVec3 = new Vector3(CurPlanetVec3.x, -10f, CurPlanetVec3.z);
    }

    void MoveDown()
    {
        CurPlanetVec3 = Vector3.MoveTowards(CurPlanetVec3, MoveToPlanetVec3, fMoveDownSpeed * Time.deltaTime);
        transform.localPosition = CurPlanetVec3;
    }

    void DestroyPlanet()
    {
        if(CurPlanetVec3.y <= -10f)
        {
            Destroy(this.gameObject);
        }
    }
}
