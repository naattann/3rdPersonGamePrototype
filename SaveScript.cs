using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
using System.Runtime.Serialization;

[Serializable]
public class SaveScript : MonoBehaviour
{

    public int level;
    public float exp;
    public float expNeeded;
    public int levelExpBase;
    public float levelExpModifier;
    private int skillPoints;




    private void Start()
    {

        LoadData();
        expNeeded = level * levelExpModifier * levelExpBase;


    }



    private void Update()
    {


       

        if (exp >= expNeeded)
        {
            level++;
            expNeeded = level * levelExpModifier * levelExpBase;
            exp = 0;
            skillPoints++;

        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveData();
            Debug.Log("datasaved");
        }

    }






    public void SaveData ()
    {

        PlayerData data = new PlayerData();
        data.level = this.level;
        data.exp = this.exp;
        data.expNeeded = this.expNeeded;
        data.skillPoints = this.skillPoints;


        string json = JsonUtility.ToJson(data, true);
        string path = Application.dataPath + "/Save.txt";
        File.WriteAllText(Application.dataPath + "/Save.json",json);

                  
    }







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
