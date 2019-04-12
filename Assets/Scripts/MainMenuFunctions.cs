using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuFunctions : MonoBehaviour
{
    public Image critter;

    Animation a;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(20f);
        a = critter.GetComponent<Animation>();
        a.Play("critterJiggle");
        


        /* REFERENCING
        a = W.GetComponent<Animation>();
        a.Play("WSlide");
        punch2.Play();
        yield return new WaitForSeconds(0.5f);

        a = Studios.GetComponent<Animation>();
        a.Play("StudiosSlide");
        punch3.Play();
        yield return new WaitForSeconds(0.5f);

        a = Back.GetComponent<Animation>();
        a.Play("TySlide");
        scream1.Play();
        yield return new WaitForSeconds(3f);

        a = Background.GetComponent<Animation>();
        a.Play("MWBackFade");
        scream2.Play();
        yield return new WaitForSeconds(3f);


        SceneManager.LoadScene("Main Menu");

    */

    }
}
