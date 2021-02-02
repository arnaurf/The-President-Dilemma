using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator fade;
    public Animator audio_anim;
    public AudioSource beep;
    public int sceneDestination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
        if (Input.anyKeyDown || Input.GetKeyDown(KeyCode.Mouse0))
        {
            fade.enabled = true;
            audio_anim.enabled = true;
            beep.enabled = true;
        }

        if (fade.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            SceneManager.LoadScene(sceneDestination);
        }
    }
}
