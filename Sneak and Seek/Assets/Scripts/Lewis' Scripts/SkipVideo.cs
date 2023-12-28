using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipVideo : MonoBehaviour
{
    [SerializeField] Image radial;

    [SerializeField] GameManager gameManager;

    bool skipping;

    float skip;

    // Start is called before the first frame update
    void Start()
    {
        skipping = false;

        skip = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (skipping == true)
        {
            if (skip < 300)
            {
                skip = skip + 1f;

                radial.fillAmount = skip / 300f; 
            }
            else if (skip >= 100)
            {
                gameManager.SkipVideo();
            }
        }
        else if (skipping == false)
        {
            if (skip > 0)
            {
                skip = skip - 1f;

                radial.fillAmount = skip / 300f;
            }
            else
            {
                skip = 0;

                radial.fillAmount = skip / 300f;
            }
        }
    }

    void OnSkip()
    {
        Debug.Log("Skip has been called");

        skipping = !skipping;
    }
}
