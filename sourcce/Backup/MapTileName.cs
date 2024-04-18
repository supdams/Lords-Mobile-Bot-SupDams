// Decompiled with JetBrains decompiler
// Type: MapTileName
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class MapTileName
{
  private static Quaternion NameTextlocalRotation = new Quaternion(0.0f, -180f, 0.0f, 0.0f);
  public RectTransform NameRectTransform;
  public float NameOffset;
  public EmojiUnit mapEmoji;
  public EmojiUnit mapEmojiBack;
  public int bloodtextID = -1;
  public short pointID = -1;
  public CString TimeString;
  private GameObject NameGameObject;
  private UIText NameText;
  private CString TitleString;

  public MapTileName(Transform parentLayout, Vector2 inipos, Vector2 testsize)
  {
    GameObject gameObject1 = new GameObject("name");
    this.NameRectTransform = gameObject1.AddComponent<RectTransform>();
    ((Transform) this.NameRectTransform).SetParent(parentLayout, false);
    ((Transform) this.NameRectTransform).localPosition = (Vector3) inipos;
    this.NameGameObject = gameObject1;
    GameObject gameObject2 = new GameObject("nameText");
    this.NameText = gameObject2.AddComponent<UIText>();
    Outline outline = gameObject2.AddComponent<Outline>();
    this.NameText.font = GUIManager.Instance.GetTTFFont();
    this.NameText.alignment = TextAnchor.MiddleCenter;
    this.NameText.resizeTextForBestFit = true;
    this.NameText.resizeTextMaxSize = 24;
    this.TitleString = new CString(32);
    ((Shadow) outline).effectColor = new Color(0.0f, 0.0f, 0.0f, 0.5f);
    RectTransform transform = gameObject2.transform as RectTransform;
    transform.sizeDelta = testsize;
    ((Transform) transform).localScale = Vector3.one;
    if (GUIManager.Instance.IsArabic)
      ((Transform) transform).localRotation = MapTileName.NameTextlocalRotation;
    ((Transform) transform).SetParent((Transform) this.NameRectTransform, false);
    this.NameGameObject.SetActive(false);
  }

  public void Release()
  {
    if (this.mapEmoji != null)
    {
      GUIManager.Instance.pushEmojiIcon(this.mapEmoji);
      this.mapEmoji = (EmojiUnit) null;
    }
    if (this.mapEmojiBack != null)
    {
      GUIManager.Instance.pushEmojiIcon(this.mapEmojiBack);
      this.mapEmojiBack = (EmojiUnit) null;
    }
    if (this.TimeString != null)
    {
      StringManager.Instance.DeSpawnString(this.TimeString);
      this.TimeString = (CString) null;
    }
    this.NameGameObject = (GameObject) null;
    this.NameRectTransform = (RectTransform) null;
    this.NameText = (UIText) null;
    this.TitleString = (CString) null;
  }

  public void updateName(
    CString Name,
    CString Tag,
    Color textcolor,
    Vector2 pos,
    ushort kingdomID = 0,
    CString First = null)
  {
    this.updateName(Name, Tag, textcolor, kingdomID, First);
    this.updateName(pos);
  }

  public void updateName(
    CString Name,
    CString Tag,
    Color textcolor,
    ushort kingdomID = 0,
    CString First = null)
  {
    this.updateName(textcolor);
    this.updateName(Name, Tag, kingdomID, First);
  }

  public void updateName(CString Name, CString Tag, ELineColor textcolor)
  {
    this.updateName(MapTileBloodName.lineNameColor[(int) textcolor]);
    this.updateName(Name, Tag, (ushort) 0);
  }

  public void updateName(CString Name, CString Tag, ushort kingdomID = 0, CString First = null)
  {
    if (!this.NameGameObject.activeSelf)
      this.NameGameObject.SetActive(true);
    if (Name == null || Name.Length == 0)
    {
      ((Component) this.NameText).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.NameText).gameObject.SetActive(true);
      this.TitleString.ClearString();
      if (GUIManager.Instance.IsArabic)
      {
        if (First != null && First.Length != 0)
        {
          this.TitleString.Append(' ');
          this.TitleString.Append(First);
          if (Tag != null && Tag.Length != 0)
          {
            if (ArabicTransfer.Instance.IsArabicStr(Name.ToString()))
            {
              if (kingdomID != (ushort) 0)
              {
                this.TitleString.Append('#');
                this.TitleString.Append(kingdomID.ToString());
                this.TitleString.Append(' ');
              }
              this.TitleString.Append(Name);
              this.TitleString.Append('[');
              this.TitleString.Append(Tag);
              this.TitleString.Append(']');
            }
            else
            {
              if (kingdomID != (ushort) 0)
              {
                this.TitleString.Append('#');
                this.TitleString.Append(kingdomID.ToString());
                this.TitleString.Append(' ');
              }
              this.TitleString.Append(Name);
              this.TitleString.Append('[');
              this.TitleString.Append(Tag);
              this.TitleString.Append(']');
            }
          }
          else if (ArabicTransfer.Instance.IsArabicStr(Name.ToString()))
          {
            if (kingdomID != (ushort) 0)
            {
              this.TitleString.Append('#');
              this.TitleString.Append(kingdomID.ToString());
              this.TitleString.Append(' ');
            }
            this.TitleString.Append(Name);
          }
          else
          {
            if (kingdomID != (ushort) 0)
            {
              this.TitleString.Append(' ');
              this.TitleString.Append(kingdomID.ToString());
              this.TitleString.Append('#');
            }
            this.TitleString.Append(Name);
          }
        }
        else if (Tag != null && Tag.Length != 0)
        {
          if (ArabicTransfer.Instance.IsArabicStr(Name.ToString()))
          {
            if (kingdomID != (ushort) 0)
            {
              this.TitleString.Append('#');
              this.TitleString.Append(kingdomID.ToString());
              this.TitleString.Append(' ');
            }
            this.TitleString.Append(Name);
            this.TitleString.Append('[');
            this.TitleString.Append(Tag);
            this.TitleString.Append(']');
          }
          else
          {
            this.TitleString.Append('[');
            this.TitleString.Append(Tag);
            this.TitleString.Append(']');
            this.TitleString.Append(Name);
            if (kingdomID != (ushort) 0)
            {
              this.TitleString.Append(' ');
              this.TitleString.Append(kingdomID.ToString());
              this.TitleString.Append('#');
            }
          }
        }
        else if (ArabicTransfer.Instance.IsArabicStr(Name.ToString()))
        {
          if (kingdomID != (ushort) 0)
          {
            this.TitleString.Append('#');
            this.TitleString.Append(kingdomID.ToString());
            this.TitleString.Append(' ');
          }
          this.TitleString.Append(Name);
        }
        else
        {
          this.TitleString.Append(Name);
          if (kingdomID != (ushort) 0)
          {
            this.TitleString.Append(' ');
            this.TitleString.Append(kingdomID.ToString());
            this.TitleString.Append('#');
          }
        }
      }
      else
      {
        if (First != null && First.Length != 0)
        {
          this.TitleString.Append(First);
          this.TitleString.Append(' ');
        }
        if (kingdomID != (ushort) 0)
        {
          this.TitleString.Append('#');
          this.TitleString.Append(kingdomID.ToString());
          this.TitleString.Append(' ');
        }
        if (Tag != null && Tag.Length != 0)
        {
          this.TitleString.Append('[');
          this.TitleString.Append(Tag);
          this.TitleString.Append(']');
        }
        this.TitleString.Append(Name);
      }
      this.NameText.text = this.TitleString.ToString();
      this.NameText.SetAllDirty();
      this.NameText.cachedTextGenerator.Invalidate();
    }
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
    this.NameRectTransform.anchoredPosition = pos + Vector2.up * this.NameOffset;
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

  public void NameTextRebuilt()
  {
    if (!this.NameGameObject.activeSelf)
      return;
    if ((Object) this.NameText != (Object) null && ((Behaviour) this.NameText).enabled)
    {
      ((Behaviour) this.NameText).enabled = false;
      ((Behaviour) this.NameText).enabled = true;
    }
    if (this.bloodtextID <= 0)
      return;
    Transform child = ((Transform) this.NameRectTransform).GetChild(this.bloodtextID);
    Text component1 = child.GetChild(4).GetComponent<Text>();
    if ((Object) component1 != (Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    Text component2 = child.GetChild(3).GetComponent<Text>();
    if (!((Object) component2 != (Object) null) || !((Behaviour) component2).enabled)
      return;
    ((Behaviour) component2).enabled = false;
    ((Behaviour) component2).enabled = true;
  }
}
