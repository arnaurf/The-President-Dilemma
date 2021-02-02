using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaaa : MonoBehaviour
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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("n"))
        {
            Anim.SetTrigger("enter");
            Anim2.SetTrigger("enter");
            Anim3.SetTrigger("enter");

            text1.enabled = true;
            text1.SetTrigger("enter");
        }
        if (Input.GetKeyDown("m"))
        {
            Anim.SetTrigger("exit");
            Anim2.SetTrigger("exit");
            Anim3.SetTrigger("exit");

            text1.enabled = false;
            text2.enabled = false;
            text11.SetActive(false);

            barra3.SetActive(true);
            barra4.SetActive(true);
            text11.SetActive(false);

            text22.SetActive(true);
            
        }

        if (Input.GetKeyDown("j"))
        {
            text3.enabled = true;
            text4.enabled = true;
            Anim4.SetTrigger("enter");
            text3.SetTrigger("enter2");

        }
        if (Input.GetKeyDown("k"))
        {
            Anim4.SetTrigger("exit");
        }

        Debug.Log(text3.GetCurrentAnimatorStateInfo(0).normalizedTime);
        if(text1.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            text2.SetTrigger("enter");
        }
        if (text3.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            text4.SetTrigger("enter2");
        }
    }
}
