using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    bool veryFirstClick = true;

    public CanvasGroup folderCanvas;
    public Text folderOptionA;
    public Text folderOptionB;
    public Text folderDescriptionA;
    public Text folderDescriptionB;

    public CanvasGroup phoneCanvas;
    public Text phoneQ;
    public Text phoneA1;
    public Text phoneA2;
    public int phoneCallStatus = 0;

    public CanvasGroup ministerCanvas;
    public Text ministerType;
    public Text ministerDescription;

    public GameObject folderObject;
    public GameObject phoneObject;
    public AudioSource ringPhone;
    public GameObject ministerObject;
    public GameObject sportsMinisterObject;


    public CanvasGroup budgetCanvas;

    public int month;
    string[] monthNames = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
    public int year;

    public GameObject olympicsLogo;
    public bool olympics;
    public bool hostingOlympics;
    public int folderOptionNews;
    public int phoneOptionNews;
    public int ministerOptionNews;
    public Sprite coverNewspaper;
    public Sprite normalNewspaper;
    public SpriteRenderer newspaper;

    public ArrayList folderEvents = new ArrayList();
    public FolderEvent currentFolderEvent;
    public ArrayList phoneEvents = new ArrayList();
    public PhoneEvent currentPhoneEvent;
    public ArrayList ministerEvents = new ArrayList();
    public MinisterEvent currentMinisterEvent;

    bool isDead = false;
    bool isHolidays = false;
    string deadCause;
    public bool isTransitioning = false;
    public Animator diaryAnim;
    public GameObject date;
    public GameObject internationalNewsObject;
    public GameObject info;
    public GameObject news;
    public GameObject coverNews;
    public string latestNews = "";

    //Society visuals
    public GameObject rainbows;
    public GameObject fires;

    //Company visuals
    public GameObject money;
    public GameObject sales;

    //Environment visuals
    public GameObject contamination;
    public GameObject greenCity;

    //Army visuals
    public GameObject weapon;
    public GameObject shots;

    //International visuals
    public TMPro.TextMeshPro internationalNews;
    public ArrayList goodInternational = new ArrayList();
    public ArrayList neutralInternational = new ArrayList();
    public ArrayList badInternational = new ArrayList();

    public int extraSociety = 0;
    public int extraCompanies = 0;
    public int extraArmy = 0;
    public int extraClimate = 0;
    public int extraInternational = 0;

    public bool folderAvailable = false;
    public bool phoneAvailable = false;
    public bool ministerAvailable = false;

    public int society;
    public int getSociety()
    { return society; }
    public void setSociety(int society)
    { this.society = society; }

    public int companies;
    public int getCompanies()
    { return companies; }
    public void setCompanies(int companies)
    { this.companies = companies; }

    public int international;
    public int getInternational()
    { return international; }
    public void setInternational(int international)
    { this.international = international; }

    public int army;
    public int getArmy()
    { return army; }
    public void setArmy(int army)
    { this.army = army; }

    public int climate;
    public int getClimate()
    { return climate; }
    public void setClimate(int climate)
    { this.climate = climate; }

    string currentInteractable;
    public string getCurrentInteractable()
    { return currentInteractable; }
    public void setCurrentInteractable(string currentInteractable)
    { this.currentInteractable = currentInteractable; }

    //End game
    public Animator fade;
    public Animator audio_anim;
    public int sceneDestination;

    // Start is called before the first frame update
    void Start()
    {
        phoneObject.GetComponent<Animator>().enabled = false;
        phoneObject.GetComponent<BoxCollider2D>().enabled = false;

        society = 50;
        companies = 50;
        international = 50;
        army = 50;
        climate = 50;

        olympics = false;
        hostingOlympics = false;

        FolderEvent f1 = new FolderEvent("Suport the Animals@Support an organization that takes care of the animals in danger of extinction@5@0@10@0@10@Prevention of fires@Create new fire prevention system@10@0@0@-5@15");
        FolderEvent f2 = new FolderEvent("World with Peace@Reduce the investments in the army and the equipment used@5@0@0@-10@5@Restrictions@Apply new laws to the taxi and motorcycle companies in order to reduce the contamination of the principal cities@-5@-10@0@0@5");
        FolderEvent f3 = new FolderEvent("Black Gold@Create a new plant to extract petrol@-5@0@5@0@-25@Private is better@Promote the private university@-15@5@5@0@0");
        FolderEvent f4 = new FolderEvent("Increase of minimum salary@The salaries of the people will be increased in a 5%@25@-10@5@0@0@Celebration of the 1st Congress of the Small Company@Create a new congress for any type of companies to make themselves to be known@-5@25@20@0@0");
        FolderEvent f5 = new FolderEvent("FarmCountry@Support the farmers by reducing their taxes@10@-5@0@0@0@New Organization: UC@Support and assist to the new organization meeting where the countries around the world debate and preserve the peace in the world@5@0@10@0@0");
        FolderEvent nationalDay = new FolderEvent("National Day\nMilitary Parade@Exhibit the powerful army of Nilfaqua@0@0@0@10@0@National Day\nPride Parade@Love and be loved@10@0@0@0@0");
        FolderEvent f6 = new FolderEvent("A new weapon@Invest in an experiment to create a new powerful weapon@-15@-5@5@15@0@I want more money@Finance the big companies of your country@-10@20@5@5@0");
        FolderEvent f7 = new FolderEvent("Clean Air@Regulate the entrance of the vehicles to the big cities@-5@0@10@-5@15@Interconnection@Upgrade and expand the public transport@15@5@0@0@-10");
        folderEvents.Insert(0, null);
        folderEvents.Insert(1, f1);
        folderEvents.Insert(2, null);
        folderEvents.Insert(3, null);
        folderEvents.Insert(4, f2);
        folderEvents.Insert(5, null);
        folderEvents.Insert(6, null);
        folderEvents.Insert(7, nationalDay);
        folderEvents.Insert(8, f6);
        folderEvents.Insert(9, f3);
        folderEvents.Insert(10, null);
        folderEvents.Insert(11, null);
        folderEvents.Insert(12, null);
        folderEvents.Insert(13, f4);
        folderEvents.Insert(14, null);
        folderEvents.Insert(15, null);
        folderEvents.Insert(16, f7);
        folderEvents.Insert(17, f5);
        folderEvents.Insert(18, null);


        PhoneEvent p1 = new PhoneEvent("Hello, I am a minister of Chima. We would like to pone a train line from our country to yours to create commerce between both countries.@We think that we should pay half of the operation and you the other half@In that case, we would like to cut tariffs between us.@It is a good idea@We are not interested, at the moment, to create new ways of commerce.@In order to expand our commerce we will do whatever it takes@Sorry but we can't afford an operation like this one. You should pay the whole quantity@Of course. We can reduce tariffs by 5%@Sorry but we will mantain our tariffs.@NULL@5@5@10@0@0@Sorry, this is inadmissible@0@-5@-10@0@0@That is a great deal. Thank you@0@5@5@0@0@NULL@0@-5@-5@0@0");
        PhoneEvent p2 = new PhoneEvent("Good morning, this is Elon Must. I was hopping to the presentation of my new Testa model in your city within a few weeks. Would that be okay?@Because I think it would be a great opportunity for both of us.@I do believe this would bring a positive effect towards the people and the country. Plus there is a Tesla for you;)@Why choose my city?@I don't not know, I believe I have more urgents things to do right now@It could only bring positive things in the near future.I could be a good thing. @Still, not interested. Sorry.@You are right.It is a good idea.Come next month!.@Still, not interested. Sorry.@Perfect!Pleasure talking with you and I hope to see you soon.@10@10@10@0@5@NULL@0@-5@-2@0@-2@Perfect!Pleasure talking with you and I hope to see you soon.@10@7@5@0@10@NULL@0@-5@-5@0@7");
        PhoneEvent p3 = new PhoneEvent("I am the president of the neighbour country. We are being attacked and need your support to defeat the oponent. Will you join us?@Because it will benefit both and our relationship will be stronger. Yes or No?@If you do not help us in the future we will no support your country if you ask for it@Why you have decided to contact us?@A war never decides a problem.@Okay. I will send my army to help you@Sorry. This is not my war.@Are you trying to intimidate me? I am going to attack you@That is not the way we behave@NULL@-20@-10@10@10@0@NULL@10@10@-10@0@0@Good luck@-10@-10@-10@20@0@NULL@20@0@-10@-10@0");
        PhoneEvent p4 = new PhoneEvent("We are from the WHO, a new disease called Covid-19 is affecting your neighbour countries. You should restrict the entrance to Nilfaqua@Prepare analysis in every hospital to check the health of your inhabitants.@In that case, you should check any person that enters to your country and make them pass a medical revision@Thanks for notifying us. Is there any more caution that we should take to prevent any contamination?@I will not close the frontiers of the country@We will do as much as we can to preserve the health of the population@I change my opinion. We will restrict the frontiers but nothing else@Perfect.@I will do what I want. This virus is a lie.@NULL@20@10@10@10@0@NULL@-10@0@-10@0@0@NULL@10@10@0@10@0@NULL@-10@-10@-10@0@0");
        PhoneEvent p5 = new PhoneEvent("Hello, this is Miquel Montoro. I want to give you a proposal. I would like to do a speech about Climate Change in your country. Is it possible?@Because this matters concerns all of us. So, what do you think?@Because this matters concerns all of us. So, what do you think?@Why do you think this concerns me?@Why would I agree to that?@You are right. It is a good idea. Come next month!.@Sorry. I am not interested.@You are right. It is a good idea. Come next month!.@I do not think that this is the best for my people right now. Sorry@Great! See you next month.@20@10@15@0@30@Sad to hear this. Bye.@-5@0@-5@0@-15@Great! See you next month.@20@10@15@0@30@Sad to hear this. Bye@-5@0@-5@0@-15");
        PhoneEvent p6 = new PhoneEvent("Hi there, I'm the director of the project Universe, that tries to send new spaceships to discover inhospitable places. We would like you to join us.@We need the porfessionals at our building, not in your country@At least, you could send us your best scientifics@We will create a new department to investigate and study the project-@Sorry but we are not interested in it.@Okay, no problem. We are in contact@Sorry but they will stay here you like it or not@We will contact with them and try to convince them to help you@Sorry, we are wasting time doing nothhing.@NULL@5@0@10@0@0@That is evil@0@5@-10@0@0@We talk@0@0@5@0@0@NULL@0@-5@-5@0@0");
        PhoneEvent p7 = new PhoneEvent("Hello, I am manager of DisneiHell. We are would like to build a new them park in your capital city.@It will take us 4 years to have it finished@We guarantee you an increase on your revenues@Okey, that will increase our revenues@Sorry, we have enough theme parks and it will be dificult to ubicate a new one.@No problem@That's to much. You should have it in less than 2 years@Sorry but we will not change our decision.@We will think about it@Okay. We will talk.@10@5@0@0@0@Impossible!@-5@-10@0@0@0@NULL@-10@-5@0@0@0@Thanks for your consideration@5@5@0@0@0");
        phoneEvents.Insert(0, null);
        phoneEvents.Insert(1, null);
        phoneEvents.Insert(2, p1);
        phoneEvents.Insert(3, null);
        phoneEvents.Insert(4, null);
        phoneEvents.Insert(5, null);
        phoneEvents.Insert(6, p4);
        phoneEvents.Insert(7, null);
        phoneEvents.Insert(8, p2);
        phoneEvents.Insert(9, null);
        phoneEvents.Insert(10, p3);
        phoneEvents.Insert(11, p5);
        phoneEvents.Insert(12, null);
        phoneEvents.Insert(13, p6);
        phoneEvents.Insert(14, null);
        phoneEvents.Insert(15, p7);
        phoneEvents.Insert(16, null);
        phoneEvents.Insert(17, null);
        phoneEvents.Insert(18, null);

        MinisterEvent m1 = new MinisterEvent("Ministry of Foreign Affairs@Would you like to help the imigrants that are trying to enter to the country?@5@0@10@0@0@-5@0@-15@0@0");
        MinisterEvent m2 = new MinisterEvent("Ministry of Industry@We should invest in the growth of new startups in our country@5@15@10@-5@0@-5@-10@-5@0@0");
        MinisterEvent m3 = new MinisterEvent("Ministry of Defence@I think that we should implement a law to force men older that 18 to spend 2 years in the army, what do you think?@-10@-5@-5@25@0@10@0@5@-10@0");
        MinisterEvent m4 = new MinisterEvent("Ministry of Environment@It would be very beneficial for both the country and for the political party to invest in the instalation of solar panels on the building rooftops.@5@-2@7@0@15@-5@5@-2@0@-20");
        MinisterEvent m5 = new MinisterEvent("Ministry of Social Affairs@It is a must do situation to close casinos near poor zones@5@-7@3@0@0@-10@8@-3@0@0");
        MinisterEvent m6 = new MinisterEvent("Ministry of Social Affairs@Some of your population are protesting in the streets against some of your decisions. I would recommend you to send the police to dispel them@-15@-5@-5@5@0@15@0@5@0@0");
        MinisterEvent olympicsApply = new MinisterEvent("Olympics 2024@Would you like to apply for hosting the 2024 Olympic Games?@5@5@5@5@5@-5@-5@-5@-5@-5");
        MinisterEvent olympicsEvent = new MinisterEvent("Olympics Speech@There is a commemorative event to remember the first gold medal in femenine taekwondo at the other coast of the country, you will need a plane to get there. Do you want to make a speech?@10@5@5@0@-10@-10@-5@0@0@5");
        MinisterEvent m7 = new MinisterEvent("Ministry of Environment@There is a chance to change the nuclearpower plants for windmills, do you want to invest some money to pull ahead this idea?@-10@-10@5@0@20@5@0@-5@0@-15");
        MinisterEvent m8 = new MinisterEvent("Ministry of Industry@It would be very beneficial for the city if we create a law in order to delay retirement on 3 years@-10@7@-3@0@-5@5@-3@-3@0@0");
        MinisterEvent m9 = new MinisterEvent("Ministry of Foreign Affairs@There is a massive fire in Australia and they can not controle it. Should we send some firemens there to help on the situation?@7@0@15@0@10@-5@0@0@0@-15");
        ministerEvents.Insert(0, null);
        ministerEvents.Insert(1, null);
        ministerEvents.Insert(2, null);
        ministerEvents.Insert(3, m1);
        ministerEvents.Insert(4, m6);
        ministerEvents.Insert(5, olympicsApply);
        ministerEvents.Insert(6, m2);
        ministerEvents.Insert(7, null);
        ministerEvents.Insert(8, m7);
        ministerEvents.Insert(9, null);
        ministerEvents.Insert(10, m8);
        ministerEvents.Insert(11, m3);
        ministerEvents.Insert(12, null);
        ministerEvents.Insert(13, m9);
        ministerEvents.Insert(14, olympicsEvent);
        ministerEvents.Insert(15, m4);
        ministerEvents.Insert(16, m5);
        ministerEvents.Insert(17, null);
        ministerEvents.Insert(18, null);

        diaryAnim.SetTrigger("Enter");
    }

    void Update()
    {
        if(isTransitioning && isDead && Input.GetMouseButton(0))
        {
            fade.enabled = true;
            audio_anim.enabled = true;
        }

        if (isTransitioning && isHolidays && Input.GetMouseButton(0))
        {
            fade.enabled = true;
            audio_anim.enabled = true;
        }

        if (fade.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            SceneManager.LoadScene(sceneDestination);
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (isTransitioning && Input.GetMouseButton(0) && !veryFirstClick)
        {
            activateInteractables();
            folderObject.SetActive(folderAvailable);
            
            if (phoneAvailable)
                ringPhone.Play();
            else
                ringPhone.Stop();

            if ((year == 0 && month == 5) || (year == 1 && month == 2))
            {
                sportsMinisterObject.SetActive(true);
                ministerObject.SetActive(false);
                sportsMinisterObject.GetComponent<click_sound>().enabled = false;
                sportsMinisterObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                sportsMinisterObject.SetActive(false);
                ministerObject.SetActive(ministerAvailable);
                sportsMinisterObject.GetComponent<click_sound>().enabled = false;
                sportsMinisterObject.GetComponent<BoxCollider2D>().enabled = false;
            }

            StartCoroutine(startInteractions(2f));

            isTransitioning = false;

            diaryAnim.SetTrigger("Exit");

            info.gameObject.SetActive(false);

            if(month == 0 && year == 1)
                StartCoroutine(startBudget(2f));
        }

        if(!isTransitioning && month == 0 && Input.GetMouseButton(0) && veryFirstClick)
        {
            diaryAnim.SetTrigger("Exit");
            StartCoroutine(startBudget(2f));
            veryFirstClick = false;
        }

        if ((year == 0 && month == 0) || (year == 1 && month == 6) || isDead)
        {
            news.SetActive(false);
            internationalNewsObject.SetActive(false);
            coverNews.SetActive(true);
            newspaper.sprite = coverNewspaper;
        }
        else
        {
            news.SetActive(true);
            internationalNewsObject.SetActive(true);
            coverNews.SetActive(false);
            newspaper.sprite = normalNewspaper;
        }
    }

    IEnumerator startBudget(float time)
    {
        yield return new WaitForSeconds(time);

        budgetCanvas.alpha = 1;
        budgetCanvas.interactable = true;
        budgetCanvas.blocksRaycasts = true;
    }

    IEnumerator startInteractions(float time)
    {
        yield return new WaitForSeconds(time);

        sportsMinisterObject.GetComponent<click_sound>().enabled = ministerAvailable;
        sportsMinisterObject.GetComponent<BoxCollider2D>().enabled = ministerAvailable;

        folderObject.GetComponent<click_sound>().enabled = folderAvailable;
        folderObject.GetComponent<BoxCollider>().enabled = folderAvailable;

        ministerObject.GetComponent<click_sound>().enabled = ministerAvailable;
        ministerObject.GetComponent<BoxCollider2D>().enabled = ministerAvailable;

        phoneObject.GetComponent<click_sound>().enabled = phoneAvailable;
        phoneObject.GetComponent<Animator>().enabled = phoneAvailable;
        phoneObject.GetComponent<BoxCollider2D>().enabled = phoneAvailable;
    }

    public void ShowOptions(string s)
    {
        currentInteractable = s;
        int eventNumber;
        if (year > 0)
            eventNumber = year * 11 + month + 1;
        else
            eventNumber = year * 11 + month;

        if (s == "folder")
        {
            currentFolderEvent = new FolderEvent((FolderEvent)folderEvents[eventNumber]);
            folderOptionA.text = currentFolderEvent.titleA;
            folderOptionB.text = currentFolderEvent.titleB;
            folderDescriptionA.text = currentFolderEvent.descriptionA;
            folderDescriptionB.text = currentFolderEvent.descriptionB;

            folderCanvas.alpha = 1;
            folderCanvas.interactable = true;
            folderCanvas.blocksRaycasts = true;
        }
        else if (s == "phone")
        {
            currentPhoneEvent = (PhoneEvent)phoneEvents[eventNumber];
            phoneQ.text = currentPhoneEvent.Q1;
            phoneA1.text = currentPhoneEvent.A1;
            phoneA2.text = currentPhoneEvent.A2;

            phoneObject.GetComponent<click_sound>().enabled = false;
            phoneObject.GetComponent<Animator>().enabled = false;
            phoneObject.GetComponent<BoxCollider2D>().enabled = false;
            ringPhone.Stop();

            phoneCanvas.alpha = 1;
            phoneCanvas.interactable = true;
            phoneCanvas.blocksRaycasts = true;
        }
        else if (s == "minister")
        {
            currentMinisterEvent = (MinisterEvent)ministerEvents[eventNumber];

            ministerType.text = currentMinisterEvent.minister;
            ministerDescription.text = currentMinisterEvent.description;

            ministerCanvas.alpha = 1;
            ministerCanvas.interactable = true;
            ministerCanvas.blocksRaycasts = true;
        }

        ministerObject.SetActive(false);
        ministerObject.GetComponent<BoxCollider2D>().enabled = false;
        sportsMinisterObject.SetActive(false);

        phoneObject.GetComponent<click_sound>().enabled = false;

        folderObject.SetActive(false);
    }

    public string ParametersToString()
    {
        return
            ("Society: " + society + "%\n"
            + "Companies: " + companies + "%\n"
            + "International: " + international + "%\n"
            + "Army: " + army + "%\n"
            + "Climate: " + climate + "% \n");
    }

    public void nextTurn()
    {

        if (society >= 100)
            society = 100;
        if (companies >= 100)
            companies = 100;
        if (army >= 100)
            army = 100;
        if (climate >= 100)
            climate = 100;
        if (international >= 100)
            international = 100;

        if (society < 0)
        {
            isDead = true;
            deadCause = "society";
        }

        if (army < 0)
        {
            isDead = true;
            deadCause = "army";
        }

        if (companies < 0)
        {
            isDead = true;
            deadCause = "companies";
        }

        if (international < 0)
        {
            isDead = true;
            deadCause = "international";
        }

        if (climate < 0)
        {
            isDead = true;
            deadCause = "environment";
        }

        month++;
        if(month >= 12)
        {
            year++;
            month = 0;
        }

        isTransitioning = true;

        diaryAnim.SetTrigger("Enter");

        if (isDead)
        {
            date.GetComponent<TMPro.TextMeshPro>().text = monthNames[month] + " " + (2020 + year);
            switch(deadCause)
            {
                case "society":
                    coverNews.GetComponent<TMPro.TextMeshPro>().text = "Revolution in Nilfaqua: the President gets executed by the guillotine in the Independence Square";
                    break;
                case "army":
                    coverNews.GetComponent<TMPro.TextMeshPro>().text = "Coup d'état in Nilfaqua: General Paco takeover the Government";
                    break;
                case "environment":
                    coverNews.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua pollution similar to Chernobyl, the WHO declares our country non-suitable for living";
                    break;
                case "international":
                    coverNews.GetComponent<TMPro.TextMeshPro>().text = "Murica declares war on Nilfaqua, Government disappears";
                    break;
                case "companies":
                    coverNews.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua Stock Exchange reaches historical minimum, the President resign";
                    break;
            }
        }
        else
        {
            if(year >= 1 && month >= 6) //Demo 13-03-2020 lasts 1 year and a half 
            {
                isHolidays = true;
                date.GetComponent<TMPro.TextMeshPro>().text = monthNames[month] + " " + (2020 + year);
                float overallResults = society + army + companies + international + climate;
                if (overallResults < 250)
                {
                    coverNews.GetComponent<TMPro.TextMeshPro>().text = "The president escapes from Nilfaqua for Summer holidays while the country is in a huge crisis";
                }
                else
                {
                    if (society >= army && society >= companies && society >= international && society >= climate)
                        coverNews.GetComponent<TMPro.TextMeshPro>().text = "Our beloved president is getting a deserved holiday";
                    else if (army >= society && army >= companies && army >= international && army >= climate)
                        coverNews.GetComponent<TMPro.TextMeshPro>().text = "The president will spend holidays helping the national troops";
                    else if(companies >= army && society >= society && companies >= international && companies >= climate)
                        coverNews.GetComponent<TMPro.TextMeshPro>().text = "The president will enjoy holidays in a luxury resort in Panama";
                    else if(international >= army && international >= companies && international >= society && international >= climate)
                        coverNews.GetComponent<TMPro.TextMeshPro>().text = "The president will travel around the globe for holidays";
                    else if(climate >= army && climate >= companies && climate >= international && climate >= society)
                        coverNews.GetComponent<TMPro.TextMeshPro>().text = "The president will stay at home during holidays to reduce carbon footprint";
                }
            }
            else
            {
                date.GetComponent<TMPro.TextMeshPro>().text = monthNames[month] + " " + (2020 + year);
            }
        }

        baseNews();

        StartCoroutine(ShowTextTransition(1.5f));
    }

    IEnumerator ShowTextTransition(float time)
    {
        yield return new WaitForSeconds(time);

        info.gameObject.SetActive(true);

        if (society <= 25)
        {
            rainbows.SetActive(false);
            fires.SetActive(true);
        }
        else if (society >= 75)
        {
            rainbows.SetActive(true);
            fires.SetActive(false);
        }
        else
        {
            rainbows.SetActive(false);
            fires.SetActive(false);
        }

        if (army <= 25)
        {
            weapon.SetActive(false);
            shots.SetActive(true);
        }
        else if (army >= 75)
        {
            weapon.SetActive(true);
            shots.SetActive(false);
        }
        else
        {
            weapon.SetActive(false);
            shots.SetActive(false);
        }

        if (companies <= 25)
        {
            sales.SetActive(true);
            money.SetActive(false);
        }
        else if (companies >= 75)
        {
            sales.SetActive(false);
            money.SetActive(true);
        }
        else
        {
            sales.SetActive(false);
            money.SetActive(false);
        }

        if (climate <= 25)
        {
            contamination.SetActive(true);
            greenCity.SetActive(false);
        }
        else if (climate >= 75)
        {
            contamination.SetActive(false);
            greenCity.SetActive(true);
        }
        else
        {
            contamination.SetActive(false);
            greenCity.SetActive(false);
        }
    }

    void activateInteractables()
    {
        phoneObject.GetComponent<Animator>().enabled = false;
        phoneObject.GetComponent<BoxCollider2D>().enabled = false;
        if (isDead)
            return;
        switch (year)
        {
            case 0:
                switch (month)
                {
                    case 0: //General Budget
                        folderAvailable = false;
                        phoneAvailable = false;
                        ministerAvailable = false;
                        break;
                    case 1:
                        folderAvailable = true;
                        phoneAvailable = false;
                        ministerAvailable = false;
                        break;
                    case 2:
                        folderAvailable = false;
                        phoneAvailable = true;
                        ministerAvailable = false;
                        break;
                    case 3:
                        folderAvailable = false;
                        phoneAvailable = false;
                        ministerAvailable = true;
                        break;
                    case 4:
                        folderAvailable = true;
                        phoneAvailable = false;
                        ministerAvailable = true;
                        break;
                    case 5: //Apply for Olympic Games
                        folderAvailable = false;
                        phoneAvailable = false;
                        ministerAvailable = true;
                        olympicsLogo.SetActive(true);
                        break;
                    case 6:
                        folderAvailable = false;
                        phoneAvailable = true;
                        ministerAvailable = true;
                        olympicsLogo.SetActive(false);
                        break;
                    case 7: //National Day
                        folderAvailable = true;
                        phoneAvailable = false;
                        ministerAvailable = false;
                        break;
                    case 8:
                        folderAvailable = true;
                        phoneAvailable = true;
                        ministerAvailable = true;
                        break;
                    case 9:
                        folderAvailable = true;
                        phoneAvailable = false;
                        ministerAvailable = false;
                        break;
                    case 10:
                        folderAvailable = false;
                        phoneAvailable = true;
                        ministerAvailable = true;
                        break;
                    case 11:
                        folderAvailable = false;
                        phoneAvailable = true;
                        ministerAvailable = true;
                        break;
                }
                break;

            case 1:
                switch (month)
                {
                    case 0: //General Budget
                        folderAvailable = false;
                        phoneAvailable = false;
                        ministerAvailable = false;
                        break;
                    case 1:
                        folderAvailable = true;
                        phoneAvailable = true;
                        ministerAvailable = true;
                        break;
                    case 2: //Olympic Games Decision
                        folderAvailable = false;
                        phoneAvailable = false;
                        ministerAvailable = true;
                        olympicsLogo.SetActive(true);
                        break;
                    case 3:
                        folderAvailable = false;
                        phoneAvailable = true;
                        ministerAvailable = true;
                        olympicsLogo.SetActive(false);
                        break;
                    case 4:
                        folderAvailable = true;
                        phoneAvailable = false;
                        ministerAvailable = true;
                        break;
                    case 5: 
                        folderAvailable = true;
                        phoneAvailable = false;
                        ministerAvailable = false;
                        break;
                    case 6:
                        folderAvailable = false;
                        phoneAvailable = false;
                        ministerAvailable = false;
                        break;
                }
                break;
        }
    }

    void baseNews()
    {
        if (isDead)
            return;
        if (isHolidays)
            return;

        switch (year)
        {
            case 0:
                switch (month)
                {
                    case 0:
                        news.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua announces a new president after three failed elections";
                        break;
                    case 1:
                        news.GetComponent<TMPro.TextMeshPro>().text = "The general budget for 2020 gets approved by the Government";
                        if (international <= 25)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "China attacks USA with biological weapons";
                        }
                        else if (international >= 75)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Chinese stores in USA will have tax advantages";
                        }
                        else
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Chinese president visits Washington";
                        }
                        break;
                    case 2:
                        switch(currentInteractable)
                        {
                            case "folder":
                                if(folderOptionNews == 0)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "SavetheAnimals recieve an investment from the government to support its cause"; 
                                else
                                    news.GetComponent<TMPro.TextMeshPro>().text = "The goverment decide to take some action to stop any possible chance of fires"; 
                                break;
                            case "phone":
                                if (phoneOptionNews == 1)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else if(phoneOptionNews == 2)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else if (phoneOptionNews == 3)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else if (phoneOptionNews == 4)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                break;
                            case "minister":
                                if (ministerOptionNews == 0)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                break;
                        }

                        if (international <= 25)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua builds a wall to protect the country against illegal immigration";
                        }
                        else if (international >= 75)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua opens its borders and gives free passports";
                        }
                        else
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Beauty and wealth, necessary conditions to enter in Nilfaqua";
                        }
                        break;
                    case 3:
                        news.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua wins 25 medals in the winter olympic, highest ever";
                        if (international <= 25)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "United Kingdom claims sovereignty over former colonies";
                        }
                        else if (international >= 75)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "United Kingdom returns all stolen artifacts to the original countries";
                        }
                        else
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "United Kingdom invites Nilfaqua to the Fish and Chips Awards 2020";
                        }
                        break;
                    case 4:
                        switch (currentInteractable)
                        {
                            case "folder":
                                if (folderOptionNews == 0)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                break;
                            case "phone":
                                if (phoneOptionNews == 1)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else if (phoneOptionNews == 2)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else if (phoneOptionNews == 3)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else if (phoneOptionNews == 4)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                break;
                            case "minister":
                                if (ministerOptionNews == 0)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "A new group of 200 inmigrants has entered to the country and their are being helped";
                                else
                                    news.GetComponent<TMPro.TextMeshPro>().text = "The police of the country shoot the inmigrants that try to enter to the country";
                                break;
                        }
                        if (international <= 25)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Military conlfict blasts in South America";
                        }
                        else if (international >= 75)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Peace has been achieved in Middle East";
                        }
                        else
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Military conlfict persists in Middle East";
                        }
                        break;
                    case 5:
                        news.GetComponent<TMPro.TextMeshPro>().text = "Olympic Games host applications are being accepted for 2024";
                        if (international <= 25)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "North Korea threat Nilfaqua to send nuclear missiles";
                        }
                        else if (international >= 75)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "North Korea opens its borders to all Nilfaqua citizens";
                        }
                        else
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "North Korea and Nilfaqua, meeting in neutral land";
                        }
                        break;
                    case 6:
                        if(olympics)
                            news.GetComponent<TMPro.TextMeshPro>().text = "Chasing the Olympic Dream: Nilfaqua 2024";
                        else
                            news.GetComponent<TMPro.TextMeshPro>().text = "'The Olympics are a waste of money', President said";

                        if (international <= 25)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Russia propagates fake news about communism in Nilfaqua";
                        }
                        else if (international >= 75)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Russia will send one million liters of vodka for the National Day";
                        }
                        else
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "President Puton will visit Nilfaqua during the National Day";
                        }
                        break;
                    case 7:
                        switch (currentInteractable)
                        {
                            case "folder":
                                if (folderOptionNews == 0)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                break;
                            case "phone":
                                if (phoneOptionNews == 1)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua restricts the frontiers and test all the population of Coronavirus";
                                else if (phoneOptionNews == 2)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua closes its borders due to Coronavirus";
                                else if (phoneOptionNews == 3)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua will test all visitors of Coronavirus";
                                else if (phoneOptionNews == 4)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua's President: It's just a flu";
                                break;
                            case "minister":
                                if (ministerOptionNews == 0)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "There is a new boom of startups thanks to the investment of the goverment in this sector";
                                else
                                    news.GetComponent<TMPro.TextMeshPro>().text = "A new study about the startups in the country has predicted that they do not have a hopeful future";
                                break;
                        }

                        if (international <= 25)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "More than 100 countries have someone infected by Coronavirus";
                        }
                        else if (international >= 75)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "South Korea and Nilfaqua are working together to find a vaccine for Coronavirus";
                        }
                        else
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "The WHO asks people to be responsable during the Coronavirus crisis";
                        }
                        break;
                    case 8:
                        switch (currentInteractable)
                        {
                            case "folder":
                                if (folderOptionNews == 0)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "Parachutist gets stucked in a lamp post during parade";
                                else
                                    news.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua gets flooded by LOVE<3";
                                break;
                            case "phone":
                                if (phoneOptionNews == 1)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else if (phoneOptionNews == 2)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else if (phoneOptionNews == 3)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else if (phoneOptionNews == 4)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                break;
                            case "minister":
                                if (ministerOptionNews == 0)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                break;
                        }
                        if (international <= 25)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "IMF criticize Nilfaqua for spending all their money in their National Day";
                        }
                        else if (international >= 75)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Netherlands celebrates Nilfaqua National Day for the help during the last floods";
                        }
                        else
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Presidents from other countries visit Nilfaqua during the National Day";
                        }
                        break;
                    case 9:
                        news.GetComponent<TMPro.TextMeshPro>().text = "Olympic Games hosting applications will be rejected if air pollution is too high";

                        if (international <= 25)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Environmental objectives of the year are too ambicious for everyone";
                        }
                        else if (international >= 75)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Countries collaborate together to fight Climate Change";
                        }
                        else
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Difficulties for all countries to reach the environmental objectives of the year";
                        }
                        break;
                    case 10:
                        switch (currentInteractable)
                        {
                            case "folder":
                                if (folderOptionNews == 0)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "A new petrol plant has been built in the coast of the country affecting to the marine wildfire of the zone";
                                else
                                    news.GetComponent<TMPro.TextMeshPro>().text = "All presidents in Nilfaqua have been assisting private universities, the President said";
                                break;
                            case "phone":
                                if (phoneOptionNews == 1)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else if (phoneOptionNews == 2)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else if (phoneOptionNews == 3)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else if (phoneOptionNews == 4)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                break;
                            case "minister":
                                if (ministerOptionNews == 0)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                break;
                        }

                        if (international <= 25)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua's President not invited to the Presidential Beauty Contest";
                        }
                        else if (international >= 75)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua's President wins the Presidential Beauty Contest";
                        }
                        else
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Pedro Sanchez, from Spain, wins the Presidential Beauty Contest";
                        }
                        break;
                    case 11: //XMas
                        switch (currentInteractable)
                        {
                            case "folder":
                                if (folderOptionNews == 0)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                break;
                            case "phone":
                                if (phoneOptionNews == 1)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "The army will depart the next month to help the neighbour country";
                                else if (phoneOptionNews == 2)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "I will not act in any war that do not affect the country, the president said";
                                else if (phoneOptionNews == 3)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "A new war is coming!";
                                else if (phoneOptionNews == 4)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua denies any type of help to the neighbour country despite the constant requests from it's president";
                                break;
                            case "minister":
                                if (ministerOptionNews == 0)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "Retirement age is increased by 3 years, retired workers demonstrated at the front of the National Work Office";
                                else
                                    news.GetComponent<TMPro.TextMeshPro>().text = "Finally, the Government do not increase the retirement age, workers still retire at 82";
                                break;
                        }
                        if (international <= 25)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "No imported products during Christmas in Nilfaqua";
                        }
                        else if (international >= 75)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Wars have been suspended during Christmas";
                        }
                        else
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Finland's President and Santa Claus wishes Merry Christmas to Nilfaqua";
                        }
                        break;
                }
                break;
            case 1:
                switch (month)
                {
                    case 0:
                        news.GetComponent<TMPro.TextMeshPro>().text = "Happy new year 2021!";
                        if (international <= 25)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua does not get an invitation to the musical contest GlobalVision";
                        }
                        else if (international >= 75)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua will host the musical contest GlobalVision";
                        }
                        else
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua will participate in the musical contest GlobalVision";
                        }
                        break;
                    case 1:
                        news.GetComponent<TMPro.TextMeshPro>().text = "The general budget for 2021 gets approved by the Government";
                        if (international <= 25)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Disney Streaming Service will be exclusive for France";
                        }
                        else if (international >= 75)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Disney Streaming Service will be first week free in Nilfaqua";
                        }
                        else
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Disney Streaming Service will launch this month in Nilfaqua";
                        }
                        break;
                    case 2: 
                        news.GetComponent<TMPro.TextMeshPro>().text = "Social welfare and international reputation may be key for hosting the 2024 Olympics";
                        if (international <= 25)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua will maintain its coin and not join the Nations Union";
                        }
                        else if (international >= 75)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "New currency for all nations: the Nilf";
                        }
                        else
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Some countries may unify under the same currency";
                        }
                        break;
                    case 3:
                        double olympicsResult = society * 0.25 + international * 0.25 + climate * 0.5;
                        if(!olympics)
                            news.GetComponent<TMPro.TextMeshPro>().text = "Madrid 2024: Spain will host the next Olympic Games since no one else have applied"; //Olympic Games Decision news
                        else if (olympicsResult < 60.0)
                            news.GetComponent<TMPro.TextMeshPro>().text = "Madrid 2024: Spain will host the next Olympic Games"; //Olympic Games Decision news
                        else
                            news.GetComponent<TMPro.TextMeshPro>().text = "Ingbend 2024: Nilfaqua will host the next Olympic Games"; //Olympic Games Decision news
                        if (international <= 25)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua is kicked out from the G20";
                        }
                        else if (international >= 75)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua will host the G20";
                        }
                        else
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua joins the G20";
                        }
                        break;
                    case 4:
                        switch (currentInteractable)
                        {
                            case "folder":
                                if (folderOptionNews == 0)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                break;
                            case "phone":
                                if (phoneOptionNews == 1)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "DisneiHell will open its doors in Nilfaqua in 4 years!";
                                else if (phoneOptionNews == 2)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "Negotiations about DisneiHell break up, too much construction time";
                                else if (phoneOptionNews == 3)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "Rollercoaster accident in the oldest theme park of Nilfaqua causes 12 deaths";
                                else if (phoneOptionNews == 4)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "Rumors about a new theme park: DisneiHell";
                                break;
                            case "minister":
                                if (ministerOptionNews == 0)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "The race to a country without pollution continues with the new solar panels installed";
                                else
                                    news.GetComponent<TMPro.TextMeshPro>().text = "We will not install this solar panels yet, said the president";
                                break;
                        }
                        if (international <= 25)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "The Universal Exposition of Nylfqua is cancelled";
                        }
                        else if (international >= 75)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "The Universal Exposition of Nylfqua will honor the immigrants";
                        }
                        else
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "The Universal Exposition of Nylfqua will honor the greatness of the army";
                        }
                        break;
                    case 5:
                        switch (currentInteractable)
                        {
                            case "folder":
                                if (folderOptionNews == 0)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "Only type A and B vehicles will be able to access the city downtown";
                                else
                                    news.GetComponent<TMPro.TextMeshPro>().text = "Four new lines of subway will be inaugurated during the next year";
                                break;
                            case "phone":
                                if (phoneOptionNews == 1)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else if (phoneOptionNews == 2)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else if (phoneOptionNews == 3)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                else if (phoneOptionNews == 4)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "";
                                break;
                            case "minister":
                                if (ministerOptionNews == 0)
                                    news.GetComponent<TMPro.TextMeshPro>().text = "The Grand Casino will be closed forever due to the last restrictions of the government";
                                else
                                    news.GetComponent<TMPro.TextMeshPro>().text = "Despite the opinion of some ministers, the president decide to leave open The Grand Casino";
                                break;
                        }
                        if (international <= 25)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua launches a rocket to Mars and explodes in less than 1km of flight";
                        }
                        else if (international >= 75)
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua joins the International Space Station";
                        }
                        else
                        {
                            internationalNews.GetComponent<TMPro.TextMeshPro>().text = "Nilfaqua launches their Space Station";
                        }
                        break;
                }
                break;
        }
    }
}