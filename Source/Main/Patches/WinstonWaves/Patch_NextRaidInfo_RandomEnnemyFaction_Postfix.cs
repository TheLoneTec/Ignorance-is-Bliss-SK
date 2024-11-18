// Decompiled with JetBrains decompiler
// Type: DIgnoranceIsBliss.WinstonWaves_Patches.Patch_NextRaidInfo_RandomEnnemyFaction_Postfix
// Assembly: IgnoranceIsBliss, Version=1.4.0.2, Culture=neutral, PublicKeyToken=null
// MVID: 3D375A9A-AE87-4AAD-A8D5-35CB8B7F5DFC
// Assembly location: E:\SteamLibrary\steamapps\workshop\content\294100\2554423472\1.4\Assemblies\IgnoranceIsBliss.dll

using DIgnoranceIsBliss.Core_Patches;
using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;

namespace DIgnoranceIsBliss.WinstonWaves_Patches
{
  [HarmonyPatch]
  internal class Patch_NextRaidInfo_RandomEnnemyFaction_Postfix
  {
    private static MethodBase targetMethod = (MethodBase) null;
    private static readonly string className = "VSEWW.NextRaidInfo";
    private static readonly string methodName = "RandomEnnemyFaction";

    [HarmonyTargetMethod]
    internal static MethodBase TargetMethod() => Patch_NextRaidInfo_RandomEnnemyFaction_Postfix.targetMethod;

    [HarmonyPrepare]
    internal static bool Prepare()
    {
      if (WinstonWaves_Compatibility.assembly == (Assembly) null)
        return false;
      System.Type type = WinstonWaves_Compatibility.assembly.GetType(Patch_NextRaidInfo_RandomEnnemyFaction_Postfix.className);
      if (type != (System.Type) null)
      {
        Patch_NextRaidInfo_RandomEnnemyFaction_Postfix.targetMethod = (MethodBase) AccessTools.Method(type, Patch_NextRaidInfo_RandomEnnemyFaction_Postfix.methodName);
        if (Patch_NextRaidInfo_RandomEnnemyFaction_Postfix.targetMethod != (MethodBase) null)
          return true;
        D.Error("The VSE - Winston Waves mod was found, but the " + Patch_NextRaidInfo_RandomEnnemyFaction_Postfix.methodName + " method was not. It's likely that API changed, please report the issue to mod developers");
        return false;
      }
      D.Error("The VSE - Winston Waves mod was found, but the " + Patch_NextRaidInfo_RandomEnnemyFaction_Postfix.className + " class was not. It's likely that API changed, please report the issue to mod developers");
      return false;
    }

    [HarmonyPostfix]
    public static void Postfix(ref Faction __result)
    {
      D.Debug("Postfix: " + __result.def.defName);
      if (IgnoranceBase.FactionInEligibleTechRange(__result))
        return;
      D.Debug("WinstonWaves_Patches: Faction " + __result.def.defName + " is not eligible. ");
      __result = IgnoranceBase.GetRandomEligibleFaction();
      if (__result != null)
      {
        D.Debug("WinstonWaves_Patches: Changed to " + __result.def.defName);
      }
      else
      {
        __result = Find.FactionManager.RandomEnemyFaction(allowDefeated: true);
        D.Debug("WinstonWaves_Patches: No eligible factions found at all. Forcing to use " + __result.def.defName + " to save Winston Waves from bugging out. Consider changing mod settings to allow more factions to raid you.");
      }
    }
  }
}
