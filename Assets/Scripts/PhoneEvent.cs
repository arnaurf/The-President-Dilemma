using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PhoneEvent : MonoBehaviour
{
    public string Q1;
    public string Q2;
    public string Q3;
    public string A1;
    public string A2;
    public string A3;
    public string A4;
    public string A5;
    public string A6;

    public string R1;
    public int society1;
    public int company1;
    public int international1;
    public int army1;
    public int climate1;

    public string R2;
    public int society2;
    public int company2;
    public int international2;
    public int army2;
    public int climate2;

    public string R3;
    public int society3;
    public int company3;
    public int international3;
    public int army3;
    public int climate3;

    public string R4;
    public int society4;
    public int company4;
    public int international4;
    public int army4;
    public int climate4;

    public PhoneEvent(string q1, string q2, string q3, string a1, string a2, string a3, string a4, string a5, string a6, string r1, int society1, int company1, int international1, int army1, int climate1, string r2, int society2, int company2, int international2, int army2, int climate2, string r3, int society3, int company3, int international3, int army3, int climate3, string r4, int society4, int company4, int international4, int army4, int climate4)
    {
        Q1 = q1;
        Q2 = q2;
        Q3 = q3;
        A1 = a1;
        A2 = a2;
        A3 = a3;
        A4 = a4;
        A5 = a5;
        A6 = a6;
        R1 = r1;
        this.society1 = society1;
        this.company1 = company1;
        this.international1 = international1;
        this.army1 = army1;
        this.climate1 = climate1;
        R2 = r2;
        this.society2 = society2;
        this.company2 = company2;
        this.international2 = international2;
        this.army2 = army2;
        this.climate2 = climate2;
        R3 = r3;
        this.society3 = society3;
        this.company3 = company3;
        this.international3 = international3;
        this.army3 = army3;
        this.climate3 = climate3;
        R4 = r4;
        this.society4 = society4;
        this.company4 = company4;
        this.international4 = international4;
        this.army4 = army4;
        this.climate4 = climate4;
    }

    public PhoneEvent(string eventDescription)
    {
        
        string[] fullData = eventDescription.Split('@');

        Q1 = fullData[0];
        Q2 = fullData[1];
        Q3 = fullData[2];
        A1 = fullData[3];
        A2 = fullData[4];
        A3 = fullData[5];
        A4 = fullData[6];
        A5 = fullData[7];
        A6 = fullData[8];

        R1 = fullData[9];
        this.society1 = Int32.Parse(fullData[10]);
        this.company1 = Int32.Parse(fullData[11]);
        this.international1 = Int32.Parse(fullData[12]);
        this.army1 = Int32.Parse(fullData[13]);
        this.climate1 = Int32.Parse(fullData[14]);

        R2 = fullData[15];
        this.society2 = Int32.Parse(fullData[16]);
        this.company2 = Int32.Parse(fullData[17]);
        this.international2 = Int32.Parse(fullData[18]);
        this.army2 = Int32.Parse(fullData[19]);
        this.climate2 = Int32.Parse(fullData[20]);

        R3 = fullData[21];
        this.society3 = Int32.Parse(fullData[22]);
        this.company3 = Int32.Parse(fullData[23]);
        this.international3 = Int32.Parse(fullData[24]);
        this.army3 = Int32.Parse(fullData[25]);
        this.climate3 = Int32.Parse(fullData[26]);

        R4 = fullData[27];
        this.society4 = Int32.Parse(fullData[28]);
        this.company4 = Int32.Parse(fullData[29]);
        this.international4 = Int32.Parse(fullData[30]);
        this.army4 = Int32.Parse(fullData[31]);
        this.climate4 = Int32.Parse(fullData[32]);
    }
}
