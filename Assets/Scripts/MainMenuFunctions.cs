using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuFunctions : MonoBehaviour
{
    public Image critter;
    public Image critterTwo;

    [SerializeField] bool looping = false;


    Animation a;
    /*
    public void Start()
    {
        StartCoroutine(CritterAnimation());
    }*/

    IEnumerator Start()
    {
        do
        {
            yield return new WaitForSeconds(3f);
            a = critter.GetComponent<Animation>();
            a.Play("critterJiggle");
            yield return new WaitForSeconds(4f);

            a = critterTwo.GetComponent<Animation>();
            a.Play("lozanoPeek");
            yield return new WaitForSeconds(2f);
        } while (looping);
        
        
    }



       

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
