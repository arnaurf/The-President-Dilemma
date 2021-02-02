using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectDialoguePhone : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public CanvasGroup phoneCanvas;
    public Text phoneQ;
    public Text phoneA1;
    public Text phoneA2;
    public GameController gameController;
    public Image panelA;
    public Image panelB;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameController.phoneCallStatus == 0)
        {
            if (this.tag == "A")
            {
                phoneQ.text = gameController.currentPhoneEvent.Q2;
                phoneA1.text = gameController.currentPhoneEvent.A3;
                phoneA2.text = gameController.currentPhoneEvent.A4;
            }
            if (this.tag == "B")
            {
                phoneQ.text = gameController.currentPhoneEvent.Q3;
                phoneA1.text = gameController.currentPhoneEvent.A5;
                phoneA2.text = gameController.currentPhoneEvent.A6;
            }

            gameController.phoneCallStatus = 1;
        }
        else if (gameController.phoneCallStatus == 1)
        {
            phoneA2.text = "Hang up the phone";
            phoneA1.text = "";
            panelA.enabled = false;

            if (this.tag == "A")
            {
                if (phoneQ.text == gameController.currentPhoneEvent.Q2)
                {
                    if (gameController.currentPhoneEvent.R1 == "NULL")
                        phoneQ.text = "They hanged up the phone";
                    else
                        phoneQ.text = gameController.currentPhoneEvent.R1;

                    gameController.setSociety(gameController.getSociety() + gameController.currentPhoneEvent.society1 + gameController.extraSociety);
                    gameController.setCompanies(gameController.getCompanies() + gameController.currentPhoneEvent.company1 + gameController.extraCompanies);
                    gameController.setArmy(gameController.getArmy() + gameController.currentPhoneEvent.army1 + gameController.extraArmy);
                    gameController.setClimate(gameController.getClimate() + gameController.currentPhoneEvent.climate1 + gameController.extraClimate);
                    gameController.setInternational(gameController.getInternational() + gameController.currentPhoneEvent.international1 + gameController.extraInternational);

                    gameController.phoneOptionNews = 1;
                }
                else if(phoneQ.text == gameController.currentPhoneEvent.Q3)
                {
                    if (gameController.currentPhoneEvent.R3 == "NULL")
                        phoneQ.text = "They hanged up the phone";
                    else
                        phoneQ.text = gameController.currentPhoneEvent.R3;

                    gameController.setSociety(gameController.getSociety() + gameController.currentPhoneEvent.society3 + gameController.extraSociety);
                    gameController.setCompanies(gameController.getCompanies() + gameController.currentPhoneEvent.company3 + gameController.extraCompanies);
                    gameController.setArmy(gameController.getArmy() + gameController.currentPhoneEvent.army3 + gameController.extraArmy);
                    gameController.setClimate(gameController.getClimate() + gameController.currentPhoneEvent.climate3 + gameController.extraClimate);
                    gameController.setInternational(gameController.getInternational() + gameController.currentPhoneEvent.international3 + gameController.extraInternational);

                    gameController.phoneOptionNews = 3;
                }
            }
            if (this.tag == "B")
            {
                if (phoneQ.text == gameController.currentPhoneEvent.Q2)
                {
                    if (gameController.currentPhoneEvent.R2 == "NULL")
                        phoneQ.text = "They hanged up the phone";
                    else
                        phoneQ.text = gameController.currentPhoneEvent.R2;

                    gameController.setSociety(gameController.getSociety() + gameController.currentPhoneEvent.society2 + gameController.extraSociety);
                    gameController.setCompanies(gameController.getCompanies() + gameController.currentPhoneEvent.company2 + gameController.extraCompanies);
                    gameController.setArmy(gameController.getArmy() + gameController.currentPhoneEvent.army2 + gameController.extraArmy);
                    gameController.setClimate(gameController.getClimate() + gameController.currentPhoneEvent.climate2 + gameController.extraClimate);
                    gameController.setInternational(gameController.getInternational() + gameController.currentPhoneEvent.international2 + gameController.extraInternational);

                    gameController.phoneOptionNews = 2;
                }
                else if (phoneQ.text == gameController.currentPhoneEvent.Q3)
                {
                    if (gameController.currentPhoneEvent.R4 == "NULL")
                        phoneQ.text = "They hanged up the phone";
                    else
                        phoneQ.text = gameController.currentPhoneEvent.R4;

                    gameController.setSociety(gameController.getSociety() + gameController.currentPhoneEvent.society4 + gameController.extraSociety);
                    gameController.setCompanies(gameController.getCompanies() + gameController.currentPhoneEvent.company4 + gameController.extraCompanies);
                    gameController.setArmy(gameController.getArmy() + gameController.currentPhoneEvent.army4 + gameController.extraArmy);
                    gameController.setClimate(gameController.getClimate() + gameController.currentPhoneEvent.climate4 + gameController.extraClimate);
                    gameController.setInternational(gameController.getInternational() + gameController.currentPhoneEvent.international4 + gameController.extraInternational);

                    gameController.phoneOptionNews = 4;
                }
            }
            gameController.phoneCallStatus = 2;
        }
        else if (gameController.phoneCallStatus == 2)
        {
            panelA.enabled = true;
            phoneCanvas.alpha = 0;
            phoneCanvas.interactable = false;
            phoneCanvas.blocksRaycasts = false;

            gameController.phoneCallStatus = 0;



            gameController.nextTurn();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Color32 col = this.GetComponentInParent<Image>().color;
        this.GetComponentInParent<Image>().color = new Color32(col.r, col.g, col.b, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Color32 col = this.GetComponentInParent<Image>().color;
        this.GetComponentInParent<Image>().color = new Color32(col.r, col.g, col.b, 74);
    }
}