using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SuperTiled2Unity;
public class DoorController : MonoBehaviour
{
    public float DestX;
    public float DestY;
    public string MapName;
    BoxCollider2D m_collider;
    
    // Start is called before the first frame update
    void Start()
    {
        m_collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            FadeController ScreenFade = GameObject.FindObjectOfType<FadeController>();
            StartCoroutine(ScreenFade.Fade(FadeController.FadeDirection.Out)); 
            GameObject Map = GameObject.FindGameObjectWithTag("map");
            
            Destroy(Map);
           Map = Instantiate(Resources.Load("Tiled/" + MapName) as GameObject);
            Map.tag = "map";

           
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Vector3 newPos = new Vector3(DestX, -DestY);
            
            player.transform.SetPositionAndRotation(newPos, player.transform.rotation);
            StartCoroutine(ScreenFade.Fade(FadeController.FadeDirection.In));
        }
    }



}
