using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ElectionManager : MonoBehaviour
{
    [SerializeField] private BulletinReader bulletinReader;
    [SerializeField] private BulletinDetail bulletinDetail;

    private Dictionary<int, Bulletin> bulletinDatabase;
    private int currentBulletinNum = 0;
    private int maxBulletinNum;

    void Start()
    {
        //MockData();
    }

    public Bulletin GetBulletin(int num)
    {
        if (bulletinDatabase.ContainsKey(num))
		{
            return bulletinDatabase[num];
		}
        Debug.Log(":((");
        return bulletinDatabase[0];
    }

    private void MockData()
    {
        Bulletin bulletin1 = new Bulletin(Mention.TB, Mention.TB, Mention.B, Mention.AB, Mention.P, Mention.I);
        Bulletin bulletin2 = new Bulletin(Mention.AR, Mention.AR, Mention.P, Mention.AB, Mention.P, Mention.I);
        Bulletin bulletin3 = new Bulletin(Mention.TB, Mention.TB, Mention.AB, Mention.AB, Mention.P, Mention.I);
        Bulletin bulletin4 = new Bulletin(Mention.B, Mention.B, Mention.B, Mention.B, Mention.B, Mention.B);
        Bulletin bulletin5 = new Bulletin(Mention.AB, Mention.P, Mention.P, Mention.P, Mention.TB, Mention.I);
        Bulletin bulletin6 = new Bulletin(Mention.AB, Mention.P, Mention.P, Mention.P, Mention.B, Mention.P);
        Bulletin bulletin7 = new Bulletin(Mention.P, Mention.AB, Mention.P, Mention.I, Mention.TB, Mention.TB);
        Bulletin bulletin8 = new Bulletin(Mention.I, Mention.I, Mention.P, Mention.I, Mention.AB, Mention.AB);
        Bulletin bulletin9 = new Bulletin(Mention.TB, Mention.B, Mention.P, Mention.P, Mention.AB, Mention.B);
        Bulletin bulletin10 = new Bulletin(Mention.TB, Mention.P, Mention.P, Mention.I, Mention.B, Mention.I);
        maxBulletinNum = 10;
        bulletinDatabase = new Dictionary<int, Bulletin>(maxBulletinNum);
        bulletinDatabase.Add(1,bulletin1);
        bulletinDatabase.Add(2,bulletin2);
        bulletinDatabase.Add(3,bulletin3);
        bulletinDatabase.Add(4,bulletin4);
        bulletinDatabase.Add(5,bulletin5);
        bulletinDatabase.Add(6,bulletin6);
        bulletinDatabase.Add(7,bulletin7);
        bulletinDatabase.Add(8,bulletin8);
        bulletinDatabase.Add(9,bulletin9);
        bulletinDatabase.Add(10,bulletin10);
    }

    public void GoToNextBulletin(InputAction.CallbackContext context)
    {
        
        if (context.phase == InputActionPhase.Started )
        {
            if (currentBulletinNum < maxBulletinNum)
            {
                currentBulletinNum ++;
                Bulletin bulletin = GetBulletin(currentBulletinNum);
                bulletinReader.AddBulletin(bulletin);
                bulletinDetail.UpdateNum(currentBulletinNum);
                bulletinDetail.DisplayBulletin(bulletin);
                bulletinReader.ComputeMentionScores(currentBulletinNum);
            }
        }  
    }

    public void GoToPrevBulletin(InputAction.CallbackContext context)
    {
        
        if (context.phase == InputActionPhase.Started )
        {
            if (currentBulletinNum > 1)
            {
                bulletinReader.RemoveBulletin(GetBulletin(currentBulletinNum));
                currentBulletinNum --;
                bulletinDetail.UpdateNum(currentBulletinNum);
                bulletinDetail.DisplayBulletin(GetBulletin(currentBulletinNum));
                bulletinReader.ComputeMentionScores(currentBulletinNum);
            }
        }  
    }

    public void SetMaxBulletinNum(int newValue)
    {
        maxBulletinNum = newValue;
    }

    public void InitializeEmptyDictionary(int size)
    {
        bulletinDatabase = new Dictionary<int, Bulletin>(size);
    }

    public void AddToDictionary(int key, Bulletin value)
    {
        bulletinDatabase.Add(key,value);
    }

}

