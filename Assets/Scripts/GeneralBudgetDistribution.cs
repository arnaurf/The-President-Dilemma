using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralBudgetDistribution : MonoBehaviour
{
    public int totalBudget;
    public int remainingBudget;
    public Text remainingBudgetText;

    public Slider societySlider;
    public Slider armySlider;
    public Slider companiesSlider;
    public Slider environmentSlider;
    public Slider internationalSlider;

    public Text societyBudgetText;
    public Text armyBudgetText;
    public Text companiesBudgetText;
    public Text environmentBudgetText;
    public Text internationalBudgetText;

    public int societyBudget = 1;
    public int armyBudget = 1;
    public int companiesBudget = 1;
    public int environmentBudget = 1;
    public int internationalBudget = 1;

    public float societyBudgetNew;
    public float armyBudgetNew;
    public float companiesBudgetNew;
    public float environmentBudgetNew;
    public float internationalBudgetNew;

    public float societyBudgetOld;
    public float armyBudgetOld;
    public float companiesBudgetOld;
    public float environmentBudgetOld;
    public float internationalBudgetOld;

    public GameController gm;
    public CanvasGroup canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        societyBudgetNew = societySlider.value;
        armyBudgetNew = armySlider.value;
        companiesBudgetNew = companiesSlider.value;
        environmentBudgetNew = environmentSlider.value;
        internationalBudgetNew = internationalSlider.value;

        if(remainingBudget <= 0)
        {
            if (societyBudgetNew >= societyBudgetOld)
            {
                societySlider.value = societyBudgetOld;
            }
            else
            {
                societySlider.value = societyBudgetNew;
            }

            if (armyBudgetNew >= armyBudgetOld)
            {
                armySlider.value = armyBudgetOld;
            }
            else
            {
                armySlider.value = armyBudgetNew;
            }

            if (companiesBudgetNew >= companiesBudgetOld)
            {
                companiesSlider.value = companiesBudgetOld;
            }
            else
            {
                companiesSlider.value = companiesBudgetNew;
            }

            if (environmentBudgetNew >= environmentBudgetOld)
            {
                environmentSlider.value = environmentBudgetOld;
            }
            else
            {
                environmentSlider.value = environmentBudgetNew;
            }

            if (internationalBudgetNew >= internationalBudgetOld)
            {
                internationalSlider.value = internationalBudgetOld;
            }
            else
            {
                internationalSlider.value = internationalBudgetNew;
            }
        }
        else
        {
            societyBudgetOld = societySlider.value;
            armyBudgetOld = armySlider.value;
            companiesBudgetOld = companiesSlider.value;
            environmentBudgetOld = environmentSlider.value;
            internationalBudgetOld = internationalSlider.value;
        }

        societyBudget = Mathf.Max(1, (int)(societySlider.value * 50));
        armyBudget = Mathf.Max(1, (int)(armySlider.value * 50));
        companiesBudget = Mathf.Max(1, (int)(companiesSlider.value * 50));
        environmentBudget = Mathf.Max(1, (int)(environmentSlider.value * 50));
        internationalBudget = Mathf.Max(1, (int)(internationalSlider.value * 50));

        societyBudgetText.text = societyBudget+"0.000 M";
        armyBudgetText.text = armyBudget + "0.000 M";
        companiesBudgetText.text = companiesBudget + "0.000 M";
        environmentBudgetText.text = environmentBudget + "0.000 M";
        internationalBudgetText.text = internationalBudget + "0.000 M";

        remainingBudget = totalBudget - societyBudget - armyBudget - companiesBudget - environmentBudget - internationalBudget;
        if (remainingBudget <= 0)
            remainingBudgetText.text = "No Money Left";
        else
            remainingBudgetText.text = remainingBudget + "0.000 M";
    }

    public void SetBudget()
    {

        if(societySlider.value <= 0.3)
            gm.extraSociety = -5;
        else if(societySlider.value > 0.3 && societySlider.value <= 0.7)
            gm.extraSociety = 0;
        else if (societySlider.value > 0.7)
            gm.extraSociety = 5;

        if (companiesSlider.value <= 0.3)
            gm.extraCompanies = -5;
        else if (companiesSlider.value > 0.3 && companiesSlider.value <= 0.7)
            gm.extraCompanies = 0;
        else if (companiesSlider.value > 0.7)
            gm.extraCompanies = 5;

        if (armySlider.value <= 0.3)
            gm.extraArmy = -5;
        else if (armySlider.value > 0.3 && armySlider.value <= 0.7)
            gm.extraArmy = 0;
        else if (armySlider.value > 0.7)
            gm.extraArmy = 5;

        if (environmentSlider.value <= 0.3)
            gm.extraClimate = -5;
        else if (environmentSlider.value > 0.3 && environmentSlider.value <= 0.7)
            gm.extraClimate = 0;
        else if (environmentSlider.value > 0.7)
            gm.extraClimate = 5;

        if (internationalSlider.value <= 0.3)
            gm.extraInternational = -5;
        else if (internationalSlider.value > 0.3 && internationalSlider.value <= 0.7)
            gm.extraInternational = 0;
        else if (internationalSlider.value > 0.7)
            gm.extraInternational = 5;

        canvas.alpha = 0;
        canvas.interactable = false;
        canvas.blocksRaycasts = false;

        gm.nextTurn();
    }
}
