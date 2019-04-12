using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuFunctions : MonoBehaviour
{

    private int randomizer;

    public Image critter;
    public Image critterTwo;
    public Image critterThree;
    public Image critterFour;

    [SerializeField] bool looping = false;
    bool initial = true;

    Animation a, aTwo;

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
            yield return new WaitForSeconds(6f);

            a = critter.GetComponent<Animation>();
            a.Play("critterJiggleBack");
            yield return new WaitForSeconds(1f);

            StartCoroutine(critterAnim());

        } while (looping);
        
        
    }
    
    public IEnumerator critterAnim()
    {
        if(initial) //run this section only once
        {
            aTwo = critterThree.GetComponent<Animation>();
            aTwo.Play("JossEnter");
            yield return new WaitForSeconds(1f);

            aTwo = critterFour.GetComponent<Animation>();
            aTwo.Play("lozanoEnter");
            yield return new WaitForSeconds(4f);

            //aTwo = critterFour.GetComponent<Animation>();
            aTwo.Play("lozanoLeave");
            yield return new WaitForSeconds(0.1f);

            aTwo = critterThree.GetComponent<Animation>();
            aTwo.Play("jossLeave");
            yield return new WaitForSeconds(5f);
        }

        initial = false;

        randomizer = Random.Range(1, 5);
        switch (randomizer)
        {
            case 1:
                aTwo = critterThree.GetComponent<Animation>();
                aTwo.Play("jossSlide");
                yield return new WaitForSeconds(0.5f);

                aTwo = critterFour.GetComponent<Animation>();
                aTwo.Play("lozanoSlide");
                yield return new WaitForSeconds(4f);
                break;
            case 2:
                aTwo = critterThree.GetComponent<Animation>();
                aTwo.Play("jossSlide1");
                yield return new WaitForSeconds(0.5f);

                aTwo = critterFour.GetComponent<Animation>();
                aTwo.Play("lozanoSlide1");
                yield return new WaitForSeconds(4f);

                break;
            case 3:
                aTwo = critterThree.GetComponent<Animation>();
                aTwo.Play("jossSlide2");
                yield return new WaitForSeconds(0.5f);

                aTwo = critterFour.GetComponent<Animation>();
                aTwo.Play("lozanoSlide2");
                yield return new WaitForSeconds(4f);
                break;

            case 4:
                aTwo = critterThree.GetComponent<Animation>();
                aTwo.Play("jossSlide");
                yield return new WaitForSeconds(0.5f);

                aTwo = critterFour.GetComponent<Animation>();
                aTwo.Play("lozanoSlide");
                yield return new WaitForSeconds(2f);

                aTwo = critterThree.GetComponent<Animation>();
                aTwo.Play("jossSlide1");
                yield return new WaitForSeconds(0.5f);

                aTwo = critterFour.GetComponent<Animation>();
                aTwo.Play("lozanoSlide1");
                yield return new WaitForSeconds(4f);
                break;
        }

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
