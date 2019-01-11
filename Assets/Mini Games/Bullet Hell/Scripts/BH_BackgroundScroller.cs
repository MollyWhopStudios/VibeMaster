using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BH_BackgroundScroller : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.5f;
    Material myMaterial;
    Vector2 offset;
    [SerializeField] bool direction = true;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        if(direction == true)
        {
            offset = new Vector2(backgroundScrollSpeed, 0f);
        }
        else
        {
            offset = new Vector2(0f, backgroundScrollSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
