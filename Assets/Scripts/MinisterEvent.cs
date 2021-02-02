using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MinisterEvent : MonoBehaviour
{
    public string minister;
    public string description;
    public int acceptSociety;
    public int acceptCompanies;
    public int acceptInternational;
    public int acceptArmy;
    public int acceptClimate;
    public int declineSociety;
    public int declineCompanies;
    public int declineInternational;
    public int declineArmy;
    public int declineClimate;

    public MinisterEvent(string eventDescription)
    { 

        string[] fullData = eventDescription.Split('@');
        this.minister = fullData[0];
        this.description = fullData[1];
        this.acceptSociety = Int32.Parse(fullData[2]);
        this.acceptCompanies = Int32.Parse(fullData[3]);
        this.acceptInternational = Int32.Parse(fullData[4]);
        this.acceptArmy = Int32.Parse(fullData[5]);
        this.acceptClimate = Int32.Parse(fullData[6]);
        this.declineSociety = Int32.Parse(fullData[7]);
        this.declineCompanies = Int32.Parse(fullData[8]);
        this.declineInternational = Int32.Parse(fullData[9]);
        this.declineArmy = Int32.Parse(fullData[10]);
        this.declineClimate = Int32.Parse(fullData[11]);
    }
}
