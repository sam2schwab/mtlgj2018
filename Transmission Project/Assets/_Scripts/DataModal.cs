using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class DataModal : MonoBehaviour {

    
    public List<Quest> MissionsData;
    public TextAsset MissionCSVFile;
    public TextAsset TavernCSVFile;
    public List<Tavern> TavernData;

    public static DataModal instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }

        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        
    }

    public void Load()
    {
        MissionsData = new List<Quest>();
        TavernData = new List<Tavern>();
        InitiateTavern();
        InitiateMissions();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitiateTavern()
    {
        string[] lines = TavernCSVFile.text.Split("\n"[0]);
        for (int i = 0; i < lines.Length; i++)
        {
            if (i != 0)
            {
                string[] TavernCharac = lines[i].Split(',');
                int ID = System.Int32.Parse(TavernCharac[0]);
                int AveragePowerLevel = System.Int32.Parse(TavernCharac[1]);
                int NumberOfHeroes = System.Int32.Parse(TavernCharac[2]);
                int NbOfKnight = System.Int32.Parse(TavernCharac[3]);
                int NbOfMage = System.Int32.Parse(TavernCharac[4]);
                int NbOfRanger = System.Int32.Parse(TavernCharac[5]);
                int NbOfThief = System.Int32.Parse(TavernCharac[6]);
                int NbOfAny = NumberOfHeroes - (NbOfKnight + NbOfMage + NbOfRanger + NbOfThief);
                double PosX = System.Double.Parse(TavernCharac[7]);
                double PosY = System.Double.Parse(TavernCharac[8]);

                List<Types> Heroes = new List<Types>();
                for(int j = 0; j < NbOfKnight; j++)
                {
                    Heroes.Add(Types.knight);
                }
                for (int j = 0; j < NbOfRanger; j++)
                {
                    Heroes.Add(Types.ranger);
                }
                for (int j = 0; j < NbOfMage; j++)
                {
                    Heroes.Add(Types.mage);
                }
                for (int j = 0; j < NbOfThief; j++)
                {
                    Heroes.Add(Types.thief);
                }
                for (int j = 0; j < NbOfAny; j++)
                {
                    Heroes.Add(Types.any);
                }

                TavernData.Add(new Tavern(ID, PosX, PosY, Heroes, AveragePowerLevel, NumberOfHeroes));
            }
        }
    }

    void InitiateMissions()
    {
        string[] lines = MissionCSVFile.text.Split("\n"[0]);
        for (int i =0; i< lines.Length; i++)
        {
            if (i != 0)
            {
                string[] Missioncharac = lines[i].Split(',');
                int MissionId = System.Int32.Parse(Missioncharac[0]);
                int QuestId = System.Int32.Parse(Missioncharac[1]);
                int Power = System.Int32.Parse(Missioncharac[10]);
                int Healing = System.Int32.Parse(Missioncharac[11]);
                int Punishement = System.Int32.Parse(Missioncharac[12]);
                List<Types> HeroesType = new List<Types>();
                for (int j =0; j < Missioncharac.Length; j++)
                {
                    switch (Missioncharac[j])
                    {
                        case "Knight":
                            HeroesType.Add(Types.knight);
                            break;
                        case "Ranger":
                            HeroesType.Add(Types.ranger);
                            break;
                        case "Thief":
                            HeroesType.Add(Types.thief);
                            break;
                        case "Mage":
                            HeroesType.Add(Types.mage);
                            break;
                        case "Any":
                            HeroesType.Add(Types.any);
                            break;
                    }
                }
                MissionsData.Add(new Quest(HeroesType.Count, MissionId,QuestId, HeroesType.ToArray(), Power, Healing, Punishement));
            }
        }
    }
    public int GetMissionHealing(int MissionId)
    {
        int TotalHealing = 0;
        for (int i =0; i <  MissionsData.Count; i++)
        {
            if(MissionsData[i].MissionID == MissionId)
            {
                TotalHealing = TotalHealing + MissionsData[i].Healing;
            }
        }
        return TotalHealing;
    }
    public List<Quest> GetAllQuestForAMission(int MissionId)
    {
        List<Quest> QuestToReturn = new List<Quest>();
        for (int i = 0; i < MissionsData.Count; i++)
        {
            if (MissionsData[i].MissionID == MissionId)
            {
                QuestToReturn.Add(MissionsData[i]);
            }
        }
        return QuestToReturn;
    }

    public class Quest
    {
        public int NbHeros;
        public int QuestID;
        public Types[] HeroesRequired;
        public int MissionLevel;
        public int Healing;
        public int MissionID;
        public int Punishement;

        public Quest()
        {
            NbHeros = 0;
            QuestID = 0;
            HeroesRequired = new Types[NbHeros];
            MissionLevel = 0;
            Healing = 0;
            Punishement = 0;
        }
        public Quest(int NbHeroes,int MissionID, int QuestId, Types[] HeroesRequired, int MissionLevel, int Healing,int Punishement)
        {
            this.NbHeros = NbHeroes;
            this.QuestID = QuestId;
            this.HeroesRequired = HeroesRequired;
            this.MissionLevel = MissionLevel;
            this.Healing = Healing;
            this.Punishement = Punishement;
            this.MissionID = MissionID;
        }
    }
    public class Tavern
    {
        public int TavernID;
        public double PosX;
        public double PosY;
        public List<Types> Heroes;
        public int AveragePowerLevel;
        public int NumberOfHeroes;

        

        public Tavern()
        {
            TavernID = 0;
            PosX = 0.0;
            PosY = 0.0;
            Heroes = new List<Types>();
            AveragePowerLevel = 0;
            NumberOfHeroes = 0;
        }
        public Tavern(int TavernID, double PosX, double PosY, List<Types> Heroes, int AveragePowerLevel, int NumberOfHeroes)
        {
            this.TavernID = TavernID;
            this.PosX = PosX;
            this.PosY = PosY;
            this.Heroes = Heroes;
            this.AveragePowerLevel = AveragePowerLevel;
            this.NumberOfHeroes = NumberOfHeroes;          
        }
    }
}
