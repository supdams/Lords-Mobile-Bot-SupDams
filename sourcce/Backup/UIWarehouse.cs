// Decompiled with JetBrains decompiler
// Type: UIWarehouse
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIWarehouse : GUIWindow, IBuildingWindowType, UILoadImageHander
{
  private DataManager DM;
  private GUIManager GUIM;
  private RectTransform[] mListRT = new RectTransform[4];
  private Transform[] mListT = new Transform[5];
  private UIText[] text_ListValue = new UIText[5];
  private UIText[] text_tmpStr = new UIText[5];
  private CustomImage tmp_CusImg;
  private StringBuilder tmpString = new StringBuilder();
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private BuildingWindow baseBuild;
  private RoleBuildingData mBD;
  private BuildLevelRequest mBR;
  private Material m_BW;
  private int B_ID;
  private float Img_top2 = 125f;
  private Door door;
  private string AssetName;
  private uint[] m_Value = new uint[2];

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.AssetName = "BuildingWindow";
    this.m_BW = this.GUIM.AddSpriteAsset(this.AssetName);
    Transform transform = this.gameObject.transform;
    uint effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PROTCTION);
    this.mBD = this.GUIM.BuildingData.GetBuildData((ushort) 9, (ushort) 0);
    this.mBR = this.GUIM.BuildingData.GetBuildLevelRequestData((ushort) 9, this.mBD.Level);
    float num = (float) (10000U + effectBaseVal) / 10000f;
    this.m_Value[0] = GameConstants.appCeil((float) this.mBR.Value1 * num);
    if (this.mBR.ExtEffect1 != (ushort) 0 && this.mBR.Value1 != 0U)
      this.m_Value[1] = GameConstants.appCeil((float) this.mBR.Value1 * num);
    for (int index = 0; index < 4; ++index)
    {
      this.mListT[index] = transform.GetChild(index);
      this.mListRT[index] = this.mListT[index].GetComponent<RectTransform>();
      this.tmp_CusImg = this.mListT[index].GetComponent<CustomImage>();
      this.tmp_CusImg.hander = (UILoadImageHander) this;
      this.tmp_CusImg = this.mListT[index].GetChild(0).GetComponent<CustomImage>();
      this.tmp_CusImg.hander = (UILoadImageHander) this;
      this.text_tmpStr[index] = this.mListT[index].GetChild(1).GetComponent<UIText>();
      this.text_tmpStr[index].font = this.TTFont;
      this.text_tmpStr[index].text = this.DM.mStringTable.GetStringByID((uint) (ushort) (3937 + index));
      this.text_ListValue[index] = this.mListT[index].GetChild(2).GetComponent<UIText>();
      this.text_ListValue[index].font = this.TTFont;
      this.tmpString.Length = 0;
      this.tmpString.AppendFormat("{0:N0}", (object) this.m_Value[0]);
      this.text_ListValue[index].text = this.tmpString.ToString();
    }
    this.mListT[4] = transform.GetChild(4);
    this.tmp_CusImg = this.mListT[4].GetComponent<CustomImage>();
    this.tmp_CusImg.hander = (UILoadImageHander) this;
    this.tmp_CusImg = this.mListT[4].GetChild(0).GetComponent<CustomImage>();
    this.tmp_CusImg.hander = (UILoadImageHander) this;
    this.text_tmpStr[4] = this.mListT[4].GetChild(1).GetComponent<UIText>();
    this.text_tmpStr[4].font = this.TTFont;
    this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(3936U);
    this.text_ListValue[4] = this.mListT[4].GetChild(2).GetComponent<UIText>();
    this.text_ListValue[4].font = this.TTFont;
    this.tmpString.Length = 0;
    this.tmpString.AppendFormat("{0:N0}", (object) this.m_Value[1]);
    this.text_ListValue[4].text = this.tmpString.ToString();
    if (this.m_Value[1] != 0U)
    {
      for (int index = 0; index < 4; ++index)
        this.mListRT[index].anchoredPosition = new Vector2(this.mListRT[index].anchoredPosition.x, this.Img_top2 - (float) (index * 92));
      this.mListT[4].gameObject.SetActive(true);
    }
    this.B_ID = arg1;
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    if ((Object) this.baseBuild != (Object) null)
      this.baseBuild.DestroyBuildingWindow();
    if (this.AssetName == null)
      return;
    GUIManager.Instance.RemoveSpriteAsset(this.AssetName);
  }

  public void OnTypeChange(e_BuildType buildType)
  {
    if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing)
    {
      if (this.m_Value[1] != 0U)
        this.mListT[4].gameObject.SetActive(true);
      for (int index = 0; index < 4; ++index)
        this.mListT[index].gameObject.SetActive(true);
    }
    else
    {
      for (int index = 0; index < 5; ++index)
        this.mListT[index].gameObject.SetActive(false);
    }
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    if (TextureName.Equals("UI_main") && (Object) this.door != (Object) null)
    {
      img.sprite = this.door.LoadSprite(ImageName);
      ((MaskableGraphic) img).material = this.door.LoadMaterial();
    }
    else
    {
      img.sprite = this.GUIM.LoadSprite(this.AssetName, ImageName);
      ((MaskableGraphic) img).material = this.m_BW;
    }
  }

  private void Start()
  {
    this.baseBuild = this.transform.gameObject.AddComponent<BuildingWindow>();
    this.baseBuild.m_Handler = (IBuildingWindowType) this;
    this.baseBuild.InitBuildingWindow((byte) 9, (ushort) this.B_ID, (byte) 1, GUIManager.Instance.BuildingData.AllBuildsData[this.B_ID].Level);
    this.baseBuild.baseTransform.SetAsFirstSibling();
  }

  private void Update()
  {
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
        if (!((Object) this.baseBuild != (Object) null))
          break;
        this.baseBuild.MyUpdate((byte) 0);
        break;
      default:
        if (networkNews != NetworkNews.Refresh_BuildBase)
        {
          if (networkNews != NetworkNews.Refresh_AttribEffectVal)
          {
            if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
              break;
            this.Refresh_FontTexture();
            if (!((Object) this.baseBuild != (Object) null))
              break;
            this.baseBuild.Refresh_FontTexture();
            break;
          }
          if ((Object) this.baseBuild != (Object) null)
            this.baseBuild.MyUpdate((byte) 0);
          uint effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_STOREHOUSE_PROTECTION);
          float num = (float) (10000U + this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PROTCTION)) / 10000f;
          this.m_Value[0] = GameConstants.appCeil((float) effectBaseVal * num);
          for (int index = 0; index < 4; ++index)
          {
            this.tmpString.Length = 0;
            this.tmpString.AppendFormat("{0:N0}", (object) this.m_Value[0]);
            this.text_ListValue[index].text = this.tmpString.ToString();
          }
          if (this.m_Value[1] == 0U)
            break;
          this.m_Value[1] = GameConstants.appCeil((float) effectBaseVal * num);
          this.tmpString.Length = 0;
          this.tmpString.AppendFormat("{0:N0}", (object) this.m_Value[1]);
          this.text_ListValue[4].text = this.tmpString.ToString();
          break;
        }
        if (meg[1] == (byte) 1)
          this.door.CloseMenu(true);
        else if ((Object) this.baseBuild != (Object) null)
          this.baseBuild.MyUpdate(meg[1]);
        this.mBD = this.GUIM.BuildingData.GetBuildData((ushort) 9, (ushort) 0);
        this.mBR = this.GUIM.BuildingData.GetBuildLevelRequestData((ushort) 9, this.mBD.Level);
        uint effectBaseVal1 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_STOREHOUSE_PROTECTION);
        this.m_Value[0] = effectBaseVal1;
        if (this.mBR.ExtEffect1 != (ushort) 0 && this.mBR.Value1 != 0U)
          this.m_Value[1] = effectBaseVal1;
        if (this.m_Value[1] == 0U)
          break;
        for (int index = 0; index < 4; ++index)
          this.mListRT[index].anchoredPosition = new Vector2(this.mListRT[index].anchoredPosition.x, this.Img_top2 - (float) (index * 92));
        this.mListT[4].gameObject.SetActive(true);
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    for (int index = 0; index < 5; ++index)
    {
      if ((Object) this.text_ListValue[index] != (Object) null && ((Behaviour) this.text_ListValue[index]).enabled)
      {
        ((Behaviour) this.text_ListValue[index]).enabled = false;
        ((Behaviour) this.text_ListValue[index]).enabled = true;
      }
      if ((Object) this.text_tmpStr[index] != (Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
    }
  }
}
