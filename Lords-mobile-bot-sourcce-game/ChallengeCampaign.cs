// Decompiled with JetBrains decompiler
// Type: ChallengeCampaign
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class ChallengeCampaign : SpriteBase
{
  private GameObject RootObj;
  private ushort PointID;
  private sbyte Score;
  private float SpriteScale = 6f;
  private SpriteRenderer spriteRender;
  private SpriteRenderer FramespriteRender;
  private SpriteRenderer[] GradespriteRender;
  private SpriteRenderer StageRender;
  private TextMesh StageText;
  private CString StageStr;
  private Vector3 GradePos = new Vector3(0.0f, 5.19f, 0.0f);

  public ChallengeCampaign()
  {
    this.RootObj = new GameObject("Campain");
    this.GradespriteRender = new SpriteRenderer[3];
    this.StageStr = StringManager.Instance.SpawnString();
  }

  public override GameObject InitialSprite(MapSpriteManager mapspriteManager)
  {
    this.mapspriteManager = mapspriteManager;
    GUIManager instance = GUIManager.Instance;
    this.RootObj.transform.position = Vector3.zero;
    this.spriteRender = mapspriteManager.GetSpriteObj().GetComponent<SpriteRenderer>();
    this.spriteRender.transform.SetParent(this.RootObj.transform);
    this.spriteRender.transform.localScale *= this.SpriteScale;
    this.spriteRender.renderer.sortingOrder = -50;
    this.spriteRender.color = Color.white;
    if (instance.IsArabic)
      this.spriteRender.transform.rotation = this.spriteRender.transform.rotation with
      {
        eulerAngles = new Vector3(0.0f, 180f, 0.0f)
      };
    this.FramespriteRender = mapspriteManager.GetSpriteObj().GetComponent<SpriteRenderer>();
    this.FramespriteRender.material = mapspriteManager.ChallegeMaterial;
    this.FramespriteRender.renderer.sortingOrder = -10;
    this.FramespriteRender.transform.SetParent(this.RootObj.transform);
    this.FramespriteRender.transform.localScale *= this.SpriteScale;
    this.FramespriteRender.color = Color.white;
    for (int index = 0; index < 3; ++index)
    {
      GameObject spriteObj = mapspriteManager.GetSpriteObj();
      this.GradespriteRender[index] = spriteObj.GetComponent<SpriteRenderer>();
      this.GradespriteRender[index].transform.SetParent(this.RootObj.transform);
      this.GradespriteRender[index].enabled = false;
    }
    Vector3 vector3 = new Vector3(6f, 6f, 6f);
    this.GradePos.Set(0.52f, -2.33f, 0.0f);
    GameObject textObj = mapspriteManager.GetTextObj();
    textObj.transform.localScale = vector3;
    textObj.transform.SetParent(this.RootObj.transform);
    textObj.transform.localPosition = this.GradePos;
    this.StageRender = textObj.GetComponent<SpriteRenderer>();
    this.StageRender.sprite = instance.LoadFrameSprite("UI_black_top");
    this.StageRender.material = instance.GetFrameMaterial();
    this.StageRender.renderer.sortingOrder = -40;
    this.GradePos.Set(-0.066f, 0.26f, 0.0f);
    this.StageText = textObj.transform.GetChild(0).GetComponent<TextMesh>();
    vector3.Set(1f / vector3.x, 1f / vector3.y, 1f / vector3.z);
    this.StageText.transform.localScale = vector3;
    this.StageText.transform.localPosition = this.GradePos;
    this.StageStr.ClearString();
    this.StageStr.IntToFormat((long) DataManager.StageDataController.currentChapterID);
    this.StageText.transform.localPosition = this.StageText.transform.localPosition with
    {
      x = this.Index >= (ushort) 10 ? -0.227f : -0.066f
    };
    this.StageStr.IntToFormat((long) this.Index);
    this.PointID = (ushort) (((int) DataManager.StageDataController.currentChapterID - 1) * 6);
    if (DataManager.StageDataController._stageMode == StageMode.Full || DataManager.StageDataController._stageMode == StageMode.Dare)
    {
      this.PointID *= (ushort) 3;
      this.PointID += this.Index;
    }
    else
      this.PointID += (ushort) ((uint) this.Index / 3U);
    if (instance.IsArabic)
      this.StageStr.AppendFormat("{1}-{0}");
    else
      this.StageStr.AppendFormat("{0}-{1}");
    this.StageText.text = this.StageStr.ToString();
    this.Score = (sbyte) DataManager.StageDataController.GetStagePoint(this.PointID, (byte) 0);
    if (this.Score < (sbyte) 0)
    {
      this.Score = (sbyte) 0;
      this.Hide();
    }
    else if (this.Score > (sbyte) 0 && (int) DataManager.StageDataController.DareNodusUpdatePointID == (int) this.PointID)
      --this.Score;
    this.Score &= (sbyte) 7;
    return this.RootObj;
  }

  public void UpdatData()
  {
    this.FramespriteRender.sprite = this.mapspriteManager.GetChalleteSprite((byte) this.Score);
    this.mapspriteManager.SetOutlinePosition(this.StageText.transform, this.StageText.text);
  }

  public override void Destroy()
  {
    StringManager.Instance.DeSpawnString(this.StageStr);
    if (!(bool) (Object) this.spriteRender)
      return;
    Object.Destroy((Object) this.StageText.gameObject);
    Object.Destroy((Object) this.RootObj);
    this.mapspriteManager.ReleaseSpriteObj(this.spriteRender.gameObject);
    this.mapspriteManager.ReleaseSpriteObj(this.FramespriteRender.gameObject);
    for (byte index = 0; index < (byte) 3; ++index)
      this.mapspriteManager.ReleaseSpriteObj(this.GradespriteRender[(int) index].gameObject);
  }

  public override void UpdateSpriteFrame()
  {
    this.Score = (sbyte) DataManager.StageDataController.GetStagePoint(this.PointID, (byte) 0);
    if (this.Score < (sbyte) 0)
    {
      this.Score = (sbyte) 0;
      this.Hide();
    }
    this.Score &= (sbyte) 7;
    this.UpdatData();
  }

  public override void SetSprite(ushort ID, byte Class)
  {
    this.spriteRender.sprite = this.mapspriteManager.GetSpriteByID(DataManager.Instance.HeroTable.GetRecordByKey(ID).Graph);
    this.UpdatData();
  }

  public override void Update(byte meg)
  {
    if (meg == (byte) 0 || meg == (byte) 1)
      return;
    this.Score = (sbyte) DataManager.StageDataController.GetStagePoint(this.PointID, (byte) 0);
    if (this.Score < (sbyte) 0)
      this.Score = (sbyte) 0;
    else if (this.Score > (sbyte) 0 && (int) DataManager.StageDataController.DareNodusUpdatePointID == (int) this.PointID)
      --this.Score;
    this.Score &= (sbyte) 7;
    this.UpdatData();
  }

  public override void Hide() => this.RootObj.SetActive(false);
}
