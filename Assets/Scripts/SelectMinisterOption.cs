using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMinisterOption : MonoBehaviour
{
    public GameController gameController;
    public CanvasGroup ministerCanvas;

    public void AcceptMinister()
    {
        gameController.setSociety(gameController.getSociety() + gameController.currentMinisterEvent.acceptSociety + gameController.extraSociety);
        gameController.setCompanies(gameController.getCompanies() + gameController.currentMinisterEvent.acceptCompanies + gameController.extraCompanies);
        gameController.setArmy(gameController.getArmy() + gameController.currentMinisterEvent.acceptArmy + gameController.extraArmy);
        gameController.setClimate(gameController.getClimate() + gameController.currentMinisterEvent.acceptClimate + gameController.extraClimate);
        gameController.setInternational(gameController.getInternational() + gameController.currentMinisterEvent.acceptInternational + gameController.extraInternational);
        
        ministerCanvas.alpha = 0;
        ministerCanvas.interactable = false;
        ministerCanvas.blocksRaycasts = false;

        if (gameController.year == 0 && gameController.month == 5)
            gameController.olympics = true;
        gameController.ministerOptionNews = 0;

        gameController.nextTurn();
    }

    public void DeclineMinister()
    {
        gameController.setSociety(gameController.getSociety() + gameController.currentMinisterEvent.declineSociety + gameController.extraSociety);
        gameController.setCompanies(gameController.getCompanies() + gameController.currentMinisterEvent.declineCompanies + gameController.extraCompanies);
        gameController.setArmy(gameController.getArmy() + gameController.currentMinisterEvent.declineArmy + gameController.extraArmy);
        gameController.setClimate(gameController.getClimate() + gameController.currentMinisterEvent.declineClimate + gameController.extraClimate);
        gameController.setInternational(gameController.getInternational() + gameController.currentMinisterEvent.declineInternational + gameController.extraInternational);

        ministerCanvas.alpha = 0;
        ministerCanvas.interactable = false;
        ministerCanvas.blocksRaycasts = false;

        if (gameController.year == 0 && gameController.month == 5)
            gameController.olympics = false;
        gameController.ministerOptionNews = 1;

        gameController.nextTurn();
    }
}
