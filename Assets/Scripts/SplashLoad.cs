using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashLoad : MonoBehaviour
{
    public Image M;
    public Image W;
    public Image Studios;
    public Image Back;
    public Image Background;

    public AudioSource punch1;
    public AudioSource punch2;
    public AudioSource punch3;
    public AudioSource scream1;
    public AudioSource scream2;


    Animation a;

    IEnumerator Start()
    {

        a = M.GetComponent<Animation>();
        a.Play("MSlide");
        punch1.Play();
        yield return new WaitForSeconds(0.5f);

        a = W.GetComponent<Animation>();
        a.Play("WSlide");
        punch2.Play();
        yield return new WaitForSeconds(0.5f);

        a = Studios.GetComponent<Animation>();
        a.Play("StudiosSlide");
        punch3.Play();
        yield return new WaitForSeconds(0.5f);

        /*
        a = Back.GetComponent<Animation>();
        a.Play("TySlide");
        scream1.Play();
        yield return new WaitForSeconds(3f);
        */

        a = Background.GetComponent<Animation>();
        a.Play("MWBackFade");
        //scream2.Play();
        yield return new WaitForSeconds(3f);


        SceneManager.LoadScene("Main Menu");

    }

}
