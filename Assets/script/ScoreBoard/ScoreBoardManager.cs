using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardManager : MonoBehaviour
{
    public GameObject rowPrefab;
    public Transform rowsParent;

    private void Start()
    {
        GiveRandomScore();

    }


    public List<Score> GetScoreBoard(string music)
    {
        var reader = new StreamReader(File.OpenRead(@".\Assets\Audio\" + music + "\\Classeur1.csv"));
        List<string> listA = new List<string>();
        List<string> listB = new List<string>();
        List<Score> AllScore = new List<Score>();
        while (!reader.EndOfStream)
        {
        var line = reader.ReadLine();
        var values = line.Split(';');
        listA.Add(values[0]);
        listB.Add(values[1]);
        }
        for(int i = 0; i < listA.Count; i++)
        {
            Score score = new Score();
            score.Name = listA[i];
            score.Scoring = Int32.Parse(listB[i]);
            AllScore.Add(score);
        }
        foreach(Score score in AllScore)
        {
            Debug.Log(score);
        }
        return AllScore;

    }

    void OnScoreboardGet()
    {

    }

    public Scores GiveRandomScore()
    {
        GameObject[] btn = GameObject.FindGameObjectsWithTag("Music");
        string[] AllPseudo = new string[9] { "Cedric", "Jordan", "Felicien", "Francois", "Guillaume", "Mathieu", "Valentin", "Henri", "Line" };

        Scores scores = new Scores();

        List<Score> AllScore = new List<Score>();
        foreach (GameObject music in btn)
        {
            string Title = music.transform.Find("Title").GetComponent<Text>().text;
            for (int i = 0; i < AllPseudo.Length; i++)
            {
                Score randomscore = new Score(AllPseudo[i], UnityEngine.Random.Range(1, 100000));
                AllScore.Add(randomscore);
                TextWriter tw = new StreamWriter(".\\Assets\\Audio\\" + Title + "\\Highscore.csv", true);
                tw.WriteLine(randomscore.Name + ";" + randomscore.Scoring.ToString());
                //tw.Write("");
                tw.Close();
            }
        }
        scores.Allscores = AllScore;
        return scores;
    }


    public struct Scores
    {
        public List<Score> Allscores;
    }

    public struct Score
    {
        public string Name;
        public int Scoring;

        public Score(string pseudo, int scoring)
        {
            this.Name = pseudo;
            this.Scoring = scoring;
        }
    }

}
