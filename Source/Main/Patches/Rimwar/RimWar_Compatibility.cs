// Decompiled with JetBrains decompiler
// Type: DIgnoranceIsBliss.RimWar_Patches.RimWar_Compatibility
// Assembly: IgnoranceIsBliss, Version=1.4.0.2, Culture=neutral, PublicKeyToken=null
// MVID: 3D375A9A-AE87-4AAD-A8D5-35CB8B7F5DFC
// Assembly location: E:\SteamLibrary\steamapps\workshop\content\294100\2554423472\1.4\Assemblies\IgnoranceIsBliss.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DIgnoranceIsBliss.RimWar_Patches
{
  internal static class RimWar_Compatibility
  {
    public static readonly Assembly assembly = ((IEnumerable<Assembly>) AppDomain.CurrentDomain.GetAssemblies()).SingleOrDefault<Assembly>((Func<Assembly, bool>) (assembly => assembly.GetName().Name == "RimWar"));
  }
}
