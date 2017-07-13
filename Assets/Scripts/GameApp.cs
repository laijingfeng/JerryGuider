using Jerry;
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