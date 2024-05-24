using System.Linq;
using ATS_API.Biomes;
using ATS_API.Effects;
using ATS_API.Goods;
using ATS_API.Helpers;
using ATS_API.Orders;
using ATS_API.Scripts.Races;
using ATS_API.Traders;
using BepInEx;
using BepInEx.Logging;
using Eremite;
using Eremite.Buildings;
using Eremite.Buildings.UI;
using Eremite.Controller;
using Eremite.Model;
using Eremite.Services;
using Eremite.WorldMap.UI.CustomGames;
using HarmonyLib;
using UnityEngine;

namespace ATS_API;

[HarmonyPatch]
[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public static string PluginDirectory;
        
    public static Plugin Instance;
    public static ManualLogSource Log;
    private Harmony harmony;
        

    private void Awake()
    {
        Instance = this;
        Log = Logger;
        harmony = Harmony.CreateAndPatchAll(typeof(Plugin).Assembly, PluginInfo.PLUGIN_GUID);

        PluginDirectory = Info.Location.Replace("API.dll", "");

        string expectedUnityVersion = "2021.3.27f1";
        Assert.IsEqual(Application.unityVersion, expectedUnityVersion, $"The Unity Version has changed!");

        // Stops Unity from destroying it for some reason. Same as Setting the BepInEx config HideManagerGameObject to true.
        gameObject.hideFlags = HideFlags.HideAndDontSave;
        
        // Hotkeys.RegisterKey("Reset Tradder", KeyCode.F1, () =>
        // {
        //     Logger.LogInfo($"Resetting trader!");
        //     TradeService tradeService = (TradeService)GameMB.TradeService;
        //     tradeService.Leave();
        // });
        
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
    }

    private void CreateRaces()
    {
        _ = new RaceBuilder(PluginInfo.PLUGIN_GUID, "Shardling", "Xenomorph")
            .Copy(RaceTypes.Harpy.ToRaceModel())
            .SetDisplayName("Shardling")
            .SetPluralName("Shardlings")
            .SetDescription($"Shardlings are steadfast and enduring, excelling in mining (<sprite name=\"mining\">) and metallurgy (<sprite name=\"metallurgy\">). They thrive in rocky environments and are extremely resilient. While their stone-like bodies make them very slow, they have a unique affinity for storms, drawing energy from the chaotic weather.")
            .SetNeeds(NeedTypes.Any_Housing, NeedTypes.Luxury, NeedTypes.Pickled_Goods, NeedTypes.Treatment) // Needs 8?
            .SetRacialHousingNeed(NeedTypes.Human_Housing)
            .SetCharacteristics(new RaceCharacteristicModel[]
            {
                new RaceCharacteristicBuilder(BuildingTagTypes.Tech)
                    .SetEffect(VillagerPerkTypes.Proficiency),
                new RaceCharacteristicBuilder(BuildingTagTypes.Wood)
                    .SetEffect(VillagerPerkTypes.Proficiency)
                //todo add global hearth effect?
            });

        Log.LogError($"RACES:");
        foreach (var race in SO.Settings.Races)
        {
            Log.LogError($"{race}");
        }
    }

    private void LateUpdate()
    {
        GoodsManager.Tick();
        EffectManager.Tick();
        TraderManager.Tick();
        OrdersManager.Tick();
        BiomeManager.Tick();
        TextMeshProManager.Tick();
        RaceManager.Tick();
        
        // TODO: PostTick to set up links between objects since we can't guarantee they will be loaded in roder.
    }
        
    [HarmonyPatch(typeof(MainController), nameof(MainController.InitReferences))]
    [HarmonyPostfix]
    private static void PostSetupMainController()
    {
        Log.LogInfo($"PostSetupMainController");
        GoodsManager.Instantiate();
        EffectManager.Instantiate();
        TraderManager.Instantiate();
        OrdersManager.Instantiate();
        BiomeManager.Instantiate();
        TextMeshProManager.Instantiate();
        RaceManager.Instantiate();
            
        // DumpPerksToJSON(MB.Settings.Relics, "Relics");
        // DumpPerksToJSON(MB.Settings.orders, "Orders");
        // DumpGoodsToJSON(MB.Settings.Goods, "Goods");
    }
        
    [HarmonyPatch(typeof(MainController), nameof(MainController.OnServicesReady))]
    [HarmonyPostfix]
    private static void HookMainControllerSetup()
    { 
        // This method will run after game load (Roughly on entering the main menu)
        // At this point a lot of the game's data will be available.
        // Your main entry point to access this data will be `Serviceable.Settings` or `MainController.Instance.Settings`
        Instance.Logger.LogInfo($"Performing game initialization on behalf of {PluginInfo.PLUGIN_GUID}.");
        Instance.Logger.LogInfo($"The game has loaded {MainController.Instance.Settings.effects.Length} effects.");

        Instance.CreateRaces();
        
        
        // ExportWikiInformation();
        
        /*
        Log.LogError($"HERE YOU IDIOT");
        
        //foreach (var effect in SO.Settings.resolveEffects)
        //{
        //    Log.LogWarning($"{effect},");
        //}
        foreach (var race in SO.Settings.Races)
        {
            Log.LogError($"{race}");
            foreach (var model in race.characteristics)
            {
                Log.LogWarning($"Tag: {model.tag}\nEffect: {model.effect}\nGlobal: {model.globalEffect}\nBuilding:{model.buildingPerk}");
            }
        }
        Log.LogError($"HERE TOO");
        foreach (var perk in SO.Settings.buildingsTags)
        {
            Log.LogWarning($"{perk}");
        }
        
        Log.LogError($"HERE TOO");
        foreach (var perk in SO.Settings.villagersPerks)
        {
            Log.LogWarning($"{perk}");
        }
        
        var count = 0;
        foreach (var race in SO.Settings.Races)
        {
            Instance.Logger.LogInfo($"RACE: {race} {count++}");
            
            Instance.Logger.LogInfo(race.ToNiceString());
            
            //var convert = JsonConvert.SerializeObject(race, new JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //});
            //Instance.Logger.LogInfo($"{convert}");
        }
        */
    }

    [HarmonyPatch(typeof(RacesMenu), nameof(RacesMenu.SetUpSlot))]
    [HarmonyPrefix]
    private static bool HookSetUpSlot(RacesMenu __instance, RacesMenuSlot slot, RaceModel race, int index)
    {
        bool canBePicked = __instance.CanBePicked(race);
        var allowedRaces = __instance.allowedRaces;
        bool getProfessionAmount = GameMB.VillagersService.GetDefaultProfessionAmount(race.Name) > 0;
        Log.LogError($"RACES: SetUpSlots {race}, CanBePicked: {canBePicked}, getProfessionAmount: {getProfessionAmount}");
        foreach (var allowedRace in allowedRaces)
        {
            Log.LogWarning($"    Allowed Race: {allowedRace}");
        }
        return true;
    }

    [HarmonyPatch(typeof(GameController), nameof(GameController.StartGame))]
    [HarmonyPostfix]
    private static void HookEveryGameStart()
    {
        // Too difficult to predict when GameController will exist and I can hook observers to it
        // So just use Harmony and save us all some time. This method will run after every game start
        var isNewGame = MB.GameSaveService.IsNewGame();
        Instance.Logger.LogInfo($"Entered a game. Is this a new game: {isNewGame}.");
        // TextMeshProManager.Instantiate();
        
    }
    
    [HarmonyPatch(typeof(CustomGameRacesPanel), nameof(CustomGameRacesPanel.SetUpSlots))]
    [HarmonyPrefix]
    private static bool HookEveryGameStart(CustomGameRacesPanel __instance)
    {
        /*
        SO.MetaStateService.Content.races.Add(_newRace.raceModel.Name);
        var service = SO.MetaConditionsService;
        foreach (RaceModel race in MB.Settings.Races)
        {
            bool isEssential = service.IsEssential(race.Name);
            bool isInContent = Serviceable.MetaStateService.Content.races.Contains(race.Name);
            Instance.Logger.LogError($"RACE: {race}, is unlocked: {MB.MetaConditionsService.IsUnlocked(race)}: {isEssential} or {isInContent}");
        }
        */
        return true;
    }
}