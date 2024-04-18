// Decompiled with JetBrains decompiler
// Type: CloudController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class CloudController
{
  private const byte MaxchildCount = 10;
  private const float CloudMoveFactor = 10f;
  private AssetBundle CloudBundle;
  private string AssetName;
  private int key;
  private GameObject CloudGO;
  private GameObject gameobject;
  private Vector3[] sourcePosition;
  private Vector3[] offsetCenter;
  private SpriteRenderer[] spriteRender;
  private Vector3[] oriScale;
  private byte childCount;
  private byte ChapterID;
  private CloudController._SceneCloud[] SceneCloud = new CloudController._SceneCloud[100];
  private byte SceneCloudCount;
  public float TotalTime = 2f;
  private float CurTime;
  private float UpdateTime;
  private float UpdateTimeFrame = 0.3f;
  private CloudMoveMode MoveState;

  public CloudController()
  {
    this.offsetCenter = new Vector3[10];
    this.spriteRender = new SpriteRenderer[10];
    this.oriScale = new Vector3[10];
    this.sourcePosition = new Vector3[10];
    this.Init();
  }

  private void Init()
  {
    this.AssetName = "UI/Building";
    this.CloudBundle = AssetManager.GetAssetBundle(this.AssetName, out this.key);
    if ((Object) this.CloudBundle == (Object) null)
      return;
    this.CloudGO = Object.Instantiate(this.CloudBundle.Load("cloud")) as GameObject;
    this.MoveState = CloudMoveMode.None;
    this.UpdateColudController();
    this.SetSceneCloud();
    this.UpdateTime = this.UpdateTimeFrame;
  }

  public void UpdateColudController()
  {
    if ((Object) this.CloudGO == (Object) null)
      return;
    StageManager stageDataController = DataManager.StageDataController;
    this.ChapterID = (byte) ((uint) stageDataController.StageRecord[2] + 1U);
    for (ushort index1 = 0; (int) index1 < this.CloudGO.transform.childCount; ++index1)
    {
      if (index1 == (ushort) 0)
      {
        Transform child = this.CloudGO.transform.GetChild((int) index1);
        if ((Object) child == (Object) null)
          break;
        this.SetSpriteRenderColor(child, 0.4314f);
        child.gameObject.SetActive(true);
      }
      else
      {
        byte index2 = (byte) ((uint) stageDataController.ChapterTable.GetRecordByKey(index1).MapID - 1U);
        if (this.CloudGO.transform.childCount < (int) index2)
          break;
        Transform child = this.CloudGO.transform.GetChild((int) index2);
        if ((Object) child == (Object) null)
          break;
        if ((int) this.ChapterID == (int) index1)
        {
          if (stageDataController.isNotFirstInChapter[2] == (byte) 0)
          {
            if (stageDataController.currentWorldMode == WorldMode.Wild)
            {
              child.gameObject.SetActive(true);
              this.SetGameObject(child.gameObject);
            }
            else
              child.gameObject.SetActive(false);
          }
          else
            child.gameObject.SetActive(false);
        }
        else if ((int) this.ChapterID > (int) index1)
        {
          child.gameObject.SetActive(false);
        }
        else
        {
          this.SetSpriteRenderColor(child, 0.4314f);
          child.gameObject.SetActive(true);
        }
      }
    }
  }

  private void SetSpriteRenderColor(Transform mapTrans, float color)
  {
    for (int index = 0; index < mapTrans.childCount; ++index)
      mapTrans.GetChild(index).GetComponent<SpriteRenderer>().color = new Color(color, color, color);
  }

  private void SetGameObject(GameObject go)
  {
    this.gameobject = go;
    Vector3 zero = Vector3.zero;
    byte index1;
    for (index1 = (byte) 0; (int) index1 < this.gameobject.transform.childCount; ++index1)
    {
      if (index1 >= (byte) 10)
      {
        --index1;
        break;
      }
      this.sourcePosition[(int) index1] = this.gameobject.transform.GetChild((int) index1).position;
      this.offsetCenter[(int) index1] = this.gameobject.transform.GetChild((int) index1).position;
      this.spriteRender[(int) index1] = this.gameobject.transform.GetChild((int) index1).gameObject.GetComponent<SpriteRenderer>();
      this.oriScale[(int) index1] = this.gameobject.transform.GetChild((int) index1).localScale;
      this.spriteRender[(int) index1].renderer.sortingOrder = -2;
      zero += this.offsetCenter[(int) index1];
    }
    Vector3 vector3 = zero / (float) index1;
    this.childCount = index1;
    for (int index2 = 0; index2 < (int) this.childCount; ++index2)
    {
      this.offsetCenter[index2] = vector3 - this.offsetCenter[index2];
      this.offsetCenter[index2].Normalize();
    }
    this.CurTime = 0.0f;
    this.MoveState = CloudMoveMode.Ready;
  }

  private void SetSceneCloud()
  {
    this.SceneCloudCount = (byte) 0;
    for (byte index1 = 0; (int) index1 < this.CloudGO.transform.childCount; ++index1)
    {
      for (int index2 = 0; index2 < this.CloudGO.transform.GetChild((int) index1).childCount; ++index2)
      {
        float num = Random.value;
        this.SceneCloud[(int) this.SceneCloudCount].transform = this.CloudGO.transform.GetChild((int) index1).GetChild(index2);
        this.SceneCloud[(int) this.SceneCloudCount].transform.GetComponent<SpriteRenderer>().sortingOrder = -2;
        this.SceneCloud[(int) this.SceneCloudCount].Chapter = index1;
        this.SceneCloud[(int) this.SceneCloudCount].forward = (double) num >= 0.5;
        this.SceneCloud[(int) this.SceneCloudCount].distance = 10f * num;
        this.SceneCloud[(int) this.SceneCloudCount].time = 0.0f;
        this.SceneCloud[(int) this.SceneCloudCount].totaltime = (float) (10.0 * (1.0 + (double) num));
        this.SceneCloud[(int) this.SceneCloudCount].origin = this.SceneCloud[(int) this.SceneCloudCount].transform.position.x;
        this.SceneCloud[(int) this.SceneCloudCount].endflag = (byte) 0;
        ++this.SceneCloudCount;
      }
    }
  }

  public void MapClick()
  {
    if ((Object) this.gameobject == (Object) null)
      return;
    GUIManager.Instance.ShowUILock(EUILock.Normal);
    this.UpdateColudController();
    this.MoveState = CloudMoveMode.Move;
    this.UpdateTimeFrame = 0.0f;
  }

  public void Update()
  {
    float deltaTime = Time.deltaTime;
    this.UpdateTime -= deltaTime;
    if ((double) this.UpdateTime > 0.0)
      return;
    this.UpdateTime = this.UpdateTimeFrame;
    if (this.MoveState == CloudMoveMode.Move)
    {
      this.UpdateMove(deltaTime);
      this.CurTime += deltaTime;
    }
    this.UpdateSceneCloudMove(deltaTime);
    if ((double) this.CurTime <= (double) this.TotalTime)
      return;
    this.CurTime = 0.0f;
    this.MoveState = CloudMoveMode.Done;
    this.gameobject.SetActive(false);
    DataManager.msgBuffer[0] = (byte) 11;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public void UpdateMove(float delta)
  {
    float num1 = this.CurTime / this.TotalTime;
    for (int index = 0; index < this.gameobject.transform.childCount; ++index)
    {
      float num2 = (double) this.offsetCenter[index].normalized.x >= 0.0 || (double) this.offsetCenter[index].normalized.y >= 0.0 ? 9.5f : -9.5f;
      this.gameobject.transform.GetChild(index).Translate(this.offsetCenter[index].normalized * delta * num2);
      this.gameobject.transform.GetChild(index).localScale = this.oriScale[index] + this.oriScale[index] * (0.15f * num1);
      Color color = this.spriteRender[index].color with
      {
        a = EasingEffect.Quintic(this.CurTime, 1f, -1f, this.TotalTime)
      };
      this.spriteRender[index].color = color;
    }
  }

  private void UpdateSceneCloudMove(float delta)
  {
    for (int index = 0; index < (int) this.SceneCloudCount; ++index)
    {
      if ((this.MoveState != CloudMoveMode.Move || (int) this.ChapterID != (int) this.SceneCloud[index].Chapter) && this.SceneCloud[index].transform.gameObject.activeInHierarchy)
      {
        Vector3 position = this.SceneCloud[index].transform.position;
        float num1 = !this.SceneCloud[index].forward ? this.SceneCloud[index].origin - this.SceneCloud[index].distance * (this.SceneCloud[index].time / this.SceneCloud[index].totaltime) : this.SceneCloud[index].origin + this.SceneCloud[index].distance * (this.SceneCloud[index].time / this.SceneCloud[index].totaltime);
        position.x = num1;
        this.SceneCloud[index].transform.position = position;
        this.SceneCloud[index].time += delta;
        if ((double) this.SceneCloud[index].time > (double) this.SceneCloud[index].totaltime)
        {
          this.SceneCloud[index].time = 0.0f;
          this.SceneCloud[index].forward = !this.SceneCloud[index].forward;
          this.SceneCloud[index].origin = this.SceneCloud[index].transform.position.x;
          this.SceneCloud[index].endflag = (byte) ((uint) ++this.SceneCloud[index].endflag & 1U);
          if (this.SceneCloud[index].endflag == (byte) 0)
          {
            float num2 = Random.value;
            this.SceneCloud[index].distance = 10f * num2;
            this.SceneCloud[index].totaltime = (float) (10.0 * (1.0 + (double) num2));
          }
        }
      }
    }
  }

  private CloudMoveMode GetCloudState() => this.MoveState;

  public void Reset()
  {
    for (byte index = 0; (int) index < this.gameobject.transform.childCount; ++index)
    {
      this.gameobject.transform.GetChild((int) index).position = this.sourcePosition[(int) index];
      this.gameobject.transform.GetChild((int) index).localScale = this.oriScale[(int) index];
      Color color = this.spriteRender[(int) index].color with
      {
        a = (float) byte.MaxValue
      };
      this.spriteRender[(int) index].color = color;
    }
    this.CurTime = 0.0f;
    this.MoveState = CloudMoveMode.Ready;
    DataManager.StageDataController.isNotFirstInChapter[2] = (byte) 0;
    this.gameobject.SetActive(true);
  }

  public void Destory()
  {
    if ((bool) (Object) this.CloudGO)
      Object.Destroy((Object) this.CloudGO);
    this.CloudGO = (GameObject) null;
    AssetManager.UnloadAssetBundle(this.key);
  }

  public struct _SceneCloud
  {
    public byte Chapter;
    public Transform transform;
    public float time;
    public float totaltime;
    public bool forward;
    public float origin;
    public float distance;
    public byte endflag;
  }
}
