using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FolderEvent : MonoBehaviour
{
    public string titleA;
    public string descriptionA;
    public int societyA;
    public int companyA;
    public int internationalA;
    public int armyA;
    public int climateA;

    public string titleB;
    public string descriptionB;
    public int societyB;
    public int companyB;
    public int internationalB;
    public int armyB;
    public int climateB;

    public FolderEvent(FolderEvent f)
    {
        this.titleA = f.titleA;
        this.descriptionA = f.descriptionA;
        this.societyA = f.societyA;
        this.companyA = f.companyA;
        this.internationalA = f.internationalA;
        this.armyA = f.armyA;
        this.climateA = f.climateA;
        this.titleB = f.titleB;
        this.descriptionB = f.descriptionB;
        this.societyB = f.societyB;
        this.companyB = f.companyB;
        this.internationalB = f.internationalB;
        this.armyB = f.armyB;
        this.climateB = f.climateB;
    }

    public FolderEvent(string titleA, string descriptionA, int societyA, int companyA, int internationalA, int armyA, int climateA, string titleB, string descriptionB, int societyB, int companyB, int internationalB, int armyB, int climateB)
    {
        this.titleA = titleA;
        this.descriptionA = descriptionA;
        this.societyA = societyA;
        this.companyA = companyA;
        this.internationalA = internationalA;
        this.armyA = armyA;
        this.climateA = climateA;
        this.titleB = titleB;
        this.descriptionB = descriptionB;
        this.societyB = societyB;
        this.companyB = companyB;
        this.internationalB = internationalB;
        this.armyB = armyB;
        this.climateB = climateB;
    }

    public FolderEvent(string eventDescription)
    {  
        string[] fullData = eventDescription.Split('@');

        this.titleA = fullData[0];
        this.descriptionA = fullData[1];
        this.societyA = Int32.Parse(fullData[2]);
        this.companyA = Int32.Parse(fullData[3]);
        this.internationalA = Int32.Parse(fullData[4]);
        this.armyA = Int32.Parse(fullData[5]);
        this.climateA = Int32.Parse(fullData[6]);
        this.titleB = fullData[7];
        this.descriptionB = fullData[8];
        this.societyB = Int32.Parse(fullData[9]);
        this.companyB = Int32.Parse(fullData[10]);
        this.internationalB = Int32.Parse(fullData[11]);
        this.armyB = Int32.Parse(fullData[12]);
        this.climateB = Int32.Parse(fullData[13]);
    }
}
