using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashTextAnimate : MonoBehaviour
{
    // config params
    public GameObject[] flashObjects;
    [SerializeField] public float flashSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FlashObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FlashObject()
    {
        while (Application.isPlaying)
        {
            yield return new WaitForSeconds(flashSpeed);
            foreach (GameObject item in flashObjects)
            {
                item.SetActive(false);
            }
            yield return new WaitForSeconds(flashSpeed);
            foreach (GameObject item in flashObjects)
            {
                item.SetActive(true);
            }
        }
    }
}
