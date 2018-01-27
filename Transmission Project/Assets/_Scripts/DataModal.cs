using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class DataModal : MonoBehaviour {
    
    private string Missions;
    public List<Mission> MissionsData;
    public TextAsset MissionCSVFile;
	// Use this for initialization
	void Start () {
        MissionsData = new List<Mission>();
        InitiateMissions();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitiateMissions()
    {
        string[] lines = MissionCSVFile.text.Split("\n"[0]);
        for (int i =0; i< lines.Length; i++)
        {
            if (i != 0)
            {
                string[] Missioncharac = lines[i].Split(',');
                int NbHeros = 0;
                //Compter le nombre de heros
                int Id = System.Int32.Parse(Missioncharac[0]);
                int Power = System.Int32.Parse(Missioncharac[9]);
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
                    }
                }
                MissionsData.Add(new Mission(HeroesType.Count, Id, HeroesType.ToArray(), Power));
            }
        }
    }
    public class Mission
    {
        public int NbHeros;
        public int ClassID;
        public Types[] HeroesRequired;
        public int MissionLevel;

        public Mission()
        {
            NbHeros = 0;
            ClassID = 0;
            HeroesRequired = new Types[NbHeros];
            MissionLevel = 0;
        }
        public Mission(int NbHeroes, int ClassId, Types[] HeroesRequired, int MissionLevel)
        {
            this.NbHeros = NbHeroes;
            this.ClassID = ClassId;
            this.HeroesRequired = HeroesRequired;
            this.MissionLevel = MissionLevel;
        }
    }
}
