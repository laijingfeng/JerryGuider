using Jerry;
using UnityEngine;

public class GameApp : MonoBehaviour
{
    void Awake()
    {
        MyTableLoader.Inst.LoadTables(() =>
        {
            GameLogicStart();
        });
    }

    void Start()
    {
    }

    private void GameLogicStart()
    {
        Table.TestA testA = null;
        if (TestATblMgr.Inst.TryGetValue(10000, out testA))
        {
            JerryDebug.Inst.LogInfo(testA, JerryDebug.LogTag.All, true);
        }
        else
        {
            Debug.LogError("not exist");
        }

        Table.TestB testB = null;
        if (TestBTblMgr.Inst.TryGetValue(TestBTblMgr.MakeKey(10000, 10000), out testB))
        {
            JerryDebug.Inst.LogInfo(testB, JerryDebug.LogTag.All, true);
        }
        else
        {
            Debug.LogError("not exist");
        }
    }
}