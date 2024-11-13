using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class JsonParser : MonoBehaviour
{
    [SerializeField] private ElectionManager electionManager;

    void Start()
    {
        ReadJSON();
    }

    private void ReadJSON()
    {
        string jsonContent = Resources.Load<TextAsset>("results").text;
        JSONNode json = JSON.Parse(jsonContent);
        int size = json.Count;
        electionManager.SetMaxBulletinNum(size);
        electionManager.InitializeEmptyDictionary(size);
        Mention mentionL1, mentionL2, mentionL3, mentionL4, mentionL5, mentionL6;
        for (int i = 0; i < size; i++)
        {
            mentionL1 = ConvertToMention(json[i][0]);
            mentionL2 = ConvertToMention(json[i][1]);
            mentionL3 = ConvertToMention(json[i][2]);
            mentionL4 = ConvertToMention(json[i][3]);
            mentionL5 = ConvertToMention(json[i][4]);
            mentionL6 = ConvertToMention(json[i][5]);
            Bulletin bulletin = new Bulletin(mentionL1, mentionL2, mentionL3, mentionL4, mentionL5, mentionL6);
            electionManager.AddToDictionary(i + 1, bulletin);
        }
    }

    private Mention ConvertToMention(string stringMention)
    {
        Mention mention;
        switch(stringMention)
        {
            case "TB":
                mention = Mention.TB;
                break;
            case "B":
                mention = Mention.B;
                break;
            case "AB":
                mention = Mention.AB;
                break;
            case "P":
                mention = Mention.P;
                break;
            case "I":
                mention = Mention.I;
                break;
            case "AR":
                mention = Mention.AR;
                break;
            default:
                Debug.Log(":((((");
                mention = Mention.TB;
                break;
        }
        return mention;
    }
}