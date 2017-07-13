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