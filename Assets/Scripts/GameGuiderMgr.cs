﻿using Jerry;

public class GameGuiderMgr : Singleton<GameGuiderMgr>
{
    public Table.Guider curGuider = null;
    public Table.GuiderUI curGuiderUI = null;
    private uint nextGuiderId = 0;

    private void CleanCurGuider()
    {
        curGuider = null;
        curGuiderUI = null;
    }

    #region 对外接口

    public bool IsInGuider()
    {
        return curGuider != null;
    }

    public bool IsInServerGuider()
    {
        return IsInGuider() && curGuider.is_server;
    }

    public bool IsNowGuiderUI(uint id)
    {
        return IsInGuider() && curGuiderUI != null && curGuiderUI.id == id;
    }

    public bool IsHaveDirtyGuider()
    {
        return nextGuiderId != 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    public void MarkNextGuider(uint id = 0)
    {
        if (id == 0)
        {
            nextGuiderId = id;
            return;
        }

        Table.Guider guiderTbl = null;
        if (!GuiderTblMgr.Inst.TryGetValue(id, out guiderTbl))
        {
            return;
        }
        nextGuiderId = id;

        //Mark的时候提前告诉服务器
        if (guiderTbl.is_server)
        {
            SetServerGuiderState(nextGuiderId);
        }
    }

    public void TryDoDirtyGuider()
    {
        if (nextGuiderId == 0)
        {
            return;
        }
        TryDoGuider(nextGuiderId);
        MarkNextGuider();
    }

    public void TryDoGuider(uint id)
    {
        Table.Guider guiderTbl = null;
        if (!GuiderTblMgr.Inst.TryGetValue(id, out guiderTbl))
        {
            return;
        }

        GameGuider.Register(id);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id">0是标空</param>
    public void SetServerGuiderState(uint id = 0)
    {
        GameApp.Inst.ServerCmdSetGuiderState(id);
    }

    public static uint Lev2GuiderId(uint lev)
    {
        return 10000 + lev * 10;
    }

    public bool LoadGuider(uint id)
    {
        if (!GuiderTblMgr.Inst.TryGetValue(id, out curGuider))
        {
            CleanCurGuider();
            return false;
        }
        if (!GuiderUITblMgr.Inst.TryGetValue(curGuider.guiderUI_id, out curGuiderUI))
        {
            CleanCurGuider();
            return false;
        }
        if (curGuider.is_server)
        {
            SetServerGuiderState(curGuider.id);
        }
        return true;
    }

    public void FinishStep()
    {
        if (curGuiderUI != null)
        {
            if (curGuiderUI.send_finish)
            {
                TrySetServerFinish();
            }
            GuiderUITblMgr.Inst.TryGetValue(curGuiderUI.next_id, out curGuiderUI);
        }

        //当前串UI做完了，看下一个
        if (curGuiderUI == null)
        {
            TrySetServerFinish();
            
            if (GuiderTblMgr.Inst.TryGetValue(curGuider.next_id, out curGuider))
            {
                LoadGuider(curGuider.id);
            }
            else//连续的都做完了
            {
                CleanCurGuider();
            }
        }
    }

    public void RefreshStep()
    {
        if (curGuiderUI != null)
        {
            if (GuiderUITblMgr.Inst.TryGetValue(curGuiderUI.next_id, out curGuiderUI))
            {
                return;
            }
        }
        else
        {
            Table.Guider nextGuider = null;
            if (GuiderTblMgr.Inst.TryGetValue(curGuider.next_id, out nextGuider))
            {
                LoadGuider(nextGuider.id);
                return;
            }
            else
            {
                TrySetServerFinish();
            }
        }
        CleanCurGuider();
    }

    private void TrySetServerFinish()
    {
        //如果有了NextGuider，不能覆盖掉
        if (!IsHaveDirtyGuider() && curGuider != null && curGuider.is_server)
        {
            SetServerGuiderState();
        }
    }

    #endregion 对外接口
}