using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NMHSpaceship : MonoBehaviour
{
    NMHSoundMng SoundMng;
    NMHGameMng GameMng;

    NMHIngameUICtrl IngameUICtrl;

    public GameObject BoosterAnimationPrefab;
    public GameObject DestroySpaceshipPrefab;
    public GameObject ChangeSpaceshipPrefab;

    public Sprite[] SpaceshipSpr;
    public CircleCollider2D[] SpaceshipCol;

    Rigidbody2D SpaceshipRig2D;
    Rigidbody2D PlanetRig2D;

    Vector2 SpaceshipTransVec2;
    Vector2 PlanetTransVec2;

    Vector2 ClickPos;

    Vector2 NormalizedVec2;
    Vector3 ScreenPoint;

    NMHPlanet Planet;

    public Text BoosterText;

    public int nType = (int)SpaceshipType.CIRCLE;

    public bool bisUnstoppable = false;
    public bool bIsAlive = true;

    const float fGravityConstant= 0.1f;
    float fGravityForce;
    float fToPlanetDistance;
    public float fBoosterForce;

    public float fBoosterDelay;
    public bool bIsBoosterDelaying = false;
    float tmpTime;

    public enum SpaceshipType
    {
        CIRCLE,
        RECTANGLE,
        TRIANGLE,
        HEXAGON
    }

	void Start ()
    {
        InitializeObjs();

    }

	void Update ()
    {
        SpaceshipTransVec2 = new Vector2(transform.position.x, transform.position.y);

        TouchEvent();
        ClickEvent();
        BoosterDelay();

    }

    private void LateUpdate()
    {
        SetBoosterPos();
    }

    void InitializeObjs()
    {
        for (int i = 1; i < 4; i++)
        {
            SpaceshipCol[i].enabled = false;
        }

        SpaceshipRig2D = GetComponent<Rigidbody2D>();

        BoosterText = GameObject.Find("BoosterDelay").GetComponent<Text>();
        BoosterText.text = "OK";

        fBoosterForce = 50f;

        fBoosterDelay = 3.0f;
        tmpTime = fBoosterDelay;

        SoundMng = GameObject.Find("SoundMng").GetComponent<NMHSoundMng>();

        GameMng = GameObject.Find("GameMng").GetComponent<NMHGameMng>();

        IngameUICtrl = GameObject.Find("IngameUI").GetComponent<NMHIngameUICtrl>();
    }

    void OnTriggerEnter2D(Collider2D Collider)
    {

        if ((Collider.transform.CompareTag("Planet") || Collider.transform.CompareTag("ShootingStar")) && bisUnstoppable != true)
        {
            DestroySpaceship();
            Debug.Log("Destroy");

            if(Collider.transform.CompareTag("ShootingStar"))
            {
                Destroy(Collider.gameObject);
            }
        }
        else

        {
            SpaceshipRig2D.velocity = new Vector2(0, 0);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Gravity"))
        {
            Planet = collision.GetComponentInParent<NMHPlanet>();

            if (IsPlanetTypeEqual())
            {
                PlanetRig2D = collision.GetComponent<Rigidbody2D>();
                PlanetTransVec2 = new Vector2(collision.GetComponent<Transform>().position.x, collision.GetComponent<Transform>().position.y);

                fToPlanetDistance = Vector2.Distance(PlanetTransVec2, transform.position);

                fGravityForce = fGravityConstant * PlanetRig2D.mass * SpaceshipRig2D.mass / fToPlanetDistance * fToPlanetDistance;

                NormalizedVec2 = (PlanetTransVec2 - SpaceshipTransVec2).normalized;

                if (IsPlanetTypeRed())
                {
                    SpaceshipRig2D.AddForce(-NormalizedVec2 * fGravityForce);
                }
                else
                {
                    SpaceshipRig2D.AddForce(NormalizedVec2 * fGravityForce);
                }
            }
        }
    }

    bool IsPlanetTypeEqual()
    {
        if (Planet.nType == nType)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool IsPlanetTypeRed()
    {
        if(Planet.nType == 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void DestroySpaceship()
    {
        bIsAlive = false;
        this.gameObject.SetActive(false);
        BoosterText.gameObject.SetActive(false);

        CreateDestroyAnimation();

        if (Singleton.SFX)
        {
            SoundMng.IngameSound[(int)NMHSoundMng.SoundContext.EXPLOSION].Play();
        }

        CheckNewRecord();
    }

    void CheckNewRecord()
    {
        if (GameMng.fCurDistance >= Singleton.Score)
        {
            Singleton.Score = Mathf.RoundToInt(GameMng.fCurDistance);

            IngameUICtrl.BestDistance();
        }
    }

    void TouchEvent()
    {
        //int cnt = Input.touchCount;
        
        //if(Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    Vector2 pos = touch.position;

        //    switch(touch.phase)
        //    {
        //        case TouchPhase.Began :
        //            Debug.Log(pos);
        //            break; 
        //    }

        //    SpaceshipRig2D.AddForce((pos - SpaceshipTransVec2).normalized * fBoosterForce);
        //}
    }

    void ClickEvent()
    {
        if (Input.GetMouseButtonDown(1) && !bIsBoosterDelaying)
        {
            ScreenPoint = Input.mousePosition;
            ScreenPoint.z = 10;

            ClickPos = Camera.main.ScreenToWorldPoint(ScreenPoint);

            Debug.Log("x : " + ClickPos.x + "y : " + ClickPos.y);
            SpaceshipRig2D.AddForce((ClickPos - SpaceshipTransVec2).normalized * fBoosterForce);

            bIsBoosterDelaying = true;

            Invoke("SetBoosterOK", fBoosterDelay);

            if (Singleton.SFX)
            {
                SoundMng.IngameSound[(int)NMHSoundMng.SoundContext.BOOSTER].Play();
            }

            CreateBoosterAnimation();
        }
    }

    void BoosterDelay()
    {
        if (bIsBoosterDelaying)
        {
            tmpTime -= Time.deltaTime;

            BoosterText.text = "" + ((int)tmpTime + 1); 
        }
    }

    void SetBoosterOK()
    {
        BoosterText.text = "OK";

        bIsBoosterDelaying = false;
        tmpTime = fBoosterDelay;
    }

    void SetBoosterPos()
    {
        BoosterText.transform.position = transform.position + new Vector3(0, -1f, 0);
    }

    void CreateBoosterAnimation()
    {
        Instantiate(BoosterAnimationPrefab, transform.position + new Vector3(0, -0.5f, 0), Quaternion.identity);
    }

    void CreateDestroyAnimation()
    {
        Instantiate(DestroySpaceshipPrefab, transform.position, Quaternion.identity);
    }

    public void ChangeSpaceshipAnimation()
    {
        Instantiate(ChangeSpaceshipPrefab, transform.position, Quaternion.identity);
    }
}
