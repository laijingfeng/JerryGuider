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
    /// <summary>
    /// 替代物
    /// </summary>
    private RectTransform m_Replacement;
    private Canvas m_GuiderCanvas;
    private Canvas m_FrontCanvas;
    private Transform m_Tip;
    private Text m_TipText;
    private Transform m_Anim;
    /// <summary>
    /// 通用UI动画，动画集
    /// </summary>
    private Transform m_AnimCommon;
    private Animator m_AnimCommonCtr;
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
        m_Replacement = this.transform.FindChild("Replacement") as RectTransform;
        UGUIEventListener.Get(m_Replacement.gameObject).onClick += (go) =>
        {
            if (!GameGuiderMgr.Inst.IsInGuider())
            {
                return;
            }
            if (!GameGuiderMgr.Inst.curGuiderUI.use_replacement)
            {
                return;
            }
            FinishCurStep();
        };
        m_Replacement.gameObject.SetActive(false);

        m_Tip = this.transform.FindChild("Front/Tip");
        m_Tip.gameObject.SetActive(false);
        m_TipText = m_Tip.FindChild("Text").GetComponent<Text>();

        m_Anim = this.transform.FindChild("Front/Anim");
        m_AnimCommon = m_Anim.FindChild("Common");
        m_AnimCommon.gameObject.SetActive(true);
        m_AnimCommonCtr = m_AnimCommon.GetComponent<Animator>();
        m_AnimSpecial = m_Anim.FindChild("Special");
        m_AnimSpecial.gameObject.SetActive(false);

        JerryEventMgr.AddEvent(GameGuiderMgr.GuiderEventType.GuiderMsg.ToString(), EventGuiderMsg);
        awaked = true;
        TryWork();
    }

    void OnDestroy()
    {
        JerryEventMgr.RemoveEvent(GameGuiderMgr.GuiderEventType.GuiderMsg.ToString(), EventGuiderMsg);
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
        JerryEventMgr.DispatchEvent(GameGuiderMgr.GuiderEventType.ForceRemoveOtherUI.ToString());
    }

    private void GuiderFinish()
    {
        this.StopAllCoroutines();
        m_Tip.gameObject.SetActive(false);
        m_Mask.gameObject.SetActive(false);
        m_AnimSpecial.gameObject.SetActive(false);
        SetAnimCommon(GuiderAnimType.ANIM_TYPE_NONE);
        curTarget = null;
    }

    private void StopGuider(bool stopServer = false)
    {
        UnHighLight();
        GameGuiderMgr.Inst.StopGuider(stopServer);
        GuiderFinish();
    }

    private void SetAnimCommon(GuiderAnimType type)
    {
        if (m_AnimCommonCtr != null)
        {
            m_AnimCommonCtr.SetInteger("id", type.GetHashCode());
        }
    }

    #region 事件

    private void EventGuiderMsg(object[] args)
    {
        FinishCurStep();
    }

    #endregion 事件

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

        if (GameGuiderMgr.Inst.curGuiderUI.begin_event != null)
        {
            SendGuiderEvent(GameGuiderMgr.Inst.curGuiderUI.begin_event);
        }

        if (GameGuiderMgr.Inst.curGuiderUI.use_replacement)
        {
            HighLightReplacement();
        }
        else if (!GameGuiderMgr.Inst.curGuiderUI.is_3d)
        {
            HighLight2D();
        }

        this.StopCoroutine("IE_RefreshAnimAndReplacementPos");
        this.StartCoroutine("IE_RefreshAnimAndReplacementPos");
    }

    private void SendGuiderEvent(GuiderEvent ge)
    {
        if (ge == null)
        {
            return;
        }
        JerryEventMgr.DispatchEvent(ge.name, new object[] { ge.par });
    }

    private void HighLightReplacement()
    {
        if (GameGuiderMgr.Inst.curGuiderUI.use_replacement)
        {
            m_Replacement.localPosition = Vector3.zero;
            m_Replacement.sizeDelta = GameGuiderMgr.Vec3ToVector3(GameGuiderMgr.Inst.curGuiderUI.replacement_size);
            m_Replacement.gameObject.SetActive(true);
        }
    }

    private void HighLight2D()
    {
        if (curTarget == null)
        {
            return;
        }

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

        //TODO: play click audio if need

        FinishCurStep();
    }

    private IEnumerator IE_RefreshAnimAndReplacementPos()
    {
        if (curTarget == null)
        {
            yield break;
        }

        if (GameGuiderMgr.Inst.curGuiderUI.is_3d)
        {
            if (string.IsNullOrEmpty(GameGuiderMgr.Inst.curGuiderUI.camera_3d))
            {
                yield break;
            }
        }

        Vector3 followOffset = GameGuiderMgr.Vec3ToVector3(GameGuiderMgr.Inst.curGuiderUI.follow_offset);
        Vector3 replacementOffset = Vector3.zero;
        if (GameGuiderMgr.Inst.curGuiderUI.use_replacement)
        {
            replacementOffset = GameGuiderMgr.Vec3ToVector3(GameGuiderMgr.Inst.curGuiderUI.replacement_offset);
        }
        Vector3 targerPos = Vector3.zero;
        GameObject camera3DGo = null;
        Camera camera3D = null;

        while (true)
        {
            if (curTarget == null)
            {
                break;
            }

            if (GameGuiderMgr.Inst.curGuiderUI.is_3d)
            {
                if (camera3D == null)
                {
                    camera3DGo = GameObject.Find(GameGuiderMgr.Inst.curGuiderUI.camera_3d);
                    if (camera3DGo != null)
                    {
                        camera3D = camera3DGo.GetComponent<Camera>();
                    }
                }
                if (camera3D != null)
                {
                    targerPos = camera3D.WorldToScreenPoint(curTarget.transform.position);
                    m_Anim.localPosition = JerryUtil.PosScreen2Canvas(m_GuiderCanvas, targerPos, m_Anim) + followOffset;
                    if (GameGuiderMgr.Inst.curGuiderUI.use_replacement)
                    {
                        m_Replacement.localPosition = JerryUtil.PosScreen2Canvas(m_GuiderCanvas, targerPos, m_Replacement) + replacementOffset;
                    }
                }
            }
            else
            {
                targerPos = JerryUtil.CalUIPosRelateToCanvas(curTarget.transform, true);
                m_Anim.localPosition = targerPos - JerryUtil.CalUIPosRelateToCanvas(m_Anim, false) + followOffset;
                if (GameGuiderMgr.Inst.curGuiderUI.use_replacement)
                {
                    m_Replacement.localPosition = targerPos - JerryUtil.CalUIPosRelateToCanvas(m_Replacement.transform, false) + replacementOffset;
                }
            }

            switch (GameGuiderMgr.Inst.curGuiderUI.follow_type)
            {
                case GuiderFollowType.FOLLOW_ONCE:
                    {
                        yield break;
                    }
                case GuiderFollowType.FOLLOW_FRAME:
                    {
                        yield return new WaitForEndOfFrame();
                    }
                    break;
                case GuiderFollowType.FOLLOW_TIME:
                    {
                        yield return new WaitForSeconds(0.1f);
                    }
                    break;
            }
        }
    }

    /// <summary>
    /// 动画
    /// </summary>
    /// <param name="isShow"></param>
    private void ShowOrHideAnim(bool isShow)
    {
        SetAnimCommon(GuiderAnimType.ANIM_TYPE_NONE);
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
                    SetAnimCommon(GameGuiderMgr.Inst.curGuiderUI.ui_anim_type);
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
        m_Tip.gameObject.SetActive(true);
    }

    public static void SendGuiderMsg(uint id)
    {
        JerryEventMgr.DispatchEvent(GameGuiderMgr.GuiderEventType.GuiderMsg.ToString(), new object[] { id });
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
                    GameGuiderMgr.Inst.TryDoGuider(GameGuiderMgr.Inst.curGuider.id);
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

        if (GameGuiderMgr.Inst.curGuiderUI.end_event != null)
        {
            SendGuiderEvent(GameGuiderMgr.Inst.curGuiderUI.begin_event);
        }

        this.StopCoroutine("IE_RefreshAnimAndReplacementPos");
        this.StopCoroutine("IE_HighLight");

        //mask保持，直到下一次设置或者结束关闭
        if (GameGuiderMgr.Inst.curGuiderUI.use_replacement)
        {
            UnHighLightReplacement();
        }
        else if (!GameGuiderMgr.Inst.curGuiderUI.is_3d)
        {
            UnHighLight2D();
        }
    }

    private void UnHighLightReplacement()
    {
        m_Replacement.gameObject.SetActive(false);
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

    [ContextMenu("当前引导信息")]
    private void EditorCurGuider()
    {
        if (!Application.isPlaying)
        {
            Debug.LogWarning("运行时才可用");
            return;
        }
        if (!GameGuiderMgr.Inst.IsInGuider())
        {
            JerryDebug.Inst.LogInfo("不在引导中");
            return;
        }
        JerryDebug.Inst.LogInfo(GameGuiderMgr.Inst.curGuider, JerryDebug.LogTag.All, true);
        JerryDebug.Inst.LogInfo(GameGuiderMgr.Inst.curGuiderUI, JerryDebug.LogTag.All, true);
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