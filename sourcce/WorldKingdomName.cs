// Decompiled with JetBrains decompiler
// Type: WorldKingdomName
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class WorldKingdomName
{
  private GameObject NameGameObject;
  private RectTransform NameRectTransform;
  private WorldMapText NameText;
  private UIText text_Info;
  private CString TitleString;
  private CString InfoString;
  private Image NamePosImage;
  private RectTransform textrtf;
  private RectTransform textrtf_Info;
  private ushort WorldKingdomTableID;
  private long WorldKingdomTime;

  public WorldKingdomName(Transform parentLayout, Vector2 inipos, Vector2 testsize)
  {
    GameObject gameObject1 = new GameObject("name");
    this.NameRectTransform = gameObject1.AddComponent<RectTransform>();
    Vector3 one = Vector3.one;
    if (GUIManager.Instance.IsArabic)
      one.x = -1f;
    ((Transform) this.NameRectTransform).localScale = one;
    ((Transform) this.NameRectTransform).SetParent(parentLayout, false);
    ((Transform) this.NameRectTransform).localPosition = (Vector3) inipos;
    this.NameGameObject = gameObject1;
    GameObject gameObject2 = new GameObject("nameText");
    this.NameText = gameObject2.AddComponent<WorldMapText>();
    gameObject2.AddComponent<Outline>();
    this.NameText.font = GUIManager.Instance.GetTTFFont();
    this.NameText.fontSize = 30;
    this.NameText.alignment = TextAnchor.MiddleLeft;
    this.NameText.resizeTextForBestFit = true;
    this.NameText.resizeTextMaxSize = 30;
    this.TitleString = new CString(148);
    this.textrtf = gameObject2.transform as RectTransform;
    this.textrtf.sizeDelta = testsize;
    this.textrtf.anchoredPosition = new Vector2(128f, -20f);
    ((Transform) this.textrtf).SetParent((Transform) this.NameRectTransform, false);
    GameObject gameObject3 = new GameObject("TextInfo");
    this.text_Info = gameObject3.AddComponent<UIText>();
    gameObject3.AddComponent<Outline>();
    this.text_Info.font = GUIManager.Instance.GetTTFFont();
    this.text_Info.fontSize = 24;
    this.text_Info.alignment = TextAnchor.UpperLeft;
    this.text_Info.resizeTextForBestFit = true;
    this.text_Info.resizeTextMaxSize = 24;
    ((Graphic) this.text_Info).color = new Color(1f, 0.984f, 0.576f);
    this.InfoString = new CString(264);
    this.textrtf_Info = gameObject3.transform as RectTransform;
    this.textrtf_Info.anchorMax = new Vector2(0.0f, 1f);
    this.textrtf_Info.anchorMin = new Vector2(0.0f, 1f);
    this.textrtf_Info.pivot = new Vector2(0.0f, 1f);
    this.textrtf_Info.sizeDelta = testsize;
    this.textrtf_Info.anchoredPosition = new Vector2(-78f, -95f);
    ((Transform) this.textrtf_Info).SetParent((Transform) this.NameRectTransform, false);
    this.NameGameObject.SetActive(false);
    this.NamePosImage = (Image) null;
    this.WorldKingdomTableID = (ushort) 0;
    this.WorldKingdomTime = 0L;
  }

  public void Release()
  {
    this.NameGameObject = (GameObject) null;
    this.NameRectTransform = (RectTransform) null;
    this.NameText = (WorldMapText) null;
    this.text_Info = (UIText) null;
    this.TitleString = (CString) null;
    this.InfoString = (CString) null;
  }

  public void updateName(byte SetKingdomTableID, Image NamePos, Color textcolor, Vector2 pos)
  {
    this.updateName(SetKingdomTableID, NamePos, textcolor);
    this.updateName(pos);
  }

  public void updateName(byte SetKingdomTableID, Image NamePos, Color textcolor)
  {
    this.updateName(textcolor);
    this.updateName(SetKingdomTableID, NamePos);
  }

  public void updateName(byte SetKingdomTableID, Image NamePos)
  {
    if (!this.NameGameObject.activeSelf)
      this.NameGameObject.SetActive(true);
    if ((Object) NamePos == (Object) null)
    {
      if ((Object) this.NamePosImage != (Object) null)
      {
        ((Component) this.NamePosImage).gameObject.SetActive(false);
        ((Component) this.NamePosImage).transform.SetParent(((Transform) this.NameRectTransform).parent, false);
      }
    }
    else if ((Object) this.NamePosImage == (Object) null)
      ((Component) NamePos).transform.SetParent((Transform) this.NameRectTransform, false);
    this.NamePosImage = NamePos;
    KingdomMap recordByKey1 = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingdomID);
    int num1 = (int) DataManager.MapDataController.WorldMaxX - (int) DataManager.MapDataController.WorldMinX + 1;
    this.WorldKingdomTableID = (ushort) ((int) recordByKey1.worldPosX - (int) DataManager.MapDataController.WorldMinX + ((int) recordByKey1.worldPosY - (int) DataManager.MapDataController.WorldMinY) * num1);
    this.TitleString.ClearString();
    if ((Object) this.NamePosImage != (Object) null)
    {
      this.TitleString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(8246U));
      this.textrtf.sizeDelta = new Vector2(512f, 215f);
      this.textrtf.anchoredPosition = new Vector2(128f, 0.0f);
    }
    else
    {
      this.textrtf.sizeDelta = new Vector2(512f, 178f);
      this.textrtf.anchoredPosition = new Vector2(128f, -20f);
    }
    if (DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
    {
      this.TitleString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingdomName);
      if ((Object) this.NamePosImage == (Object) null)
        this.TitleString.AppendFormat("{0}");
      else
        this.TitleString.AppendFormat("        {0}\n{1}");
    }
    else
    {
      this.TitleString.IntToFormat((long) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingdomID);
      if (GUIManager.Instance.IsArabic)
      {
        this.TitleString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(8247U));
        this.TitleString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingdomName);
      }
      else
      {
        this.TitleString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingdomName);
        this.TitleString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(8247U));
      }
      if ((Object) this.NamePosImage == (Object) null)
        this.TitleString.AppendFormat("#{0} {1} {2}");
      else
        this.TitleString.AppendFormat("        {0}\n#{1} {2} {3}");
    }
    this.NameText.text = this.TitleString.ToString();
    this.NameText.SetAllDirty();
    this.NameText.cachedTextGenerator.Invalidate();
    this.InfoString.ClearString();
    if (DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
    {
      this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(11038U));
      if (ActivityManager.Instance.IsKOWRunning() || DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingName == null || DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingName.Length == 0 || DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingName[0] == char.MinValue)
      {
        this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(5334U));
        this.InfoString.AppendFormat("{0}{1}");
      }
      else if (DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceKingdomID == (ushort) 0)
      {
        if (GUIManager.Instance.IsArabic)
        {
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingName);
          this.InfoString.AppendFormat("{0}{1}");
        }
        else
        {
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingName);
          this.InfoString.AppendFormat("{0}{1}");
        }
      }
      else if ((int) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingKingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID)
      {
        if (GUIManager.Instance.IsArabic)
        {
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingName);
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceTag);
          this.InfoString.AppendFormat("{0}{1}[{2}]");
        }
        else
        {
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceTag);
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingName);
          this.InfoString.AppendFormat("{0}[{1}]{2}");
        }
      }
      else if (GUIManager.Instance.IsArabic)
      {
        this.InfoString.IntToFormat((long) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingKingdomID);
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingName);
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceTag);
        this.InfoString.AppendFormat("{0}#{1} {2} [{3}]");
      }
      else
      {
        this.InfoString.IntToFormat((long) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingKingdomID);
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceTag);
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingName);
        this.InfoString.AppendFormat("{0}#{1} [{2}]{3}");
      }
    }
    else
    {
      byte InKey = (byte) ((uint) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingdomFlag >> 3);
      if (InKey > (byte) 0)
      {
        TitleData recordByKey2 = DataManager.Instance.TitleDataN.GetRecordByKey((ushort) InKey);
        this.InfoString.StringToFormat("<color=#FFFF00>");
        this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey2.StringID));
        this.InfoString.StringToFormat("</color>");
      }
      this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(676U));
      if (DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceTag == null || DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceTag.Length == 0 || DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceTag[0] == char.MinValue)
      {
        this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(5334U));
        this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677U));
        this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(5334U));
        if (InKey > (byte) 0)
          this.InfoString.AppendFormat("{0}{1}{2}\n{3}{4}\n{5}{6}");
        else
          this.InfoString.AppendFormat("{0}{1}\n{2}{3}");
      }
      else if ((int) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceKingdomID == (int) DataManager.Instance.RoleAlliance.KingdomID && (int) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingKingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID)
      {
        if (GUIManager.Instance.IsArabic)
        {
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceName);
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceTag);
          if (((int) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingdomFlag & 1) == 0)
            this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677U));
          else
            this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372U));
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingName);
          if (InKey > (byte) 0)
            this.InfoString.AppendFormat("{0}{1}{2}\n{3}{4}[{5}]\n{6}{7}");
          else
            this.InfoString.AppendFormat("{0}{1}[{2}]\n{3}{4}");
        }
        else
        {
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceTag);
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceName);
          if (((int) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingdomFlag & 1) == 0)
            this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677U));
          else
            this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372U));
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingName);
          if (InKey > (byte) 0)
            this.InfoString.AppendFormat("{0}{1}{2}\n{3}[{4}]{5}\n{6}{7}");
          else
            this.InfoString.AppendFormat("{0}[{1}]{2}\n{3}{4}");
        }
      }
      else if ((int) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceKingdomID == (int) DataManager.Instance.RoleAlliance.KingdomID)
      {
        if (GUIManager.Instance.IsArabic)
        {
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceName);
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceTag);
          if (((int) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingdomFlag & 1) == 0)
            this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677U));
          else
            this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372U));
          this.InfoString.IntToFormat((long) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingKingdomID);
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingName);
          if (InKey > (byte) 0)
            this.InfoString.AppendFormat("{0}{1}{2}\n{3}{4}[{5}]\n{6}#{7} {8}");
          else
            this.InfoString.AppendFormat("{0}{1}[{2}]\n{3}#{4} {5}");
        }
        else
        {
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceTag);
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceName);
          if (((int) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingdomFlag & 1) == 0)
            this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677U));
          else
            this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372U));
          this.InfoString.IntToFormat((long) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingKingdomID);
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingName);
          if (InKey > (byte) 0)
            this.InfoString.AppendFormat("{0}{1}{2}\n{3}[{4}]{5}\n{6}#{7} {8}");
          else
            this.InfoString.AppendFormat("{0}[{1}]{2}\n{3}#{4} {5}");
        }
      }
      else if ((int) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingKingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID)
      {
        if (GUIManager.Instance.IsArabic)
        {
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceName);
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceTag);
          this.InfoString.IntToFormat((long) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceKingdomID);
          if (((int) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingdomFlag & 1) == 0)
            this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677U));
          else
            this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372U));
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingName);
          if (InKey > (byte) 0)
            this.InfoString.AppendFormat("{0}{1}{2}\n{3}#{6} {4}[{5}]\n{7}{8}");
          else
            this.InfoString.AppendFormat("{0}#{3} {1}[{2}]\n{4}{5}");
        }
        else
        {
          this.InfoString.IntToFormat((long) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceKingdomID);
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceTag);
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceName);
          if (((int) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingdomFlag & 1) == 0)
            this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677U));
          else
            this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372U));
          this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingName);
          if (InKey > (byte) 0)
            this.InfoString.AppendFormat("{0}{1}{2}\n{3}#{4} [{5}]{6}\n{7}{8}");
          else
            this.InfoString.AppendFormat("{0}#{1} [{2}]{3}\n{4}{5}");
        }
      }
      else if (GUIManager.Instance.IsArabic)
      {
        this.InfoString.IntToFormat((long) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceKingdomID);
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceName);
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceTag);
        if (((int) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingdomFlag & 1) == 0)
          this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677U));
        else
          this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372U));
        this.InfoString.IntToFormat((long) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingKingdomID);
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingName);
        if (InKey > (byte) 0)
          this.InfoString.AppendFormat("{0}{1}{2}\n{3}#{4} {5}[{6}]\n{7}#{8} {9}");
        else
          this.InfoString.AppendFormat("{0}#{1} {2}[{3}]\n{4}#{5} {6}");
      }
      else
      {
        this.InfoString.IntToFormat((long) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceKingdomID);
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceTag);
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].allianceName);
        if (((int) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingdomFlag & 1) == 0)
          this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677U));
        else
          this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372U));
        this.InfoString.IntToFormat((long) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingKingdomID);
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingName);
        if (InKey > (byte) 0)
          this.InfoString.AppendFormat("{0}{1}{2}\n{3}#{4} [{5}]{6}\n{7}#{8} {9}");
        else
          this.InfoString.AppendFormat("{0}#{1} [{2}]{3}\n{4}#{5} {6}");
      }
      long num2 = this.WorldKingdomTime = (long) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingdomTime + 7776000L - DataManager.Instance.ServerTime;
      if (num2 > 0L)
      {
        CString cstring = StringManager.Instance.StaticString1024();
        CString tmpS1 = StringManager.Instance.StaticString1024();
        CString tmpS2 = StringManager.Instance.StaticString1024();
        cstring.ClearString();
        tmpS1.ClearString();
        tmpS2.ClearString();
        if (num2 > 86400L)
        {
          tmpS2.IntToFormat(num2 / 86400L);
          tmpS2.AppendFormat("{0}d");
        }
        else if (num2 / 3600L > 0L)
        {
          tmpS2.IntToFormat(num2 / 3600L);
          long num3 = num2 % 3600L;
          tmpS2.IntToFormat(num3 / 60L, 2);
          long x = num3 % 60L;
          tmpS2.IntToFormat(x, 2);
          tmpS2.AppendFormat("{0}:{1}:{2}");
        }
        else
        {
          tmpS2.IntToFormat(num2 / 60L, 2);
          long x = num2 % 60L;
          tmpS2.IntToFormat(x, 2);
          tmpS2.AppendFormat("{0}:{1}");
        }
        tmpS1.StringToFormat(tmpS2);
        tmpS1.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(948U));
        cstring.StringToFormat(tmpS1);
        cstring.AppendFormat("\n<color=#B8D9F3>{0}");
        if (DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingdomTime > DataManager.MapDataController.kingdomData.kingdomTime && !DataManager.Instance.IsNewbie())
        {
          cstring.Append("\n");
          cstring.Append(DataManager.Instance.mStringTable.GetStringByID(947U));
        }
        cstring.Append("</color>");
        this.InfoString.Append(cstring);
      }
    }
    this.text_Info.text = this.InfoString.ToString();
    this.text_Info.SetAllDirty();
    this.text_Info.cachedTextGenerator.Invalidate();
    this.text_Info.cachedTextGeneratorForLayout.Invalidate();
    if ((double) this.text_Info.preferredHeight <= (double) ((Graphic) this.text_Info).rectTransform.sizeDelta.y)
      return;
    ((Graphic) this.text_Info).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Info).rectTransform.sizeDelta.x, this.text_Info.preferredHeight + 1f);
  }

  public void updateName(Color textcolor)
  {
    if (!this.NameGameObject.activeSelf)
      this.NameGameObject.SetActive(true);
    ((Graphic) this.NameText).color = textcolor;
  }

  public void updateName(Vector2 pos)
  {
    if (!this.NameGameObject.activeSelf)
      return;
    this.NameRectTransform.anchoredPosition = pos;
  }

  public void updateNamePos(Vector2 pos)
  {
    if (!this.NameGameObject.activeSelf)
      this.NameGameObject.SetActive(true);
    Vector2 vector2 = pos - this.NameRectTransform.anchoredPosition;
    if ((double) Mathf.Abs(vector2.x) <= 8.0 && (double) Mathf.Abs(vector2.y) <= 8.0)
      return;
    this.NameRectTransform.anchoredPosition = pos;
  }

  public void SetActive(bool active) => this.NameGameObject.SetActive(active);

  public void SetNameText(int row, int col)
  {
    this.NameText.row = row;
    this.NameText.col = col;
  }

  public void NameTextRebuilt()
  {
    if (!this.NameGameObject.activeSelf)
      return;
    if ((Object) this.NameText != (Object) null && ((Behaviour) this.NameText).enabled)
    {
      ((Behaviour) this.NameText).enabled = false;
      ((Behaviour) this.NameText).enabled = true;
    }
    if (!((Object) this.text_Info != (Object) null) || !((Behaviour) this.text_Info).enabled)
      return;
    ((Behaviour) this.text_Info).enabled = false;
    ((Behaviour) this.text_Info).enabled = true;
  }

  public void SetTimeText()
  {
    byte tableId = DataManager.MapDataController.TileMapKingdomID[(int) this.WorldKingdomTableID].tableID;
    if ((int) tableId >= DataManager.MapDataController.WorldKingdomTable.Length || (int) DataManager.MapDataController.TileMapKingdomID[(int) this.WorldKingdomTableID].KingdomID != (int) DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingdomID || DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
      return;
    long num1 = (long) DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingdomTime + 7776000L - DataManager.Instance.ServerTime;
    if (num1 <= 0L)
      return;
    if (num1 == this.WorldKingdomTime)
      return;
    CString cstring;
    CString tmpS1;
    CString tmpS2;
    if (num1 > 86400L)
    {
      long x = num1 / 86400L;
      if (this.WorldKingdomTime / 86400L == x)
        return;
      this.WorldKingdomTime = num1;
      cstring = StringManager.Instance.StaticString1024();
      tmpS1 = StringManager.Instance.StaticString1024();
      tmpS2 = StringManager.Instance.StaticString1024();
      cstring.ClearString();
      tmpS1.ClearString();
      tmpS2.ClearString();
      tmpS2.IntToFormat(x);
      tmpS2.AppendFormat("{0}d");
    }
    else
    {
      this.WorldKingdomTime = num1;
      cstring = StringManager.Instance.StaticString1024();
      tmpS1 = StringManager.Instance.StaticString1024();
      tmpS2 = StringManager.Instance.StaticString1024();
      cstring.ClearString();
      tmpS1.ClearString();
      tmpS2.ClearString();
      if (num1 / 3600L > 0L)
      {
        tmpS2.IntToFormat(num1 / 3600L);
        long num2 = num1 % 3600L;
        tmpS2.IntToFormat(num2 / 60L, 2);
        long x = num2 % 60L;
        tmpS2.IntToFormat(x, 2);
        tmpS2.AppendFormat("{0}:{1}:{2}");
      }
      else
      {
        tmpS2.IntToFormat(num1 / 60L, 2);
        long x = num1 % 60L;
        tmpS2.IntToFormat(x, 2);
        tmpS2.AppendFormat("{0}:{1}");
      }
    }
    this.InfoString.ClearString();
    byte InKey = (byte) ((uint) DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingdomFlag >> 3);
    if (InKey > (byte) 0)
    {
      TitleData recordByKey = DataManager.Instance.TitleDataN.GetRecordByKey((ushort) InKey);
      this.InfoString.StringToFormat("<color=#FFFF00>");
      this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.StringID));
      this.InfoString.StringToFormat("</color>");
    }
    this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(676U));
    if (DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceTag == null || DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceTag.Length == 0 || DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceTag[0] == char.MinValue)
    {
      this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(5334U));
      this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677U));
      this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(5334U));
      if (InKey > (byte) 0)
        this.InfoString.AppendFormat("{0}{1}{2}\n{3}{4}\n{5}{6}");
      else
        this.InfoString.AppendFormat("{0}{1}\n{2}{3}");
    }
    else if ((int) DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceKingdomID == (int) DataManager.Instance.RoleAlliance.KingdomID && (int) DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingKingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID)
    {
      if (GUIManager.Instance.IsArabic)
      {
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceName);
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceTag);
        if (((int) DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingdomFlag & 1) == 0)
          this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677U));
        else
          this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372U));
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingName);
        if (InKey > (byte) 0)
          this.InfoString.AppendFormat("{0}{1}{2}\n{3}{4}[{5}]\n{6}{7}");
        else
          this.InfoString.AppendFormat("{0}{1}[{2}]\n{3}{4}");
      }
      else
      {
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceTag);
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceName);
        if (((int) DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingdomFlag & 1) == 0)
          this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677U));
        else
          this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372U));
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingName);
        if (InKey > (byte) 0)
          this.InfoString.AppendFormat("{0}{1}{2}\n{3}[{4}]{5}\n{6}{7}");
        else
          this.InfoString.AppendFormat("{0}[{1}]{2}\n{3}{4}");
      }
    }
    else if ((int) DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceKingdomID == (int) DataManager.Instance.RoleAlliance.KingdomID)
    {
      if (GUIManager.Instance.IsArabic)
      {
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceName);
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceTag);
        if (((int) DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingdomFlag & 1) == 0)
          this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677U));
        else
          this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372U));
        this.InfoString.IntToFormat((long) DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingKingdomID);
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingName);
        if (InKey > (byte) 0)
          this.InfoString.AppendFormat("{0}{1}{2}\n{3}{4}[{5}]\n{6}#{7} {8}");
        else
          this.InfoString.AppendFormat("{0}{1}[{2}]\n{3}#{4} {5}");
      }
      else
      {
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceTag);
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceName);
        if (((int) DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingdomFlag & 1) == 0)
          this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677U));
        else
          this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372U));
        this.InfoString.IntToFormat((long) DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingKingdomID);
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingName);
        if (InKey > (byte) 0)
          this.InfoString.AppendFormat("{0}{1}{2}\n{3}[{4}]{5}\n{6}#{7} {8}");
        else
          this.InfoString.AppendFormat("{0}[{1}]{2}\n{3}#{4} {5}");
      }
    }
    else if ((int) DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingKingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID)
    {
      if (GUIManager.Instance.IsArabic)
      {
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceName);
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceTag);
        this.InfoString.IntToFormat((long) DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceKingdomID);
        if (((int) DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingdomFlag & 1) == 0)
          this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677U));
        else
          this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372U));
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingName);
        if (InKey > (byte) 0)
          this.InfoString.AppendFormat("{0}{1}{2}\n{3}#{6} {4}[{5}]\n{7}{8}");
        else
          this.InfoString.AppendFormat("{0}#{3} {1}[{2}]\n{4}{5}");
      }
      else
      {
        this.InfoString.IntToFormat((long) DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceKingdomID);
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceTag);
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceName);
        if (((int) DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingdomFlag & 1) == 0)
          this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677U));
        else
          this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372U));
        this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingName);
        if (InKey > (byte) 0)
          this.InfoString.AppendFormat("{0}{1}{2}\n{3}#{4} [{5}]{6}\n{7}{8}");
        else
          this.InfoString.AppendFormat("{0}#{1} [{2}]{3}\n{4}{5}");
      }
    }
    else if (GUIManager.Instance.IsArabic)
    {
      this.InfoString.IntToFormat((long) DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceKingdomID);
      this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceName);
      this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceTag);
      if (((int) DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingdomFlag & 1) == 0)
        this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677U));
      else
        this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372U));
      this.InfoString.IntToFormat((long) DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingKingdomID);
      this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingName);
      if (InKey > (byte) 0)
        this.InfoString.AppendFormat("{0}{1}{2}\n{3}#{4} {5}[{6}]\n{7}#{8} {9}");
      else
        this.InfoString.AppendFormat("{0}#{1} {2}[{3}]\n{4}#{5} {6}");
    }
    else
    {
      this.InfoString.IntToFormat((long) DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceKingdomID);
      this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceTag);
      this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].allianceName);
      if (((int) DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingdomFlag & 1) == 0)
        this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(677U));
      else
        this.InfoString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9372U));
      this.InfoString.IntToFormat((long) DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingKingdomID);
      this.InfoString.StringToFormat(DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingName);
      if (InKey > (byte) 0)
        this.InfoString.AppendFormat("{0}{1}{2}\n{3}#{4} [{5}]{6}\n{7}#{8} {9}");
      else
        this.InfoString.AppendFormat("{0}#{1} [{2}]{3}\n{4}#{5} {6}");
    }
    tmpS1.StringToFormat(tmpS2);
    tmpS1.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(948U));
    cstring.StringToFormat(tmpS1);
    cstring.AppendFormat("\n<color=#B8D9F3>{0}");
    if (DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingdomTime > DataManager.MapDataController.kingdomData.kingdomTime && !DataManager.Instance.IsNewbie())
    {
      cstring.Append("\n");
      cstring.Append(DataManager.Instance.mStringTable.GetStringByID(947U));
    }
    cstring.Append("</color>");
    this.InfoString.Append(cstring);
    this.text_Info.text = this.InfoString.ToString();
    this.text_Info.SetAllDirty();
    this.text_Info.cachedTextGenerator.Invalidate();
    this.text_Info.cachedTextGeneratorForLayout.Invalidate();
    if ((double) this.text_Info.preferredHeight <= (double) ((Graphic) this.text_Info).rectTransform.sizeDelta.y)
      return;
    ((Graphic) this.text_Info).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Info).rectTransform.sizeDelta.x, this.text_Info.preferredHeight + 1f);
  }
}
