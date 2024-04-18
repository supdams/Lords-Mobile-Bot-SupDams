// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.PlatformConfiguration
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal abstract class PlatformConfiguration : BaseReferenceHolder
  {
    protected PlatformConfiguration(IntPtr selfPointer)
      : base(selfPointer)
    {
    }

    internal HandleRef AsHandle() => this.SelfPtr();
  }
}
