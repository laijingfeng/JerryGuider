using Jerry;
using Table;
using UnityEngine;

public class GameApp : SingletonMono<GameApp>
{
    public override void Awake()
    {
        base.Awake();
        MyTableLoader.Inst.LoadTables(() =>
        {
            GameLogicStart();
        });
    }

    private void GameLogicStart()
    {
        TestA testA = null;
        if (TestATblMgr.Inst.TryGetValue(10000, out testA))
        {
            JerryDebug.Inst.LogInfo(testA, JerryDebug.LogTag.All, true);
        }
        else
        {
            Debug.LogError("not exist");
        }

        TestB testB = null;
        if (TestBTblMgr.Inst.TryGetValue(TestBTblMgr.MakeKey(10000, 10000), out testB))
        {
            JerryDebug.Inst.LogInfo(testB, JerryDebug.LogTag.All, true);
        }
        else
        {
            Debug.LogError("not exist");
        }

        ServerCmdLoginRsp();
    }

    public void ServerCmdSetGuiderState(uint id = 0)
    {
        PlayerPrefs.SetInt("ServerGuiderState", (int)id);
    }

    private void ServerCmdLoginRsp()
    {
        int id = PlayerPrefs.GetInt("ServerGuiderState", 0);
        uint guiderId = (uint)id;
        if (guiderId != 0)
        {
            GameGuiderMgr.Inst.TryDoGuider(guiderId);
        }
    }
}