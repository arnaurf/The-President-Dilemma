using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectItem : MonoBehaviour
{
    public GameController gameController;
    public Color32 selectedColor;
    public Sprite selected;
    public Sprite unselected;

    private bool click;
    void OnMouseOver()
    {
        this.GetComponent<SpriteRenderer>().color = selectedColor;
        this.GetComponent<SpriteRenderer>().sprite = selected;

        if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            gameController.ShowOptions(this.tag);
        }
    }

    void OnMouseExit()
    {
        click = false;

        this.GetComponent<SpriteRenderer>().sprite = unselected;
        this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }
}
