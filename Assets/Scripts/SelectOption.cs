using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectOption : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public CanvasGroup folderCanvas;
    public GameController gameController;
    public GameObject firm;
    public AudioClip sign;
    public AudioSource signSource;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(this.tag == "A")
        {
            gameController.setSociety(gameController.getSociety() + gameController.currentFolderEvent.societyA + gameController.extraSociety);
            gameController.setCompanies(gameController.getCompanies() + gameController.currentFolderEvent.companyA + gameController.extraCompanies);
            gameController.setArmy(gameController.getArmy() + gameController.currentFolderEvent.armyA + gameController.extraArmy);
            gameController.setClimate(gameController.getClimate() + gameController.currentFolderEvent.climateA + gameController.extraClimate);
            gameController.setInternational(gameController.getInternational() + gameController.currentFolderEvent.internationalA + gameController.extraInternational);

            gameController.folderOptionNews = 0;
        }
        else if (this.tag == "B")
        {
            gameController.setSociety(gameController.getSociety() + gameController.currentFolderEvent.societyB + gameController.extraSociety);
            gameController.setCompanies(gameController.getCompanies() + gameController.currentFolderEvent.companyB + gameController.extraCompanies);
            gameController.setArmy(gameController.getArmy() + gameController.currentFolderEvent.armyB + gameController.extraArmy);
            gameController.setClimate(gameController.getClimate() + gameController.currentFolderEvent.climateB + gameController.extraClimate);
            gameController.setInternational(gameController.getInternational() + gameController.currentFolderEvent.internationalB + gameController.extraInternational);

            gameController.folderOptionNews = 1;
        }

        folderCanvas.alpha = 0;
        folderCanvas.interactable = false;
        folderCanvas.blocksRaycasts = false;

        signSource.PlayOneShot(sign);

        gameController.nextTurn();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        firm.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        firm.SetActive(false);
    }
}
