using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class anim_controller : MonoBehaviour
{
    public Animator Anim;
    public Animator Anim2;
    public Animator Anim3;
    public Animator Anim4;

    public Animator text1;
    public Animator text2;
    public Animator text3;
    public Animator text4;

    public GameObject text11;
    public GameObject text22;

    public GameObject barra3;
    public GameObject barra4;
    public Animator fade;

    public AudioSource typing;
    public Animator music;

    public int sceneDestination;

    // Start is called before the first frame update
    void Start()
    {
        //Start moving black slides. Voting animation starts

        Anim.SetTrigger("enter");
        Anim2.SetTrigger("enter");
        Anim3.SetTrigger("enter");

        text1.enabled = true;
        text1.SetBool("enter", true);

        typing.enabled = true;


    }

    // Update is called once per frame
    void Update()
    {
        //Segunda linia de texto
        if (text1.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && text1.GetCurrentAnimatorStateInfo(0).IsName("textt"))
        {
            text2.SetBool("enter-2", true);
        }

        if (text2.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && text2.GetCurrentAnimatorStateInfo(0).IsName("textt"))
        {
            typing.Pause();
        }
        
        // Desaparece primer texto y sprites
        if (text1.GetCurrentAnimatorStateInfo(0).normalizedTime > 2.55 && text1.GetCurrentAnimatorStateInfo(0).IsName("textt"))
        {
            Anim.SetTrigger("exit");
            Anim2.SetTrigger("exit");
            Anim3.SetTrigger("exit");


            text11.SetActive(false);

            barra3.SetActive(true);
            barra4.SetActive(true);
            text11.SetActive(false);

            text22.SetActive(true);

        }


        //Aparece nuevo texto y sprite
        if (text1.GetCurrentAnimatorStateInfo(0).normalizedTime > 3.2 && text1.GetCurrentAnimatorStateInfo(0).IsName("textt"))
        {
            text1.enabled = false;
            text2.enabled = false;
            text3.enabled = true;
            text4.enabled = true;
            Anim4.SetTrigger("enter");
            text3.SetBool("enter2", true);
            
            typing.Play();

        }

        //Siguiente linia de texto
        if (text3.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && text3.GetCurrentAnimatorStateInfo(0).IsName("textt3"))
        {
            text4.SetBool("enter2-2", true);
        }

        //Cuando acaba el texto -> audio off
        if (text4.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && text4.GetCurrentAnimatorStateInfo(0).IsName("textt4"))
        {
            typing.Pause();
        }

        //Start fade
        if (text3.GetCurrentAnimatorStateInfo(0).normalizedTime > 3.5 && text3.GetCurrentAnimatorStateInfo(0).IsName("textt3"))
        {
            fade.enabled = true;
            music.enabled = true;
        }
        
        //After fade, change scene
        if (text3.GetCurrentAnimatorStateInfo(0).normalizedTime > 4.5 && text3.GetCurrentAnimatorStateInfo(0).IsName("textt3"))
        {
            SceneManager.LoadScene(sceneDestination);
        }

        
    }

}
