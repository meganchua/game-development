using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.InputField;
using static UnityEngine.UI.Dropdown;

/**********************************************************************
     * Megan Chua
     * CS583 HW 2 D&D Character Generator
     * Due 09/30/2019
     * Implements a dice simulator with the use of an array as well as 
     * the sliders in the UI.
     * Outputs as a JSON string using the ToJson function.
     * ********************************************************************/

public class Output : MonoBehaviour
{
    /**********************************************************************
     * Initialize all variables
     * ********************************************************************/
    public InputField Name;
    public InputField Armorclass;
    public InputField Items;

    public Dropdown Class;
    public Dropdown Race;
    public Dropdown Alignment;

    public Text Strength;
    public Text Dexterity;
    public Text Charisma;
    public Text Constitution;
    public Text Intelligence;
    public Text Wisdom;

    public Text Walking;
    public Text Running;
    public Text Jumping;
    public Text curXP;
    public Text maxXP;
    public Text curHP;
    public Text maxHP;

    //public Text outputtxt;
    public InputField outputtxt;

    static string charname;
    static string ClassLevel;
    static string race;
    static string alignment;

    static int armorclass;
    static int strength;
    static int dexterity;
    static int charisma;
    static int constitution;
    static int intelligence;
    static int wisdom;
    static int walking;
    static int running;
    static int jumping;
    static int curxp;
    static int maxxp;
    static int curhp;
    static int maxhp;

    static List<string> items = new List<string>();

    Text value;

    static int d1, d2, d3, d4, d5;
    static int top1, top2, top3, sum;
    public GameObject TextBox;

    /**********************************************************************
     * Creates a dynamic variable for the sliders.
     * All slider values go from 0 to 100.
     * ********************************************************************/

    void Start()
    {
        value = GetComponent<Text>();
    }

    // Update is called once per frame
    public void valueUpdate(float val)
    {
        value.text = Mathf.RoundToInt(val * 100) + "";
    }

    /**********************************************************************
     * Dice simulator:
     * Randomizes 5 rolls and checks for top three values.
     * Returns the total sum of the top three values.
     * ********************************************************************/

    public void ClickButton()
    {
        d1 = UnityEngine.Random.Range(1, 7);
        d2 = UnityEngine.Random.Range(1, 7);
        d3 = UnityEngine.Random.Range(1, 7);
        d4 = UnityEngine.Random.Range(1, 7);
        d5 = UnityEngine.Random.Range(1, 7);

        int[] arr1 = { d1, d2, d3, d4, d5 };
        top1 = top2 = top3 = 0;
        for (int i = 0; i < 5; i++)
        {
            if (arr1[i] > top1)
            {
                top3 = top2;
                top2 = top1;
                top1 = arr1[i];
            }

            else if (arr1[i] > top2)
            {
                top3 = top2;
                top2 = arr1[i];
            }

            else if (arr1[i] > top3)
            {
                top3 = arr1[i];
            }

        }

        sum = top1 + top2 + top3;

        TextBox.GetComponent<Text>().text = "First roll: " + d1 + " Second Roll: " + d2 + "\nThird Roll: " + d3 + " Fourth Roll: "
            + d4 + "\nFifth Roll: " + d5 + "\nTop three values: " + top1 + " " + top2 + " " + top3 + " " + "\nFinal value: " + sum;

    }

    public void Sum()
    {
        TextBox.GetComponent<Text>().text = sum + "";

    }

    /**********************************************************************
     * Converts the game objects to the correct data type in order to 
     * output as a JSON string.
     * ********************************************************************/


    public void Convert()
    {
        charname= Name.text;

        armorclass = int.Parse(Armorclass.text);
        strength = int.Parse(Strength.text);
        dexterity = int.Parse(Dexterity.text);
        charisma = int.Parse(Charisma.text);
        constitution = int.Parse(Constitution.text);
        intelligence = int.Parse(Intelligence.text);
        wisdom = int.Parse(Wisdom.text);
        walking = int.Parse(Walking.text);
        running = int.Parse(Running.text);
        jumping = int.Parse(Jumping.text);
        curxp = int.Parse(curXP.text);
        maxxp = int.Parse(maxXP.text);
        curhp = int.Parse(curHP.text);
        maxhp = int.Parse(maxHP.text);

        items.Add(Items.text);

        int classIndex = Class.GetComponent<Dropdown>().value;
        List<Dropdown.OptionData> classOptions = Class.GetComponent<Dropdown>().options;
        ClassLevel = classOptions[classIndex].text;

        int raceIndex = Race.GetComponent<Dropdown>().value;
        List<Dropdown.OptionData> raceOptions = Race.GetComponent<Dropdown>().options;
        race = raceOptions[raceIndex].text;

        int alignIndex = Alignment.GetComponent<Dropdown>().value;
        List<Dropdown.OptionData> alignOptions = Alignment.GetComponent<Dropdown>().options;
        alignment = alignOptions[alignIndex].text;

        //return JsonUtility.ToJson(this);

        //outputtxt.text = "Name: " + Name.text;//+ "\nArmor Class: " + Armorclass.text + "\nItems: " +
                                              //  Items + "\nClass: " + Class + "\nRace: " + Race + "\nAlignment: " + Alignment;
    }

    /**********************************************************************
     * Create Player characteristics
     * ********************************************************************/
    private class Player
    {
        public string Charname;
        public List<string> ItemsList;
        public string CharRace;
        public string CharClass;
        public string CharAlignment;
        public int CharcurXP;
        public int CharmaxXP;
        public int CharcurHP;
        public int CharmaxHP;
        public int Chararmorclass;
        public int Charwalking;
        public int Charrunning;
        public int Charjumping;
        public int Ability_Strength;
        public int Ability_Dexterity;
        public int Ability_Constitution;
        public int Ability_Intelligence;
        public int Ability_Wisdom;
        public int Ability_Charisma;


    }

    /**********************************************************************
     * Print out Json string
     * ********************************************************************/
    public void toJson()
    {
        Convert();

        Player characteristics = new Player();

        characteristics.Charname = charname;
        characteristics.ItemsList = items;
        characteristics.CharRace = race;
        characteristics.CharClass = ClassLevel;
        characteristics.CharAlignment = alignment;
        characteristics.CharcurXP = curxp;
        characteristics.CharmaxXP = maxxp;
        characteristics.CharcurHP = curhp;
        characteristics.CharmaxHP = maxhp;
        characteristics.Charwalking = walking;
        characteristics.Charrunning = running;
        characteristics.Charjumping = jumping;
        characteristics.Chararmorclass = armorclass;
        characteristics.Ability_Strength = strength;
        characteristics.Ability_Dexterity = dexterity;
        characteristics.Ability_Constitution = constitution;
        characteristics.Ability_Intelligence = intelligence;
        characteristics.Ability_Wisdom = wisdom;
        characteristics.Ability_Charisma = charisma;


        //outputtxt.text = JsonUtility.ToJson(characteristics);
        outputtxt.GetComponent<InputField>().text = JsonUtility.ToJson(characteristics);

    }

    /**********************************************************************
     * Quit button functionality
     * ********************************************************************/

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else
        Application.Quit();

#endif
    }
   
}



