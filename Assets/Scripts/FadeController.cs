using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeController : MonoBehaviour
{
    public RawImage fadeOutUIImage;
    float fadeSpeed = 1.5f;

    public FadeDirection Out { get; private set; }

    public enum FadeDirection
    {
        In, //Alpha = 1
        Out // Alpha = 0
    }

    // Start is called before the first frame update
    void Start()
    {
        fadeOutUIImage = GetComponent<RawImage>();
    }


    //void OnEnable()
    //{
    //    StartCoroutine(Fade(FadeDirection.Out));
    //}

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator Fade(FadeDirection fadeDirection)
    {
        
        PlayerMover mover = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMover>();
        mover.freeze = true;
        if (fadeDirection == FadeDirection.In)
        {
            for (float i = 0; i <= fadeSpeed; i += Time.deltaTime)
            {

                // set color with i as alpha
                fadeOutUIImage.color = new Color(0, 0, 0, i);
                StartCoroutine(this.Fade(FadeDirection.Out));
                yield return null;
            }
        }
        else
        {
            for (float i = fadeSpeed; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                fadeOutUIImage.color = new Color(0, 0, 0, i);
                mover.freeze = false;
                yield return null;
                
                
            }
        }
    }
}
