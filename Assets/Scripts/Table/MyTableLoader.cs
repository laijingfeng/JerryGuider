using System;
using System.Collections;
using Jerry;
using Table;
using UnityEngine;

public class MyTableLoader : TableLoader<MyTableLoader>
{
    public MyTableLoader()
        : base()
    {
        AddLoader(new Loader(TestATblMgr.Inst, "Table/c_table_TestA"));
        AddLoader(new Loader(TestBTblMgr.Inst, "Table/c_table_TestB"));
        AddLoader(new Loader(GuiderTblMgr.Inst, "Table/c_table_Guider"));
        AddLoader(new Loader(GuiderUITblMgr.Inst, "Table/c_table_GuiderUI"));
        AddLoader(new Loader(GuiderMsgTblMgr.Inst, "Table/c_table_GuiderMsg"));
        //AddLoader(new Loader(XXXTblMgr.Inst, "Table/c_table_XXX"));
    }

    protected override IEnumerator IE_LoadTables(Action allTblComplete = null)
    {
        yield return base.IE_LoadTables(allTblComplete);

        foreach (Loader loader in _loaders)
        {
            //Load tables start
            TextAsset tex = Resources.Load<TextAsset>(loader.resPath);
            if (loader.loadedCallback != null)
            {
                loader.loadedCallback(tex);
            }
            //Load tables end
        }
        yield return this.WaitAllTableLoaded();
    }
}

public class TestATblMgr : TableManager<TestA_ARRAY, TestA, int, TestATblMgr>
{
    protected override int GetKey(TestA table)
    {
        return table.id;
    }
}

public class TestBTblMgr : TableManager<TestB_ARRAY, TestB, long, TestBTblMgr>
{
    public static long MakeKey(int id1, int id2)
    {
        return (((long)id1) << 32) + id2;
    }

    protected override long GetKey(TestB table)
    {
        return MakeKey(table.id1, table.id2);
    }
}

public class GuiderTblMgr : TableManager<Guider_ARRAY, Guider, uint, GuiderTblMgr>
{
    protected override uint GetKey(Guider table)
    {
        return table.id;
    }
}

public class GuiderUITblMgr : TableManager<GuiderUI_ARRAY, GuiderUI, uint, GuiderUITblMgr>
{
    protected override uint GetKey(GuiderUI table)
    {
        return table.id;
    }
}

public class GuiderMsgTblMgr : TableManager<GuiderMsg_ARRAY, GuiderMsg, uint, GuiderMsgTblMgr>
{
    protected override uint GetKey(GuiderMsg table)
    {
        return table.id;
    }
}

//模版
//public class XXXTblMgr : TableManager<XXX_ARRAY, XXX, uint, XXXTblMgr>//TODO:返回值
//{
//    protected override uint GetKey(XXX table)//TODO:返回值
//    {
//        return table.id;//TODO:具体Key
//    }
//}