// Decompiled with JetBrains decompiler
// Type: SevenZip.ICoder
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.IO;

#nullable disable
namespace SevenZip
{
  public interface ICoder
  {
    void Code(
      Stream inStream,
      Stream outStream,
      long inSize,
      long outSize,
      ICodeProgress progress);
  }
}
