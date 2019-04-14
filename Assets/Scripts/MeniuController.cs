using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeniuController : MonoBehaviour
{
    public GameObject play;
    public GameObject contr;
    public GameObject cred;
    public GameObject exit;
    public GameObject credT;
    public GameObject contrT;
    public GameObject ret;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Controlls()
    {
        Set(false);
        credT.SetActive(false);
    }

    public void Credits()
    {
        Set(false);
        contrT.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Return()
    {
        Set(true);
    }

    private void Set(bool act)
    {
        play.SetActive(act);
        contr.SetActive(act);
        cred.SetActive(act);
        exit.SetActive(act);
        credT.SetActive(!act);
        contrT.SetActive(!act);
        ret.SetActive(!act);
    }
}
