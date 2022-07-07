using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class LoadHeroLevel : MonoBehaviour
{



    public TextMeshProUGUI levelText;
    public TextMeshProUGUI expText;
    public TextMeshProUGUI expNeededText;
    public TextMeshProUGUI skillPointsText;

    public float exp;
    public int level;
    public float expNeeded;
    public float skillPoints;

    // Start is called before the first frame update
    void Start()
    {
        LoadData();

        levelText.text = string.Format("{0}", level);
        expText.text = string.Format("{0}", exp);
        expNeededText.text = string.Format("{0:#}", expNeeded);
        skillPointsText.text = string.Format("{0}", skillPoints);


        int choosenHero = PlayerPrefs.GetInt("choosenHero");

    }

    // Update is called once per frame
   


    public void LoadData()
    {
        string path = Application.dataPath + "/Save.json";


        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);


            this.level = data.level;
            this.exp = data.exp;
            this.expNeeded = data.expNeeded;
            this.skillPoints = data.skillPoints;



        }

        else
        {
            return;
        }
    }




}
