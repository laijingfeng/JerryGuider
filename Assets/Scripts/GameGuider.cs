using Jerry;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameGuider : MonoBehaviour
{
    #region UI

    private Transform m_Mask;
    private Transform m_Replacement;
    private Canvas m_GuiderCanvas;
    private Canvas m_FrontCanvas;
    private Transform m_Tip;
    private Text m_TipText;

    #endregion UI

    private uint id = 0;
    private bool awaked = false;
    private bool inited = false;
    private const int GameGuiderSortingOrder = 10;

    void Awake()
    {
        //可能跨场景，不能销毁
        DontDestroyOnLoad(this.gameObject);

        m_GuiderCanvas = this.transform.GetComponent<Canvas>();
        m_GuiderCanvas.sortingOrder = GameGuiderSortingOrder;
        m_FrontCanvas = this.transform.FindChild("Front").GetComponent<Canvas>();
        m_FrontCanvas.sortingOrder = GameGuiderSortingOrder + 2;

        m_Mask = this.transform.FindChild("Mask");
        m_Mask.gameObject.SetActive(false);
        m_Replacement = this.transform.FindChild("Replacement");
        m_Replacement.gameObject.SetActive(false);

        m_Tip = this.transform.FindChild("Front/Tip");
        m_Tip.gameObject.SetActive(false);
        m_TipText = m_Tip.FindChild("Text").GetComponent<Text>();

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
        if (!awaked || !inited || id == 0)
        {
            return;
        }

        if (GameGuiderMgr.Inst.LoadGuider(id))
        {
            RemoveOtherOpenUI();

            this.StopCoroutine("IE_FindCamera");
            this.StartCoroutine("IE_FindCamera");

            this.StopCoroutine("IE_BeginOneStep");
            this.StartCoroutine("IE_BeginOneStep");
        }
    }

    private IEnumerator IE_FindCamera()
    {
        GameObject cameraGo = null;
        Camera cameraS = null;
        while (true)
        {
            if(m_GuiderCanvas.worldCamera==null
                || m_GuiderCanvas.worldCamera.name.Equals(GameGuiderMgr.Inst.uiCameraName))
            {
                cameraGo = GameObject.Find(GameGuiderMgr.Inst.uiCameraName);
                if (cameraGo != null)
                {
                    cameraS = cameraGo.GetComponent<Camera>();
                    if (cameraS != null)
                    {
                        m_GuiderCanvas.worldCamera = cameraS;
                    }
                }
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    private IEnumerator IE_BeginOneStep()
    {
        if (GameGuiderMgr.Inst.IsInGuider())
        {
            if (m_GuiderCanvas == null || m_GuiderCanvas.worldCamera == null)
            {
                //等候相机
                yield return new WaitUntil(() => m_GuiderCanvas != null && m_GuiderCanvas.worldCamera != null);
            }
        }

        if (GameGuiderMgr.Inst.IsInGuider())//还在引导中
        {
            GuiderUI();
        }
        else//引导结束
        {
            GuiderFinish();
        }
    }

    /// <summary>
    /// 有些可能异常打开的UI，强制关闭
    /// </summary>
    private void RemoveOtherOpenUI()
    {
    }

    private void GuiderFinish()
    {
        this.StopCoroutine("IE_FindCamera");
    }

    #region GuiderUI

    private void GuiderUI()
    {

    }

    #endregion GuiderUI

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