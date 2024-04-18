// Decompiled with JetBrains decompiler
// Type: AudioManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class AudioManager
{
  private const byte MaxSourceNum = 20;
  private const byte BGMSourceCount = 2;
  private const float DuckVolDecreaseNum = 0.2921f;
  private const float DuckExtendTime = 1f;
  private const float DuckCancelTime = 1f;
  private const ushort MP3PriName = 700;
  private GameObject AudioController;
  private static AudioManager instance;
  private AudioSource[] SFXSource = new AudioSource[20];
  private int[] SFXBundleKey = new int[20];
  private Transform[] PlaySFXTrans = new Transform[20];
  private short MarkSFXBundleKey;
  private byte SpeechSoundPrev;
  private float[] SpeechSoundPitchVal = new float[3]
  {
    1f,
    1.11225f,
    0.8909f
  };
  private ClipInfo SFXClip = new ClipInfo();
  private byte poolIndex;
  private int FireKey;
  private AudioSource FireSFXSource;
  private AudioHighPassFilter FireHighPass;
  private AudioCloseQueue[] CloseQueue = new AudioCloseQueue[4];
  private int CloseQueueIndex;
  private int NowPlayBGMName;
  private WWW www;
  private AudioSource[] BGMSource = new AudioSource[2];
  private byte BGMLoop;
  private ClipInfo BGMClip = new ClipInfo();
  private AssetBundle[] BGMassetBundle = new AssetBundle[2];
  private int BGMmainIndex;
  private bool bCrossfade;
  private float FadeTime;
  private float FadeTimeMax = 3f;
  public float MusicVol = 1f;
  public float TmpVol;
  private BGMType CurMusicType;
  private float DuckVolDecrease;
  private float DuckDeltaTime;
  private byte PlaySFXCount;
  public bool BlockNormalSFX = true;
  private AudioManager.DuckingState duckingstate;
  private ushort MP3ABName;
  private int MP3Key;
  private AudioSource MP3Source;
  private string Path = "Role/";
  private string Music = "Music/";
  public float BaseVol;
  public bool MuteSFXVol;
  public byte[] PauseKey = new byte[20];
  private byte CurUseIndex;
  private short bPlayOnlyOneClip = -1;
  private AudioSourceController SourceController = new AudioSourceController();
  private AssetBundle AudioAssetBundle;
  private int AudioAssetBundleKey;

  private AudioManager()
  {
    this.AudioController = new GameObject(nameof (AudioController));
    Object.DontDestroyOnLoad((Object) this.AudioController);
    for (int index = 0; index < 2; ++index)
      this.BGMSource[index] = this.AudioController.AddComponent<AudioSource>();
    for (int index = 0; index < this.CloseQueue.Length; ++index)
      this.CloseQueue[index] = new AudioCloseQueue();
    this.Initial();
  }

  public static AudioManager Instance
  {
    get
    {
      if (AudioManager.instance == null)
        AudioManager.instance = new AudioManager();
      return AudioManager.instance;
    }
  }

  private void Initial()
  {
    this.poolIndex = (byte) 0;
    this.MarkSFXBundleKey = (short) -1;
    GameConstants.ArrayFill<int>(this.SFXBundleKey, 0);
    this.BaseVol = 1f;
    this.MuteSFXVol = false;
    this.www = (WWW) null;
    this.bCrossfade = false;
    this.BGMmainIndex = 0;
    this.SpeechSoundPrev = (byte) 0;
    this.DuckVolDecrease = 0.0f;
    this.DuckDeltaTime = 0.0f;
    this.DuckVolDecrease = 0.2921f;
    this.DuckDeltaTime = 0.0f;
    this.duckingstate = AudioManager.DuckingState.None;
    this.MusicVol = 1f;
    this.TmpVol = 0.0f;
    this.FireKey = 0;
    this.CloseQueueIndex = 0;
    GameConstants.ArrayFill<byte>(this.PauseKey, (byte) 0);
    this.MP3Key = 0;
  }

  public void LoadSFXObj()
  {
    if (this.AudioAssetBundleKey != 0)
      return;
    this.AudioAssetBundle = AssetManager.GetAssetBundle("UI/AudioAsset", out this.AudioAssetBundleKey);
    GameObject original = this.AudioAssetBundle.Load("SFX") as GameObject;
    for (byte index = 0; (int) index < this.SFXSource.Length; ++index)
    {
      GameObject target = (GameObject) Object.Instantiate((Object) original);
      Object.DontDestroyOnLoad((Object) target);
      this.SFXSource[(int) index] = target.GetComponent<AudioSource>();
      this.SFXSource[(int) index].transform.SetParent(this.AudioController.transform);
    }
    GameObject target1 = (GameObject) Object.Instantiate((Object) original);
    Object.DontDestroyOnLoad((Object) target1);
    this.MP3Source = target1.GetComponent<AudioSource>();
    this.MP3Source.transform.SetParent(this.AudioController.transform);
    GameObject target2 = (GameObject) Object.Instantiate((Object) (this.AudioAssetBundle.Load("SFXFire") as GameObject));
    Object.DontDestroyOnLoad((Object) target2);
    this.FireSFXSource = target2.GetComponent<AudioSource>();
    this.FireHighPass = target2.GetComponent<AudioHighPassFilter>();
    target2.transform.SetParent(this.AudioController.transform);
  }

  public void SetSFXEnvironment(SFXKind Kind)
  {
    CString cstring = StringManager.Instance.StaticString1024();
    if (Kind == SFXKind.Normal)
      cstring.Append("SFX");
    else
      cstring.Append("SFXLegion");
    GameObject original = this.AudioAssetBundle.Load(cstring.ToString(), typeof (GameObject)) as GameObject;
    for (byte index = 0; (int) index < this.SFXSource.Length; ++index)
    {
      Object.Destroy((Object) this.SFXSource[(int) index].gameObject);
      GameObject gameObject = (GameObject) Object.Instantiate((Object) original);
      this.SFXSource[(int) index] = gameObject.GetComponent<AudioSource>();
      this.SFXSource[(int) index].transform.SetParent(this.AudioController.transform);
    }
  }

  public BGMType GetCurMusic() => this.CurMusicType;

  public void LoadAndPlayBGM(BGMType Type, byte Loop = 1, bool Force = false)
  {
    if (this.www != null)
    {
      if (this.CurMusicType == Type)
        return;
      this.www.Dispose();
      this.www = (WWW) null;
      Resources.UnloadUnusedAssets();
    }
    this.CurMusicType = Type;
    if (!DataManager.Instance.MySysSetting.bMusic && !Force)
    {
      if (!((Object) this.BGMSource[this.BGMmainIndex].clip != (Object) null))
        return;
      Object.Destroy((Object) this.BGMSource[this.BGMmainIndex].clip);
      this.BGMSource[this.BGMmainIndex].clip = (AudioClip) null;
      this.BGMClip.clip = (AudioClip) null;
      this.BGMassetBundle[this.BGMmainIndex].Unload(true);
      this.BGMassetBundle[this.BGMmainIndex] = (AssetBundle) null;
      this.NowPlayBGMName = 0;
    }
    else
    {
      if (this.bCrossfade)
      {
        this.FadeTime = this.FadeTimeMax + 1f;
        this.UpdateCrossfade();
      }
      CString tmpS1 = StringManager.Instance.StaticString1024();
      tmpS1.ClearString();
      CString tmpS2 = StringManager.Instance.StaticString1024();
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.StringToFormat(tmpS2);
      cstring.StringToFormat(Application.streamingAssetsPath);
      switch (this.CurMusicType)
      {
        case BGMType.Main:
          cstring.StringToFormat(this.Path);
          tmpS1.Append("BGM10");
          break;
        case BGMType.Legion:
          if (DataManager.Instance.MySysSetting.mMusicSelect == (byte) 0)
          {
            cstring.StringToFormat(this.Path);
            tmpS1.Append("BGM02");
            break;
          }
          cstring.StringToFormat(this.Path);
          tmpS1.Append("BGM07");
          break;
        case BGMType.WarVictory:
          cstring.StringToFormat(this.Path);
          tmpS1.Append("BGM03");
          break;
        case BGMType.WarDefeat:
          cstring.StringToFormat(this.Path);
          tmpS1.Append("BGM04");
          break;
        case BGMType.War:
          cstring.StringToFormat(this.Path);
          tmpS1.Append("War01");
          break;
        case BGMType.LegionWar:
        case BGMType.Login:
          cstring.StringToFormat("Loading/");
          tmpS1.Append("War02");
          break;
        case BGMType.LegionVictory:
          cstring.StringToFormat(this.Path);
          tmpS1.Append("BGM05");
          break;
        case BGMType.LegionDefeat:
          cstring.StringToFormat(this.Path);
          tmpS1.Append("BGM06");
          break;
        case BGMType.Master:
          cstring.StringToFormat(this.Path);
          tmpS1.Append("BGM10");
          break;
        case BGMType.Newie:
          cstring.StringToFormat(this.Path);
          tmpS1.Append("BGM02");
          break;
      }
      cstring.StringToFormat(tmpS1);
      cstring.AppendFormat("{0}{1}/{2}{3}.unity3d");
      this.BGMLoop = Loop;
      if (this.NowPlayBGMName == cstring.GetHashCode(false))
      {
        if (this.BGMSource[this.BGMmainIndex].isPlaying)
          return;
        this.BGMSource[this.BGMmainIndex].loop = this.BGMLoop == (byte) 1;
        this.BGMSource[this.BGMmainIndex].Play();
        this.BGMSource[this.BGMmainIndex].volume = this.BaseVol;
      }
      else
        this.www = new WWW(cstring.ToString());
    }
  }

  public void UnLoadBGM()
  {
    for (int index = 0; index < 2; ++index)
    {
      if ((bool) (Object) this.BGMSource[index])
      {
        this.BGMSource[index].Stop();
        Object.Destroy((Object) this.BGMSource[index].clip);
      }
      if ((bool) (Object) this.BGMassetBundle[index])
        this.BGMassetBundle[index].Unload(true);
    }
    if (this.www != null)
    {
      this.www.assetBundle.Unload(true);
      this.www.Dispose();
      this.www = (WWW) null;
    }
    Resources.UnloadUnusedAssets();
    this.NowPlayBGMName = 0;
    this.bCrossfade = false;
  }

  public void PlayUISFXIndex(UIClickSoundIndex EnumSoundIndex)
  {
    switch (EnumSoundIndex)
    {
      case UIClickSoundIndex.Normal:
        this.PlayUISFX();
        break;
      case UIClickSoundIndex.Parameter:
        this.PlayUISFX(UIKind.Tag);
        break;
      case UIClickSoundIndex.Dynamic:
        this.PlayUISFX(UIKind.Tag);
        break;
      case UIClickSoundIndex.Catagory:
        this.PlayUISFX(UIKind.Tag);
        break;
    }
  }

  public void PlayUISFX(ref AudioSourceController controller, UIKind Kind = UIKind.Normal)
  {
    if (!this.PlayUISFX(Kind))
      return;
    int num = (int) this.poolIndex;
    if (num == 0)
      num = 19;
    controller = this.SourceController;
    controller.Set(this.SFXSource[num - 1]);
  }

  public bool PlayUISFX(UIKind Kind = UIKind.Normal)
  {
    if (this.MuteSFXVol || Kind == UIKind.None || this.AudioAssetBundleKey == 0)
      return false;
    this.GetEmptyIndex();
    CString Name = StringManager.Instance.StaticString1024();
    ushort x1 = (ushort) Kind;
    if (x1 == (ushort) 0)
      return false;
    int x2 = (int) x1 / 100;
    Name.StringToFormat(this.Path);
    Name.IntToFormat((long) x2, 3);
    Name.AppendFormat("{0}{1}");
    if (x1 == (ushort) 40030 && this.bPlayOnlyOneClip >= (short) 0)
      return false;
    AssetBundle assetBundle = AssetManager.GetAssetBundle(Name, out this.SFXBundleKey[(int) this.poolIndex]);
    if ((bool) (Object) assetBundle)
    {
      if (x1 == (ushort) 40030)
        this.bPlayOnlyOneClip = (short) this.poolIndex;
      Name.ClearString();
      Name.IntToFormat((long) x1);
      Name.AppendFormat("{0}");
      this.SFXClip.clip = assetBundle.Load(Name.ToString(), typeof (AudioClip)) as AudioClip;
      if ((Object) this.SFXClip.clip == (Object) null)
      {
        AssetManager.UnloadAssetBundle(this.SFXBundleKey[(int) this.poolIndex]);
        this.SFXBundleKey[(int) this.poolIndex] = 0;
        return false;
      }
      this.SFXClip.DelaySecond = new float?();
      this.SFXClip.Pitch = x2 != 300 || x1 == (ushort) 30005 ? 1f : (float) (0.89090001583099365 + 0.55299997329711914 * (double) Random.value);
      this.SFXClip.PanLevel = 0.0f;
      this.SFXClip.Loop = false;
      this.SFXClip.Volume = 1f;
      this.PlayAudio(this.SFXSource[(int) this.poolIndex++], this.SFXClip);
      this.ChangeDuckingState(AudioManager.DuckingState.Start);
      if (this.poolIndex >= (byte) 20)
        this.poolIndex = (byte) 0;
    }
    else
    {
      AssetManager.UnloadAssetBundle(this.SFXBundleKey[(int) this.poolIndex]);
      this.SFXBundleKey[(int) this.poolIndex] = 0;
    }
    return true;
  }

  public void PlaySFXCloseBGM(ushort NameID, float delay = 0.0f, PitchKind pitchkind = PitchKind.NoPitch, Transform PlayObj = null)
  {
    if (this.MuteSFXVol)
      return;
    this.AddCloseQueue((byte) 100);
    this.PlaySFX(NameID, delay, pitchkind, PlayObj);
    if (this.poolIndex == (byte) 0)
      this.poolIndex = (byte) 19;
    this.CurUseIndex = (byte) ((uint) this.poolIndex - 1U);
    this.PauseSFX(this.CurUseIndex);
  }

  public void PlaySFX(
    ushort NameID,
    float delay = 0.0f,
    PitchKind pitchkind = PitchKind.NoPitch,
    Transform PlayObj = null,
    Vector3? Position = null)
  {
    if (this.MuteSFXVol || NameID == (ushort) 0)
      return;
    int x = (int) NameID / 100;
    switch (x)
    {
      case 37:
      case 77:
        PlayObj = (Transform) null;
        break;
    }
    this.GetEmptyIndex();
    CString Name = StringManager.Instance.StaticString1024();
    Name.StringToFormat(this.Path);
    Name.IntToFormat((long) x, 3, true);
    Name.AppendFormat("{0}{1}");
    AssetBundle assetBundle = AssetManager.GetAssetBundle(Name, out this.SFXBundleKey[(int) this.poolIndex]);
    if ((bool) (Object) assetBundle)
    {
      Name.ClearString();
      Name.IntToFormat((long) NameID);
      Name.AppendFormat("{0}");
      this.SFXClip.clip = assetBundle.Load(Name.ToString(), typeof (AudioClip)) as AudioClip;
      if ((Object) this.SFXClip.clip == (Object) null)
      {
        AssetManager.UnloadAssetBundle(this.SFXBundleKey[(int) this.poolIndex]);
        this.SFXBundleKey[(int) this.poolIndex] = 0;
      }
      else
      {
        this.SFXClip.DelaySecond = new float?(delay);
        switch (pitchkind)
        {
          case PitchKind.SpeechSound:
            byte num = (byte) Mathf.Max(0.0f, (float) (30.0 * (double) Random.value / 10.0));
            if ((int) num == (int) this.SpeechSoundPrev)
            {
              ++num;
              if (num >= (byte) 3)
                num = (byte) 0;
            }
            this.SpeechSoundPrev = num;
            this.SFXClip.Pitch = this.SpeechSoundPitchVal[(int) this.SpeechSoundPrev];
            break;
          case PitchKind.Hit:
            this.SFXClip.Pitch = (float) (0.89090001583099365 + 0.23160000145435333 * (double) Random.value);
            break;
          default:
            this.SFXClip.Pitch = 1f;
            break;
        }
        if ((Object) PlayObj != (Object) null)
        {
          this.AttachAudioSound(this.poolIndex, PlayObj);
          this.SFXClip.PanLevel = 1f;
        }
        else if (Position.HasValue)
        {
          this.AttachAudioSound(this.poolIndex, Position.Value);
          this.SFXClip.PanLevel = 1f;
        }
        else
          this.SFXClip.PanLevel = 0.0f;
        this.SFXClip.Volume = 1f;
        this.SFXClip.Loop = false;
        this.PlayAudio(this.SFXSource[(int) this.poolIndex++], this.SFXClip);
        this.ChangeDuckingState(AudioManager.DuckingState.Start);
        if (this.poolIndex < (byte) 20)
          return;
        this.poolIndex = (byte) 0;
      }
    }
    else
    {
      if ((Object) this.SFXSource[(int) this.poolIndex] == (Object) null)
        Debug.LogWarning((object) string.Format("bundle_AbName({0}Null)", (object) NameID));
      AssetManager.UnloadAssetBundle(this.SFXBundleKey[(int) this.poolIndex]);
      this.SFXBundleKey[(int) this.poolIndex] = 0;
    }
  }

  private void GetEmptyIndex()
  {
    float num = 0.0f;
    byte Index = 0;
    while (this.SFXBundleKey[(int) this.poolIndex] != 0)
    {
      if ((int) this.poolIndex == (int) this.MarkSFXBundleKey)
      {
        this.DelSFXClip(Index);
        this.poolIndex = Index;
        break;
      }
      if (this.MarkSFXBundleKey == (short) -1)
        this.MarkSFXBundleKey = (short) this.poolIndex;
      if ((Object) this.SFXSource[(int) this.poolIndex] == (Object) null)
        Debug.LogWarning((object) string.Format("AudioSourceIndex({0}Null)", (object) this.poolIndex));
      if ((double) num < (double) this.SFXSource[(int) this.poolIndex].time)
      {
        num = this.SFXSource[(int) this.poolIndex].time;
        Index = this.poolIndex;
      }
      ++this.poolIndex;
      if (this.poolIndex >= (byte) 20)
        this.poolIndex = (byte) 0;
    }
    this.MarkSFXBundleKey = (short) -1;
  }

  public bool PlaySFXLoop(ushort NameID, out byte Key, Transform PlayObj = null, SFXEffect Effect = SFXEffect.Normal)
  {
    Key = (byte) 0;
    if (this.MuteSFXVol || NameID == (ushort) 0)
      return false;
    int x = (int) NameID / 100;
    this.GetEmptyIndex();
    CString Name = StringManager.Instance.StaticString1024();
    Name.StringToFormat(this.Path);
    Name.IntToFormat((long) x, 3, true);
    Name.AppendFormat("{0}{1}");
    if (Effect == SFXEffect.HighPassFilter)
      return this.PlaySFXLoopHighPass(NameID, out Key, PlayObj);
    AssetBundle assetBundle = AssetManager.GetAssetBundle(Name, out this.SFXBundleKey[(int) this.poolIndex]);
    if ((bool) (Object) assetBundle)
    {
      Name.ClearString();
      Name.IntToFormat((long) NameID);
      Name.AppendFormat("{0}");
      this.SFXClip.clip = assetBundle.Load(Name.ToString(), typeof (AudioClip)) as AudioClip;
      if ((Object) this.SFXClip.clip == (Object) null)
      {
        AssetManager.UnloadAssetBundle(this.SFXBundleKey[(int) this.poolIndex]);
        this.SFXBundleKey[(int) this.poolIndex] = 0;
        return false;
      }
      if ((Object) PlayObj != (Object) null)
      {
        this.AttachAudioSound(this.poolIndex, PlayObj);
        this.SFXClip.PanLevel = 1f;
      }
      else
        this.SFXClip.PanLevel = 0.0f;
      this.SFXClip.Loop = true;
      this.SFXClip.Volume = 1f;
      this.SFXClip.Pitch = 1f;
      Key = this.poolIndex;
      this.PlayAudio(this.SFXSource[(int) this.poolIndex++], this.SFXClip);
      this.ChangeDuckingState(AudioManager.DuckingState.Start);
      if (this.poolIndex >= (byte) 20)
        this.poolIndex = (byte) 0;
      return true;
    }
    AssetManager.UnloadAssetBundle(this.SFXBundleKey[(int) this.poolIndex]);
    this.SFXBundleKey[(int) this.poolIndex] = 0;
    return false;
  }

  private bool PlaySFXLoopHighPass(ushort NameID, out byte Key, Transform PlayObj = null)
  {
    Key = (byte) 0;
    if (this.FireKey != 0)
      return false;
    int x = (int) NameID / 100;
    CString Name = StringManager.Instance.StaticString1024();
    Name.StringToFormat(this.Path);
    Name.IntToFormat((long) x, 3, true);
    Name.AppendFormat("{0}{1}");
    AssetBundle assetBundle = AssetManager.GetAssetBundle(Name, out this.FireKey);
    if ((bool) (Object) assetBundle)
    {
      if ((Object) this.FireSFXSource.clip != (Object) null)
        this.FireSFXSource.Stop();
      Name.ClearString();
      Name.IntToFormat((long) NameID);
      Name.AppendFormat("{0}");
      this.SFXClip.clip = assetBundle.Load(Name.ToString(), typeof (AudioClip)) as AudioClip;
      if ((Object) this.SFXClip.clip == (Object) null)
      {
        AssetManager.UnloadAssetBundle(this.FireKey);
        this.FireKey = 0;
        return false;
      }
      if ((Object) PlayObj != (Object) null)
      {
        this.FireSFXSource.transform.position = PlayObj.position;
        this.SFXClip.PanLevel = 1f;
      }
      else
        this.SFXClip.PanLevel = 0.0f;
      this.SFXClip.Loop = true;
      this.SFXClip.Volume = 1f;
      this.SFXClip.Pitch = 1f;
      Key = (byte) 20;
      this.PlayAudio(this.FireSFXSource, this.SFXClip);
      this.ChangeDuckingState(AudioManager.DuckingState.Start);
      return true;
    }
    AssetManager.UnloadAssetBundle(this.FireKey);
    this.FireKey = 0;
    return false;
  }

  private void ChangeDuckingState(AudioManager.DuckingState State)
  {
    if (State == this.duckingstate || State == AudioManager.DuckingState.Start && this.duckingstate == AudioManager.DuckingState.Extend)
      return;
    this.duckingstate = State;
    this.DuckDeltaTime = 0.0f;
    this.TmpVol = 0.0f;
  }

  public void SwitchMusic(bool TurnOn)
  {
    if (TurnOn)
    {
      if ((Object) this.BGMSource[this.BGMmainIndex].clip != (Object) null)
        this.BGMSource[this.BGMmainIndex].Play();
      else
        this.LoadAndPlayBGM(this.CurMusicType, (byte) 1);
    }
    else
      this.BGMSource[this.BGMmainIndex].Stop();
  }

  public void StopSFX(byte Key, bool bFadeOut = true)
  {
    if (Key < (byte) 20)
    {
      if ((Object) this.SFXSource[(int) Key].clip == (Object) null)
        return;
      if (!bFadeOut)
        this.SFXSource[(int) Key].Stop();
    }
    else if ((Object) this.FireSFXSource.clip == (Object) null)
      return;
    this.AddCloseQueue(Key);
  }

  public void AddCloseQueue(byte Key)
  {
    int index = ++this.CloseQueueIndex & 3;
    if (Key < (byte) 20)
      this.CloseQueue[index].SetAudio(this.SFXSource[(int) Key], Key);
    else if (Key == (byte) 100)
      this.CloseQueue[index].SetAudio(this.BGMSource[this.BGMmainIndex], Key, 0.75f);
    else
      this.CloseQueue[index].SetAudio(this.FireSFXSource, Key);
  }

  public void PauseSFX(byte Key)
  {
    if (Key < (byte) 20)
    {
      if ((Object) this.SFXSource[(int) Key] == (Object) null)
        return;
      this.SFXSource[(int) Key].Pause();
      this.PauseKey[(int) Key] = (byte) 1;
    }
    else
    {
      if (!(bool) (Object) this.FireSFXSource)
        return;
      this.FireSFXSource.Pause();
    }
  }

  public void PlaySFX(byte Key)
  {
    if (Key < (byte) 20)
    {
      if ((Object) this.SFXSource[(int) Key].clip == (Object) null)
        return;
      this.PauseKey[(int) Key] = (byte) 0;
      this.SFXSource[(int) Key].Play();
    }
    else
    {
      if (!(bool) (Object) this.FireSFXSource)
        return;
      this.FireSFXSource.Play();
    }
  }

  public void SetFireSize(float Size)
  {
    this.FireSFXSource.volume = Size * 0.5f * this.BaseVol;
    this.FireHighPass.cutoffFrequency = (float) (220.0 - (double) Size * 220.0);
  }

  public void PlayMP3SFX(ushort NameID, float delay = 0.0f)
  {
    if (this.MuteSFXVol || NameID == (ushort) 0)
      return;
    if (this.MP3Key != 0)
    {
      if ((int) NameID == (int) this.MP3ABName)
        return;
      this.MP3Source.Stop();
      AssetManager.UnloadAssetBundle(this.MP3Key);
      this.MP3Key = 0;
    }
    this.MP3ABName = NameID;
    int x = (int) NameID / 100;
    CString Name = StringManager.Instance.StaticString1024();
    Name.StringToFormat(this.Path);
    Name.IntToFormat((long) x, 3, true);
    Name.AppendFormat("{0}{1}");
    AssetBundle assetBundle = AssetManager.GetAssetBundle(Name, out this.MP3Key);
    if ((bool) (Object) assetBundle)
    {
      Name.ClearString();
      Name.IntToFormat((long) NameID);
      Name.AppendFormat("{0}");
      this.SFXClip.clip = assetBundle.Load(Name.ToString(), typeof (AudioClip)) as AudioClip;
      if ((Object) this.SFXClip.clip == (Object) null)
      {
        AssetManager.UnloadAssetBundle(this.MP3Key);
        this.MP3Key = 0;
        this.MP3ABName = (ushort) 0;
      }
      else
      {
        this.SFXClip.DelaySecond = new float?(delay);
        this.SFXClip.Pitch = 1f;
        this.SFXClip.PanLevel = 0.0f;
        this.SFXClip.Volume = 1f;
        this.SFXClip.Loop = false;
        this.PlayAudio(this.MP3Source, this.SFXClip);
        this.ChangeDuckingState(AudioManager.DuckingState.Start);
        if (this.poolIndex < (byte) 20)
          return;
        this.poolIndex = (byte) 0;
      }
    }
    else
    {
      AssetManager.UnloadAssetBundle(this.MP3Key);
      this.MP3Key = 0;
      this.MP3ABName = (ushort) 0;
    }
  }

  public void PlayMP3SFX(BGMType Type, bool bLoop = true, float Vol = 1f)
  {
    if (!DataManager.Instance.MySysSetting.bMusic)
      return;
    if (this.MP3Key != 0)
    {
      if ((int) (ushort) Type == (int) this.MP3ABName)
        return;
      this.MP3Source.Stop();
      AssetManager.UnloadAssetBundle(this.MP3Key);
      this.MP3Key = 0;
    }
    if (this.bCrossfade)
    {
      this.FadeTime = this.FadeTimeMax + 1f;
      this.UpdateCrossfade();
    }
    CString tmpS = StringManager.Instance.StaticString1024();
    tmpS.ClearString();
    CString Name = StringManager.Instance.StaticString1024();
    switch (Type)
    {
      case BGMType.Main:
        Name.StringToFormat(this.Path);
        tmpS.Append("BGM10");
        break;
      case BGMType.Legion:
        Name.StringToFormat(this.Path);
        tmpS.Append("BGM02");
        break;
      case BGMType.WarVictory:
        Name.StringToFormat(this.Path);
        tmpS.Append("BGM03");
        break;
      case BGMType.WarDefeat:
        Name.StringToFormat(this.Path);
        tmpS.Append("BGM04");
        break;
      case BGMType.War:
        Name.StringToFormat(this.Path);
        tmpS.Append("War01");
        break;
      case BGMType.LegionWar:
        Name.StringToFormat("Loading/");
        tmpS.Append("War02");
        break;
      case BGMType.LegionVictory:
        Name.StringToFormat(this.Path);
        tmpS.Append("BGM05");
        break;
      case BGMType.LegionDefeat:
        Name.StringToFormat(this.Path);
        tmpS.Append("BGM06");
        break;
    }
    Name.StringToFormat(tmpS);
    Name.AppendFormat("{0}{1}");
    AssetBundle assetBundle = AssetManager.GetAssetBundle(Name, out this.MP3Key);
    if ((bool) (Object) assetBundle)
    {
      this.SFXClip.clip = assetBundle.mainAsset as AudioClip;
      if ((Object) this.SFXClip.clip == (Object) null)
      {
        AssetManager.UnloadAssetBundle(this.MP3Key);
        this.MP3Key = 0;
        this.MP3ABName = (ushort) 0;
      }
      else
      {
        this.BGMSource[this.BGMmainIndex].Stop();
        this.MP3ABName = (ushort) Type;
        this.SFXClip.Pitch = 1f;
        this.SFXClip.PanLevel = 0.0f;
        this.SFXClip.Volume = Vol;
        this.SFXClip.Loop = bLoop;
        this.PlayAudio(this.MP3Source, this.SFXClip);
        if (this.poolIndex < (byte) 20)
          return;
        this.poolIndex = (byte) 0;
      }
    }
    else
    {
      AssetManager.UnloadAssetBundle(this.MP3Key);
      this.MP3Key = 0;
      this.MP3ABName = (ushort) 0;
    }
  }

  public void StopMP3AndPlayBGM()
  {
    this.MP3Source.Stop();
    if (this.MP3Key != 0)
    {
      AssetManager.UnloadAssetBundle(this.MP3Key);
      this.MP3Key = 0;
      this.MP3ABName = (ushort) 0;
    }
    if (!DataManager.Instance.MySysSetting.bMusic)
      return;
    this.BGMSource[this.BGMmainIndex].Play();
  }

  public void Update()
  {
    if (this.www != null && this.www.isDone)
    {
      if ((Object) this.BGMSource[this.BGMmainIndex].clip == (Object) null)
      {
        this.BGMassetBundle[this.BGMmainIndex] = this.www.assetBundle;
        this.BGMClip.clip = this.www.GetAudioClip(false, true, AudioType.MPEG);
        this.BGMClip.Loop = this.BGMLoop == (byte) 1;
        this.BGMClip.Volume = this.BaseVol;
        this.BGMClip.PanLevel = 0.0f;
        this.PlayAudio(this.BGMSource[this.BGMmainIndex], this.BGMClip);
      }
      else if (!this.BGMSource[this.BGMmainIndex].isPlaying)
      {
        Object.Destroy((Object) this.BGMSource[this.BGMmainIndex].clip);
        this.BGMSource[this.BGMmainIndex].clip = (AudioClip) null;
        if ((Object) this.BGMassetBundle[this.BGMmainIndex] != (Object) null)
          this.BGMassetBundle[this.BGMmainIndex].Unload(true);
        this.BGMassetBundle[this.BGMmainIndex] = (AssetBundle) null;
        this.BGMassetBundle[this.BGMmainIndex] = this.www.assetBundle;
        this.BGMClip.clip = this.www.GetAudioClip(false, true, AudioType.MPEG);
        this.BGMClip.Loop = this.BGMLoop == (byte) 1;
        this.BGMClip.Volume = this.BaseVol;
        this.BGMClip.PanLevel = 0.0f;
        this.PlayAudio(this.BGMSource[this.BGMmainIndex], this.BGMClip);
      }
      else if (!this.bCrossfade)
      {
        this.BGMmainIndex = ++this.BGMmainIndex & 1;
        this.BGMassetBundle[this.BGMmainIndex] = this.www.assetBundle;
        this.BGMClip.clip = this.www.GetAudioClip(false, true, AudioType.MPEG);
        this.BGMClip.Loop = this.BGMLoop == (byte) 1;
        this.BGMClip.Volume = 0.0f;
        this.BGMClip.PanLevel = 0.0f;
        this.PlayAudio(this.BGMSource[this.BGMmainIndex], this.BGMClip);
        this.bCrossfade = true;
      }
      this.NowPlayBGMName = this.www.url.GetHashCode();
      this.www.Dispose();
      this.www = (WWW) null;
      Resources.UnloadUnusedAssets();
    }
    if (this.bCrossfade)
      this.UpdateCrossfade();
    this.PlaySFXCount = (byte) 0;
    for (byte Index = 0; (int) Index < this.SFXSource.Length && !((Object) this.SFXSource[(int) Index] == (Object) null); ++Index)
    {
      if (!((Object) this.SFXSource[(int) Index].clip == (Object) null))
      {
        if (!this.SFXSource[(int) Index].isPlaying && this.PauseKey[(int) Index] == (byte) 0)
        {
          this.SourceController.CheckValid(this.SFXSource[(int) Index]);
          this.DelSFXClip(Index);
        }
        else
        {
          if ((bool) (Object) this.PlaySFXTrans[(int) Index])
            this.SFXSource[(int) Index].transform.position = this.PlaySFXTrans[(int) Index].position;
          ++this.PlaySFXCount;
        }
      }
    }
    if ((Object) this.MP3Source != (Object) null && !this.MP3Source.isPlaying && this.MP3Key != 0)
    {
      AssetManager.UnloadAssetBundle(this.MP3Key);
      this.MP3Key = 0;
      this.MP3ABName = (ushort) 0;
    }
    this.UpdateDucking();
    this.UpdateCloseFadeOut();
  }

  private void UpdateCrossfade()
  {
    int index = this.BGMmainIndex + 1 & 1;
    this.BGMSource[index].volume = this.OutQuintic(this.FadeTime, 1f, -1f, this.FadeTimeMax);
    this.BGMSource[this.BGMmainIndex].volume = 1f - this.BGMSource[index].volume;
    if ((double) this.FadeTime > (double) this.FadeTimeMax)
    {
      this.BGMSource[index].Stop();
      if ((Object) this.BGMSource[index].clip != (Object) null)
        Object.Destroy((Object) this.BGMSource[index].clip);
      this.BGMSource[index].clip = (AudioClip) null;
      this.BGMClip.clip = (AudioClip) null;
      if ((Object) this.BGMassetBundle[index] != (Object) null)
        this.BGMassetBundle[index].Unload(true);
      this.BGMassetBundle[index] = (AssetBundle) null;
      this.bCrossfade = false;
      this.FadeTime = 0.0f;
    }
    else
      this.FadeTime += Time.deltaTime;
  }

  public float OutQuintic(float t, float b, float c, float d)
  {
    float num1 = (t /= d) * t;
    float num2 = num1 * t;
    return b + c * (float) (-1.0 * (double) num1 * (double) num1 + 4.0 * (double) num2 + -6.0 * (double) num1 + 4.0 * (double) t);
  }

  public void DelSFXClip(byte Index)
  {
    this.PlaySFXTrans[(int) Index] = (Transform) null;
    this.SFXSource[(int) Index].clip = (AudioClip) null;
    AssetManager.UnloadAssetBundle(this.SFXBundleKey[(int) Index]);
    this.SFXBundleKey[(int) Index] = 0;
    if ((int) this.bPlayOnlyOneClip != (int) Index)
      return;
    this.bPlayOnlyOneClip = (short) -1;
  }

  public void DelFireClip()
  {
    this.FireSFXSource.clip = (AudioClip) null;
    AssetManager.UnloadAssetBundle(this.FireKey);
    this.FireKey = 0;
  }

  private void UpdateDucking()
  {
    if (this.bCrossfade)
      return;
    switch (this.duckingstate)
    {
      case AudioManager.DuckingState.Start:
        float num1 = this.DuckVolDecrease * (this.DuckDeltaTime / 1f);
        this.BGMSource[this.BGMmainIndex].volume = (this.BGMSource[this.BGMmainIndex].volume - (num1 - this.TmpVol)) * this.BaseVol * this.MusicVol;
        this.TmpVol = num1;
        this.DuckDeltaTime += Time.deltaTime;
        if ((double) this.DuckDeltaTime <= 1.0)
          break;
        this.DuckVolDecrease = 0.0f;
        this.ChangeDuckingState(AudioManager.DuckingState.Extend);
        break;
      case AudioManager.DuckingState.Extend:
        if (this.PlaySFXCount == (byte) 0)
          this.DuckDeltaTime += Time.deltaTime;
        else
          this.DuckDeltaTime = 0.0f;
        if ((double) this.DuckDeltaTime <= 1.0)
          break;
        this.ChangeDuckingState(AudioManager.DuckingState.Cancel);
        break;
      case AudioManager.DuckingState.Cancel:
        float num2 = (float) (0.29210001230239868 * ((double) this.DuckDeltaTime / 1.0));
        this.BGMSource[this.BGMmainIndex].volume = (this.BGMSource[this.BGMmainIndex].volume + (num2 - this.DuckVolDecrease)) * this.BaseVol * this.MusicVol;
        this.DuckVolDecrease = num2;
        this.DuckDeltaTime += Time.deltaTime;
        if ((double) this.DuckDeltaTime <= 1.0)
          break;
        this.ChangeDuckingState(AudioManager.DuckingState.None);
        this.BGMSource[this.BGMmainIndex].volume = this.MusicVol * this.BaseVol;
        break;
    }
  }

  private void UpdateCloseFadeOut()
  {
    for (int index = 0; index < this.CloseQueue.Length; ++index)
      this.CloseQueue[index].Update();
  }

  public void NotifyCloseSFX(byte Key)
  {
    if (Key == (byte) 100)
      this.PlaySFX(this.CurUseIndex);
    else if (Key < (byte) 20)
      this.DelSFXClip(Key);
    else
      this.DelFireClip();
  }

  private void PlayAudio(AudioSource au, ClipInfo clipInfo)
  {
    if (au.isPlaying)
      au.Stop();
    au.loop = clipInfo.Loop;
    au.volume = clipInfo.Volume * this.BaseVol;
    au.pitch = clipInfo.Pitch;
    au.clip = clipInfo.clip;
    au.panLevel = clipInfo.PanLevel;
    au.enabled = true;
    if (!clipInfo.DelaySecond.HasValue)
      au.Play();
    else
      au.PlayDelayed(clipInfo.DelaySecond.Value);
    clipInfo.clear();
  }

  public void Destroy()
  {
    this.UnLoadBGM();
    this.ChangeDuckingState(AudioManager.DuckingState.None);
    for (byte index = 0; (int) index < this.SFXBundleKey.Length; ++index)
    {
      if (this.SFXBundleKey[(int) index] != 0)
      {
        if ((bool) (Object) this.SFXSource[(int) index])
        {
          this.SFXSource[(int) index].Stop();
          this.SFXSource[(int) index].clip = (AudioClip) null;
        }
        AssetManager.UnloadAssetBundle(this.SFXBundleKey[(int) index]);
      }
    }
    if (this.MP3Key != 0)
    {
      if ((bool) (Object) this.MP3Source)
      {
        this.MP3Source.Stop();
        this.MP3Source.clip = (AudioClip) null;
      }
      AssetManager.UnloadAssetBundle(this.MP3Key);
    }
    if (this.AudioAssetBundleKey != 0)
      AssetManager.UnloadAssetBundle(this.AudioAssetBundleKey);
    this.AudioAssetBundle = (AssetBundle) null;
    Object.Destroy((Object) this.AudioController);
  }

  public void RetrieveSFX()
  {
    for (byte Index = 0; (int) Index < this.SFXSource.Length; ++Index)
    {
      if (this.SFXSource[(int) Index].isPlaying || this.PauseKey[(int) Index] == (byte) 1)
      {
        this.SFXSource[(int) Index].Stop();
        this.DelSFXClip(Index);
      }
    }
    if (!(bool) (Object) this.FireSFXSource.clip)
      return;
    this.FireSFXSource.Stop();
    this.DelFireClip();
  }

  private void AttachAudioSound(byte sourceIndex, Transform transform)
  {
    this.SFXSource[(int) sourceIndex].transform.position = transform.position;
    this.PlaySFXTrans[(int) sourceIndex] = transform;
  }

  private void AttachAudioSound(byte sourceIndex, Vector3 position)
  {
    this.SFXSource[(int) sourceIndex].transform.position = position;
  }

  private enum DuckingState
  {
    Start,
    Extend,
    Cancel,
    None,
  }
}
