using UnityEngine;
using System.Collections;

public class LogoSceneUICtr : MonoBehaviour
{

    // Use this for initialization

    private void Awake()
    {
        Screen.SetResolution(540, 540 / 9 * 16, false);
        PlayerPrefs.DeleteAll();
    }

    void Start()
    {
        Invoke("gotomenu", 2);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void gotomenu()
    {
        Application.LoadLevel(1);
    }
}
