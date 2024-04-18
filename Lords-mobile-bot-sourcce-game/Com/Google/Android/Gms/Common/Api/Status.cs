// Decompiled with JetBrains decompiler
// Type: Com.Google.Android.Gms.Common.Api.Status
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using Google.Developers;
using System;

#nullable disable
namespace Com.Google.Android.Gms.Common.Api
{
  public class Status : JavaObjWrapper, Result
  {
    private const string CLASS_NAME = "com/google/android/gms/common/api/Status";

    public Status(IntPtr ptr)
      : base(ptr)
    {
    }

    public Status(int arg_int_1, string arg_string_2, object arg_object_3)
    {
      this.CreateInstance("com/google/android/gms/common/api/Status", (object) arg_int_1, (object) arg_string_2, arg_object_3);
    }

    public Status(int arg_int_1, string arg_string_2)
    {
      this.CreateInstance("com/google/android/gms/common/api/Status", (object) arg_int_1, (object) arg_string_2);
    }

    public Status(int arg_int_1)
    {
      this.CreateInstance("com/google/android/gms/common/api/Status", (object) arg_int_1);
    }

    public static object CREATOR
    {
      get
      {
        return JavaObjWrapper.GetStaticObjectField<object>("com/google/android/gms/common/api/Status", nameof (CREATOR), "Landroid/os/Parcelable$Creator;");
      }
    }

    public static string NULL
    {
      get
      {
        return JavaObjWrapper.GetStaticStringField("com/google/android/gms/common/api/Status", nameof (NULL));
      }
    }

    public static int CONTENTS_FILE_DESCRIPTOR
    {
      get
      {
        return JavaObjWrapper.GetStaticIntField("com/google/android/gms/common/api/Status", nameof (CONTENTS_FILE_DESCRIPTOR));
      }
    }

    public static int PARCELABLE_WRITE_RETURN_VALUE
    {
      get
      {
        return JavaObjWrapper.GetStaticIntField("com/google/android/gms/common/api/Status", nameof (PARCELABLE_WRITE_RETURN_VALUE));
      }
    }

    public bool equals(object arg_object_1)
    {
      return this.InvokeCall<bool>(nameof (equals), "(Ljava/lang/Object;)Z", arg_object_1);
    }

    public string toString() => this.InvokeCall<string>(nameof (toString), "()Ljava/lang/String;");

    public int hashCode() => this.InvokeCall<int>(nameof (hashCode), "()I");

    public bool isInterrupted() => this.InvokeCall<bool>(nameof (isInterrupted), "()Z");

    public Status getStatus()
    {
      return this.InvokeCall<Status>(nameof (getStatus), "()Lcom/google/android/gms/common/api/Status;");
    }

    public bool isCanceled() => this.InvokeCall<bool>(nameof (isCanceled), "()Z");

    public int describeContents() => this.InvokeCall<int>(nameof (describeContents), "()I");

    public object getResolution()
    {
      return this.InvokeCall<object>(nameof (getResolution), "()Landroid/app/PendingIntent;");
    }

    public int getStatusCode() => this.InvokeCall<int>(nameof (getStatusCode), "()I");

    public string getStatusMessage()
    {
      return this.InvokeCall<string>(nameof (getStatusMessage), "()Ljava/lang/String;");
    }

    public bool hasResolution() => this.InvokeCall<bool>(nameof (hasResolution), "()Z");

    public void startResolutionForResult(object arg_object_1, int arg_int_2)
    {
      this.InvokeCallVoid(nameof (startResolutionForResult), "(Landroid/app/Activity;I)V", arg_object_1, (object) arg_int_2);
    }

    public void writeToParcel(object arg_object_1, int arg_int_2)
    {
      this.InvokeCallVoid(nameof (writeToParcel), "(Landroid/os/Parcel;I)V", arg_object_1, (object) arg_int_2);
    }

    public bool isSuccess() => this.InvokeCall<bool>(nameof (isSuccess), "()Z");
  }
}
