using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class click_sound : MonoBehaviour
{
    public new AudioSource audio;
    private bool wasOver;
    // Start is called before the first frame update
    void Start()
    {
        wasOver = false;
        audio.Stop();
    }
    void OnMouseEnter()
    {
        audio.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
