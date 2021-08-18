using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMHShootingStar : MonoBehaviour
{
    Vector3 CurVec3;
    Vector3 MoveToVec3;

    public float fMoveDownSpeed;
    public float fRandMoveToX;
    float fRandMoveToY;
   

	void Start ()
    {
        InitializeObjs();
    }

	void Update ()
    {
        MoveDown();
        DestroyShootingStar();
    }

    void InitializeObjs()
    {
        fMoveDownSpeed = 3f;
        CurVec3 = transform.localPosition;
        RandMoveToVec3();
    }

    void MoveDown()
    {
        CurVec3 = Vector3.MoveTowards(CurVec3, MoveToVec3, fMoveDownSpeed * Time.deltaTime);
        transform.localPosition = CurVec3;
    }

    void RandMoveToVec3()
    {
            fRandMoveToY = Random.Range(-4f, -6f);

            if (fRandMoveToY >= -5.5f)
            {
                if (GetComponent<SpriteRenderer>().flipX)
                {
                    fRandMoveToX = Random.Range(3.5f, 4f);
                }
                else
                {
                    fRandMoveToX = Random.Range(-4f, -3.5f);
                }
            }
            else
            {
                if (GetComponent<SpriteRenderer>().flipX)
                {
                    fRandMoveToX = Random.Range(0f, 4f);
                }
                else
                {
                    fRandMoveToX = Random.Range(-4f, 0f);
                }
            }
        MoveToVec3 = new Vector3(fRandMoveToX, fRandMoveToY);
    }

    void DestroyShootingStar()
    {
        if(CurVec3 == MoveToVec3)
        {
            Destroy(this.gameObject);
        }
    }
}
