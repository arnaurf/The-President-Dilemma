using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlympicsManager : MonoBehaviour
{
    public GameController gameController;
    public CanvasGroup olympicCanvas;

    public void AcceptOlympics()
    {
        /*gameController.setSociety(gameController.getSociety() + gameController.currentMinisterEvent.acceptSociety + gameController.extraSociety);
        gameController.setCompanies(gameController.getCompanies() + gameController.currentMinisterEvent.acceptCompanies + gameController.extraCompanies);
        gameController.setArmy(gameController.getArmy() + gameController.currentMinisterEvent.acceptArmy + gameController.extraArmy);
        gameController.setClimate(gameController.getClimate() + gameController.currentMinisterEvent.acceptClimate + gameController.extraClimate);
        gameController.setInternational(gameController.getInternational() + gameController.currentMinisterEvent.acceptInternational + gameController.extraInternational);*/

        olympicCanvas.alpha = 0;
        olympicCanvas.interactable = false;
        olympicCanvas.blocksRaycasts = false;

        gameController.nextTurn();
    }

    public void DeclineOlympics()
    {
        /*gameController.setSociety(gameController.getSociety() + gameController.currentMinisterEvent.declineSociety + gameController.extraSociety);
        gameController.setCompanies(gameController.getCompanies() + gameController.currentMinisterEvent.declineCompanies + gameController.extraCompanies);
        gameController.setArmy(gameController.getArmy() + gameController.currentMinisterEvent.declineArmy + gameController.extraArmy);
        gameController.setClimate(gameController.getClimate() + gameController.currentMinisterEvent.declineClimate + gameController.extraClimate);
        gameController.setInternational(gameController.getInternational() + gameController.currentMinisterEvent.declineInternational + gameController.extraInternational);*/

        olympicCanvas.alpha = 0;
        olympicCanvas.interactable = false;
        olympicCanvas.blocksRaycasts = false;

        gameController.nextTurn();
    }
}
