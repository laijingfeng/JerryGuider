using Jerry;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameGuider : MonoBehaviour
{
    private uint id = 0;
    private bool awaked = false;
    private bool inited = false;

    void Awake()
    {
        //可能跨场景，不能销毁
        DontDestroyOnLoad(this.gameObject);
        awaked = true;
        TryWork();
    }

    private void InitData(uint id)
    {
        this.id = id;
        inited = true;
        TryWork();
    }

    private void TryWork()
    {
        if (!awaked || !inited)
        {
            return;
        }
    }

    #region 编辑器

#if UNITY_EDITOR

    public uint testLev = 0;
    public uint teseId = 0;

    [MenuItem("游戏引导/创建引导模块", false)]
    private static void CreateGameGuiderModule()
    {
        GameGuider.Register();
    }

    [ContextMenu("测试引导")]
    private void TestGuider()
    {
        if (testLev != 0)
        {
            teseId = GameGuiderMgr.Lev2GuiderId(testLev);
        }
        if (teseId != 0)
        {
            GameGuider.Register(teseId);
        }
    }

#endif

    #endregion 编辑器

    private static GameGuider guider = null;
    public static void Register(uint id = 0)
    {
        if (guider == null)
        {
            GameObject obj = Resources.Load<GameObject>("GameGuider");
            guider = JerryUtil.CloneGo<GameGuider>(new JerryUtil.CloneGoData()
            {
                active = true,
                clean = false,
                prefab = obj,
                name = "GameGuider",
            });
        }

        if (guider != null)
        {
            guider.InitData(id);
        }
    }
}