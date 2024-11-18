// Decompiled with JetBrains decompiler
// Type: DIgnoranceIsBliss.RimWar_Patches.Patch_CreateScout_Prefix
// Assembly: IgnoranceIsBliss, Version=1.4.0.2, Culture=neutral, PublicKeyToken=null
// MVID: 3D375A9A-AE87-4AAD-A8D5-35CB8B7F5DFC
// Assembly location: E:\SteamLibrary\steamapps\workshop\content\294100\2554423472\1.4\Assemblies\IgnoranceIsBliss.dll

using DIgnoranceIsBliss.Core_Patches;
using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using System.Reflection;

namespace DIgnoranceIsBliss.RimWar_Patches
{
  [HarmonyPatch]
  internal class Patch_CreateScout_Prefix
  {
    private static MethodBase targetMethod;

    [HarmonyTargetMethod]
    internal static MethodBase TargetMethod() => Patch_CreateScout_Prefix.targetMethod;

    [HarmonyPrepare]
    internal static bool Prepare()
    {
      if (RimWar_Compatibility.assembly == (Assembly) null)
        return false;
      Patch_CreateScout_Prefix.targetMethod = (MethodBase) AccessTools.Method(RimWar_Compatibility.assembly.GetType("RimWar.Planet.WorldUtility"), "CreateScout");
      return true;
    }

    [HarmonyPrefix]
    public static bool Prefix(Settlement parentSettlement, WorldObject destination) => !destination.Faction.IsPlayerSafe() || IgnoranceBase.FactionInEligibleTechRange(parentSettlement.Faction);
  }
}
