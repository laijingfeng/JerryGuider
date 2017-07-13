using Jerry;
using UnityEngine;
using UnityEngine.UI;
using Common;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameGuider : MonoBehaviour
{
    #region UI

    /// <summary>
    /// 遮罩
    /// </summary>
    private Transform m_Mask;
    private Transform m_Replacement;
    private Canvas m_GuiderCanvas;
    private Canvas m_FrontCanvas;
    private Transform m_Tip;
    private Text m_TipText;
    private Transform m_Anim;
    /// <summary>
    /// 通用UI动画，动画集，TODO
    /// </summary>
    private Transform m_AnimCommon;
    /// <summary>
    /// 特殊动画
    /// </summary>
    private Transform m_AnimSpecial;

    #endregion UI

    private const int GuiderCanvasSortingOrder = 10;
    /// <summary>
    /// 设置在相机视野内
    /// </summary>
    private const float GuiderCanvasPlaneDistance = 5;

    private uint id = 0;
    private bool awaked = false;
    private bool inited = false;
    private GameObject curTarget = null;
    /// <summary>
    /// 目标对象被加了Button组件，结束时要删除
    /// </summary>
    private bool curTargetAddButton = false;

    void Awake()
    {
        //可能跨场景，不能销毁
        DontDestroyOnLoad(this.gameObject);

        m_GuiderCanvas = this.transform.GetComponent<Canvas>();
        m_GuiderCanvas.sortingOrder = GuiderCanvasSortingOrder;
        m_FrontCanvas = this.transform.FindChild("Front").GetComponent<Canvas>();
        m_FrontCanvas.sortingOrder = GuiderCanvasSortingOrder + 2;

        m_Mask = this.transform.FindChild("Mask");
        m_Mask.gameObject.SetActive(false);
        m_Replacement = this.transform.FindChild("Replacement");
        m_Replacement.gameObject.SetActive(false);

        m_Tip = this.transform.FindChild("Front/Tip");
        m_Tip.gameObject.SetActive(false);
        m_TipText = m_Tip.FindChild("Text").GetComponent<Text>();

        m_Anim = this.transform.FindChild("Front/Anim");
        m_AnimCommon = m_Anim.FindChild("Common");
        m_AnimCommon.gameObject.SetActive(false);
        m_AnimSpecial = m_Anim.FindChild("Special");
        m_AnimSpecial.gameObject.SetActive(false);

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
            
            BeginCurStep();
        }
    }

    private IEnumerator IE_FindCamera()
    {
        GameObject cameraGo = null;
        Camera cameraS = null;
        while (true)
        {
            if (m_GuiderCanvas.worldCamera == null
                || m_GuiderCanvas.worldCamera.name.Equals(GameGuiderMgr.Inst.uiCameraName))
            {
                cameraGo = GameObject.Find(GameGuiderMgr.Inst.uiCameraName);
                if (cameraGo != null)
                {
                    cameraS = cameraGo.GetComponent<Camera>();
                    if (cameraS != null)
                    {
                        m_GuiderCanvas.worldCamera = cameraS;
                        m_GuiderCanvas.planeDistance = GuiderCanvasPlaneDistance;
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

    private void BeginCurStep()
    {
        this.StopCoroutine("IE_BeginCurStep");
        this.StartCoroutine("IE_BeginCurStep");
    }

    private IEnumerator IE_BeginCurStep()
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
        this.StopAllCoroutines();
        m_Tip.gameObject.SetActive(false);
        m_Mask.gameObject.SetActive(false);
        m_AnimSpecial.gameObject.SetActive(false);
        m_AnimCommon.gameObject.SetActive(false);
        curTarget = null;
    }

    private void StopGuider(bool stopServer = false)
    {
        UnHighLight();
        GameGuiderMgr.Inst.StopGuider(stopServer);
        GuiderFinish();
    }

    #region GuiderUI

    private void GuiderUI()
    {
        switch (GameGuiderMgr.Inst.curGuiderUI.begin_type)
        {
            case GuiderTriggerType.TRIGGER_AUTO:
                {
                    DoGuiderUI();
                }
                break;
            default:
                {
                    //wait msg
                }
                break;
        }
    }

    private void DoGuiderUI()
    {
        this.StopCoroutine("IE_HighLight");
        this.StartCoroutine("IE_HighLight");
    }

    private IEnumerator IE_HighLight()
    {
        //查找目标
        curTarget = null;
        if (!string.IsNullOrEmpty(GameGuiderMgr.Inst.curGuiderUI.node_path))
        {
            while (curTarget == null)
            {
                curTarget = GameObject.Find(GameGuiderMgr.Inst.curGuiderUI.node_path);
                yield return new WaitForSeconds(0.1f);
            }

            while (curTarget != null && curTarget.activeInHierarchy == false)
            {
                yield return new WaitForSeconds(0.1f);
            }
        }

        m_Mask.gameObject.SetActive(GameGuiderMgr.Inst.curGuiderUI.need_mask);
        ShowOrHideAnim(true);
        ShowOrHideTip(true);

        HighLight2D();
        this.StopCoroutine("IE_RefreshAnimPos");
        this.StartCoroutine("IE_RefreshAnimPos");
    }

    private void HighLight2D()
    {
        if (curTarget == null)
        {
            return;
        }

        //TODO:替代物

        //如果原来带有Canvas，岂不是要破坏？这种情况应该使用替代物
        Canvas tarCanvas = curTarget.GetComponent<Canvas>();
        if (tarCanvas == null)
        {
            tarCanvas = curTarget.AddComponent<Canvas>();
        }
        if (tarCanvas != null)
        {
            tarCanvas.overrideSorting = true;
            tarCanvas.sortingOrder = GuiderCanvasSortingOrder + 1;
        }

        //不加这个，原来curTarget上的UI事件检测将因为新的Canvas检测不到
        if (curTarget.GetComponent<GraphicRaycaster>() == null)
        {
            curTarget.AddComponent<GraphicRaycaster>();
        }

        //TRIGGER_AUTO的引导类型必然是点击型的
        if (GameGuiderMgr.Inst.curGuiderUI.end_type == GuiderTriggerType.TRIGGER_AUTO)
        {
            Button btn = curTarget.GetComponent<Button>();
            curTargetAddButton = false;
            if (btn == null)
            {
                btn = curTarget.AddComponent<Button>();
                curTargetAddButton = true;
            }
            if (btn != null)
            {
                btn.onClick.RemoveListener(OnCurTargetClick);
                btn.onClick.AddListener(OnCurTargetClick);
                //TODO:如果是原生的Button，是否可能之后有逻辑移除所有监听
                //TODO:是否可能原来没有Button，后续逻辑也添加Button
                //TODO:如果使用替代物体，事件穿透下去如何？但是有阻挡，另如何高亮替代物
            }
        }
    }

    /// <summary>
    /// 目标被点击
    /// </summary>
    private void OnCurTargetClick()
    {
        //防止连续点击
        if (curTarget != null)
        {
            Button btn = curTarget.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.RemoveListener(OnCurTargetClick);
            }
        }

        //TODO:play click audio if need

        FinishCurStep();
    }

    private IEnumerator IE_RefreshAnimPos()
    {
        if (curTarget == null)
        {
            yield break;
        }
        Vector3 followOffset = GameGuiderMgr.Vec3ToVector3(GameGuiderMgr.Inst.curGuiderUI.follow_offset);
        Vector3 targerPos = Vector3.zero;
        while (true)
        {
            if (curTarget == null)
            {
                break;
            }
            targerPos = JerryUtil.CalUIPosRelateToCanvas(curTarget.transform, true);
            m_Anim.localPosition = targerPos - JerryUtil.CalUIPosRelateToCanvas(m_Anim, false) + followOffset;
            yield return new WaitForEndOfFrame();//TODO
        }
    }

    /// <summary>
    /// 动画
    /// </summary>
    /// <param name="isShow"></param>
    private void ShowOrHideAnim(bool isShow)
    {
        m_AnimCommon.gameObject.SetActive(false);
        m_AnimSpecial.gameObject.SetActive(false);

        if (isShow == false)
        {
            return;
        }

        switch (GameGuiderMgr.Inst.curGuiderUI.ui_anim_type)
        {
            case GuiderAnimType.ANIM_TYPE_NONE:
                {
                    //nothing
                }
                break;
            case GuiderAnimType.ANIM_TYPE_CLICK:
                {
                    m_AnimCommon.gameObject.SetActive(true);
                }
                break;
            case GuiderAnimType.ANIM_TYPE_ATTACH:
                {
                    if (!string.IsNullOrEmpty(GameGuiderMgr.Inst.curGuiderUI.attach_ui))
                    {
                        //TODO:Load Attach UI
                        m_AnimSpecial.gameObject.SetActive(true);
                    }
                }
                break;
        }
    }

    /// <summary>
    /// 提示
    /// </summary>
    /// <param name="isShow"></param>
    private void ShowOrHideTip(bool isShow)
    {
        if (isShow == false)
        {
            m_Tip.gameObject.SetActive(false);
            return;
        }
        if (string.IsNullOrEmpty(GameGuiderMgr.Inst.curGuiderUI.tip_text))
        {
            m_Tip.gameObject.SetActive(false);
            return;
        }
        m_TipText.text = GameGuiderMgr.Inst.curGuiderUI.tip_text;
        m_Tip.localPosition = GameGuiderMgr.Vec3ToVector3(GameGuiderMgr.Inst.curGuiderUI.tip_pos);
    }

    public static void SendGuiderMsg(uint id)
    {
        //TODO:send event
    }

    /// <summary>
    /// 通过事件到达
    /// </summary>
    /// <param name="id"></param>
    private void HandleGuiderMsg(uint id)
    {
        if (!GameGuiderMgr.Inst.IsInGuider())
        {
            return;
        }
        Table.GuiderMsg msg = null;
        if (!GuiderMsgTblMgr.Inst.TryGetValue(id, out msg))
        {
            return;
        }
        if (!msg.guider_id_list.Contains(GameGuiderMgr.Inst.curGuiderUI.id))
        {
            return;
        }
        switch (msg.cmd)
        {
            case GuiderMsgCmd.MSG_CMD_OPEN:
                {
                    if (GameGuiderMgr.Inst.curGuiderUI.begin_type == GuiderTriggerType.TRIGGER_MSG)
                    {
                        DoGuiderUI();
                    }
                }
                break;
            case GuiderMsgCmd.MSG_CMD_CLOSE:
                {
                    if (GameGuiderMgr.Inst.curGuiderUI.end_type == GuiderTriggerType.TRIGGER_MSG)
                    {
                        FinishCurStep();
                    }
                }
                break;
            case GuiderMsgCmd.MSG_CMD_Reopen:
                {
                    //TODO:重做当前引导？是否还有必要
                }
                break;
        }
    }

    private void FinishCurStep()
    {
        if (!GameGuiderMgr.Inst.IsInGuider())
        {
            return;
        }
        UnHighLight();
        GameGuiderMgr.Inst.FinishCurStep();
        BeginCurStep();
    }

    private void UnHighLight()
    {
        ShowOrHideAnim(false);
        ShowOrHideTip(false);

        this.StopCoroutine("IE_RefreshAnimPos");
        this.StopCoroutine("IE_HighLight");

        //mask保持，直到下一次设置或者结束关闭

        UnHighLight2D();
    }

    private void UnHighLight2D()
    {
        if (curTarget == null)
        {
            return;
        }
        GraphicRaycaster gr = curTarget.GetComponent<GraphicRaycaster>();
        if (gr != null)
        {
            Destroy(gr);
        }
        Canvas canvas = curTarget.GetComponent<Canvas>();
        if (canvas != null)
        {
            Destroy(canvas);
        }
        if (GameGuiderMgr.Inst.curGuiderUI.end_type == GuiderTriggerType.TRIGGER_AUTO)
        {
            Button btn = curTarget.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.RemoveListener(OnCurTargetClick);
                if (curTargetAddButton)
                {
                    Destroy(btn);
                }
            }
        }
        curTargetAddButton = false;
        curTarget = null;
    }

    #endregion GuiderUI

    #region 编辑器

#if UNITY_EDITOR

    public uint testLev = 0;
    public uint teseId = 0;

    [MenuItem("游戏引导/创建引导模块", false)]
    private static void EditorCreateGameGuiderModule()
    {
        if (!Application.isPlaying)
        {
            Debug.LogWarning("运行时才可用");
            return;
        }
        GameGuider.Register();
    }

    [MenuItem("游戏引导/输出选中结点路径", false)]
    private static void GameGuiderPath()
    {
        Object[] obj = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.TopLevel);
        if (obj == null || obj.Length <= 0 || obj.Length > 1)
        {
            return;
        }

        GameObject go = obj[0] as GameObject;

        if (go == null)
        {
            return;
        }

        string path = GetPath(go.transform);

        Debug.LogWarning(string.Format("路径:{0}", path), obj[0]);
    }

    private static string GetPath(Transform tf)
    {
        if (tf == null)
        {
            return string.Empty;
        }
        string path = tf.name;
        while (tf.parent != null)
        {
            tf = tf.parent;
            if (string.IsNullOrEmpty(path))
            {
                path = tf.name;
            }
            else
            {
                path = tf.name + "/" + path;
            }
        }
        return path;
    }

    [ContextMenu("测试引导")]
    private void EditorTestGuider()
    {
        if (!Application.isPlaying)
        {
            Debug.LogWarning("运行时才可用");
            return;
        }
        if (testLev != 0)
        {
            teseId = GameGuiderMgr.Lev2GuiderId(testLev);
        }
        if (teseId != 0)
        {
            GameGuider.Register(teseId);
        }
    }

    [ContextMenu("跳过当前步")]
    private void EditorJumpCurStep()
    {
        if (!Application.isPlaying)
        {
            Debug.LogWarning("运行时才可用");
            return;
        }
        if (!GameGuiderMgr.Inst.IsInGuider())
        {
            Debug.LogWarning("当前没有引导");
            return;
        }
        FinishCurStep();
    }

    [ContextMenu("停止引导")]
    private void EditorStopGuider()
    {
        if (!Application.isPlaying)
        {
            Debug.LogWarning("运行时才可用");
            return;
        }
        if (!GameGuiderMgr.Inst.IsInGuider())
        {
            Debug.LogWarning("当前没有引导");
            return;
        }
        StopGuider();
    }

    [ContextMenu("停止引导_加服务器")]
    private void EditorStopGuider_ServerToo()
    {
        if (!Application.isPlaying)
        {
            Debug.LogWarning("运行时才可用");
            return;
        }
        if (!GameGuiderMgr.Inst.IsInGuider())
        {
            Debug.LogWarning("当前没有引导");
            return;
        }
        StopGuider(true);
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