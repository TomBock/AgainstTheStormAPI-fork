using System.Collections.Generic;
using System.Linq;
using ATS_API.Biomes;
using ATS_API.Effects;
using ATS_API.Goods;
using ATS_API.Helpers;
using ATS_API.Localization;
using ATS_API.Orders;
using ATS_API.Scripts.Needs;
using ATS_API.Scripts.Races;
using ATS_API.Traders;
using BepInEx;
using BepInEx.Logging;
using Eremite;
using Eremite.Buildings;
using Eremite.Buildings.UI;
using Eremite.Characters.Villagers;
using Eremite.Controller;
using Eremite.Controller.Generator;
using Eremite.Model;
using Eremite.Model.Needs;
using Eremite.Services;
using Eremite.View.HUD;
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
        //NewNeed clay = new NeedsBuilder(PluginInfo.PLUGIN_GUID, "Clay").
        //           SetGoodPresentation(
        //               GoodsTypes.Clay.ToName().ToGoodsModel(),
        //               "Shardlings thrive on Clay".ToLocaText()).
        //           SetCategory(NeedCategoryTypes.Food_Need_Category.ToName().ToNeedCategoryModel()).
        //           SetEffect(ResolveEffectTypes.Motivated.ToResolveEffectModel());
        
        var shardlings = new RaceBuilder(PluginInfo.PLUGIN_GUID, "Shardling", "Shardling")
            .CopyPrefabs(RaceTypes.Foxes.ToRaceModel())
            .CopySounds(RaceTypes.Foxes.ToRaceModel())
            .CopyAssignAction(RaceTypes.Foxes.ToRaceModel())
            .SetDisplayName("Shardling")
            .SetPluralName("Shardlings")
            .SetShortDescription("Shardlings are steadfast and enduring, excelling in mining and metallurgy.")
            .SetDescription($"Shardlings are steadfast and enduring, excelling in mining (<sprite name=\"mining\">) and metallurgy (<sprite name=\"metallurgy\">). They thrive in rocky environments and are extremely resilient. While their stone-like bodies make them very slow, they have a unique affinity for storms, drawing energy from the chaotic weather.")
            .SetOrder(4)
            .SetMaleNames(new [] {"Fuchsite Shardglow", "Serpentine Rockward", "Flint Gemheart", "Grossular Gembright", "Epidote Stonewrath", "Aragonite Gemshield", "Crystal Riftwalker", "Garnet Stoneweaver", "Cobalt Shardveil", "Andalusite Shardwielder", "Azurite Stoneflare", "Granite Gemforge", "Quartz Veinbinder", "Zeolite Rockseer", "Jasper Cragspark", "Beryl Stonecarve", "Bronzite Gemhammer", "Topaz Rockgleam", "Peridot Gemshaper", "Dumortierite Stonecaller", "Ammonite Gemglow", "Rhodonite Veincrush", "Selenite Stonebringer", "Rhyolite Gemstone", "Tantalite Stoneguardian", "Obsidian Shardspire", "Variscite Gemhold", "Hematite Shardclash", "Ulexite Shardstorm", "Carnelian Rockguard", "Smithsonite Gemstrike", "Lazurite Gemkeeper", "Tektite Rockbreaker", "Orthoclase Stonebender", "Morganite Rockshaper", "Galena Shardblight", "Wulfenite Stonecaster", "Stibnite Stoneblaze", "Onyx Shardflare", "Malachite Shardstrike", "Pyrite Veinstone", "Basalt Stonefist", "Yttrium Gemspire", "Petalite Shardfire", "Kyanite Shardforge", "Hypersthene Rockwhisper", "Xenotime Shardlash", "Chalcedony Rockcrusher", "Labradorite Gemflame", "Aventurine Stonewrath"})
            .SetFemaleNames(new [] {"Tourmalina Veinshaper", "Xyla Gemglint", "Pyra Gemstrike", "Tanza Gemflare", "Lepida Rockbender", "Halina Shardgleam", "Zeola Shardwhisper", "Turquina Stonegleam", "Coralia Shardlight", "Nephra Shardcaster", "Zira Stoneglow", "Diamanda Shardglow", "Citrina Gemshine", "Epi Gemshaper", "Azura Gemflow", "Micara Shardveil", "Yara Stonebloom", "Rosalia Stonebloom", "Opal Rockwarda", "Una Shardbringer", "Flora Gemcaster", "Dola Shardwave", "Blooda Shardshade", "Morgana Gemwarden", "Aqua Gemflow", "Seraphina Shardflame", "Ambra Rockbreaker", "Quartzy Stonebearer", "Rubina Stoneglint", "Smokya Stonebearer", "Celestia Rockguardian", "Obsidia Stoneglow", "Wulfa Shardflame", "Lapis Shardbrighte", "Jetta Gemflare", "Agata Stonecaller", "Chrysa Rockseer", "Amethysa Shardshield", "Rhoda Shardveil", "Dana Shardstrike", "Iola Stonebringer", "Eudalia Stoneweaver", "SmokOpal Rockwarda", "Esmeralda Shardgleam", "Jada Stonebearer", "Kuni Shardlight", "Sapphira Veinscribe", "Garneta Rockblaze", "Moona Gemshade", "Vesuvi Rockgleam", "Rhodona Stoneglimmer", "Aventina Gemwhisper"})
            .SetBaseSpeed(1.4f)
            .SetInitialResolve(15)
            .SetMinResolve(0)
            .SetMaxResolve(50)
            .SetResolvePositiveChangePerSec(0.1f)
            .SetResolveNegativeChangePerSec(0.1f)
            .SetResolveNegativeChangeDiffFactor(0.1f)
            .SetReputationPerSec(0.0005f)
            .SetMinPopulationToGainReputation(1)
            .SetResolveForReputationThreshold(new Vector2(30f, 50f))
            .SetMaxReputationFromResolvePerSec(10f)
            .SetReputationThresholdIncreasePerReputation(10f)
            .SetResolveToReputationRatio(0.1f)
            .SetPopulationToReputationRatio(0.7f)
            .SetResilienceLabel("Very High".ToLocaText())
            .SetNeeds(
                NeedTypes.Any_Housing.ToName().ToNeedModel(),
                NeedTypes.Fox_Housing.ToName().ToNeedModel(),
                NeedTypes.Porridge.ToName().ToNeedModel(), 
                NeedTypes.Treatment.ToName().ToNeedModel()/*,
                clay.model*/)
            .SetRacialHousingNeed(NeedTypes.Fox_Housing)
            .SetNeedsInterval(240f)
            .SetHungerTolerance(15)
            .SetHungerEffect(ResolveEffectTypes.Hunger_Penalty)
            .SetCharacteristics(new RaceCharacteristicModel[]
            {
                new RaceCharacteristicBuilder(BuildingTagTypes.Tech)
                    .SetEffect(VillagerPerkTypes.Proficiency),
                new RaceCharacteristicBuilder(BuildingTagTypes.Rainwater)
                    .SetEffect(VillagerPerkTypes.Comfortable_Job)
                //todo add shardling_hearth effect
            })
            .SetDeathEffect(EffectTypes.Villager_Death_Reputation_Penalty);
        
        var scarabs = new RaceBuilder(PluginInfo.PLUGIN_GUID, "Scarab", "Scarab")
            .CopyPrefabs(RaceTypes.Lizard.ToRaceModel())
            .CopySounds(RaceTypes.Lizard.ToRaceModel())
            .CopyAssignAction(RaceTypes.Lizard.ToRaceModel())
            .SetDisplayName("Scarab")
            .SetPluralName("Scarabs")
            .SetShortDescription("Scarabs are strong race, using its strength to collect resources and survive. They are proud of their work and tenacity.")
            .SetDescription($"Scarabs are very strong creatures. They excel at working on buildings that produce clay, stone and metal. Their affinity to the farmlands allow them to feel comfortable when working on buildings that are built on fertile soil such as farms.")
            .SetOrder(4)
            .SetMaleNames(new [] {"Scarabos Elytron", "Chitron Carapace", "Beetlor Mandible", "Mandrix Antenna", "Thoraxius Elytra", "Antarion Segmin", "Krito Thoraxis", "Carabus Scarabaeus", "Lucano Cervus", "Dynastes Titanus", "Sphero Tarsalis", "Melolonth Vespidae", "Tarsus Chitin", "Coleon Verduro", "Tenebrix Fovea"})
            .SetFemaleNames(new [] {"Scarabella Elytra", "Chrysia Mandibella", "Beetlia Antenna", "Mandra Carapacea", "Thoraxa Elytrina", "Antaria Segmina", "Kritona Thoracina", "Carabella Scarabina", "Lucina Cervina", "Dynastia Titanessa", "Spherina Tarsalia", "Melora Vespa", "Tarsina Chitina", "Colea Verda", "Tenebria Foveata"})
            .SetBaseSpeed(1.8f)
            .SetInitialResolve(12)
            .SetMinResolve(0)
            .SetMaxResolve(75)
            .SetResolvePositiveChangePerSec(0.18f)
            .SetResolveNegativeChangePerSec(0.06f)
            .SetResolveNegativeChangeDiffFactor(0.1f)
            .SetReputationPerSec(0.00025f)
            .SetMinPopulationToGainReputation(1)
            .SetResolveForReputationThreshold(new Vector2(20f, 75f))
            .SetMaxReputationFromResolvePerSec(25f)
            .SetReputationThresholdIncreasePerReputation(9f)
            .SetResolveToReputationRatio(0.1f)
            .SetPopulationToReputationRatio(0.7f)
            .SetResilienceLabel("Very High".ToLocaText())
            .SetNeeds(
                NeedTypes.Any_Housing.ToName().ToNeedModel(),
                NeedTypes.Lizard_Housing.ToName().ToNeedModel(),
                NeedTypes.Porridge.ToName().ToNeedModel(), 
                NeedTypes.Biscuits.ToName().ToNeedModel(), 
                NeedTypes.Pickled_Goods.ToName().ToNeedModel(), 
                NeedTypes.Leasiure.ToName().ToNeedModel(), 
                NeedTypes.Treatment.ToName().ToNeedModel(), 
                NeedTypes.Luxury.ToName().ToNeedModel()/*,
                clay.model*/)
            .SetRacialHousingNeed(NeedTypes.Lizard_Housing)
            .SetNeedsInterval(160f)
            .SetHungerTolerance(8)
            .SetHungerEffect(ResolveEffectTypes.Hunger_Penalty)
            .SetHostilityPenalty(ResolveEffectTypes.New_Year_Penalty)
            .SetCharacteristics(new RaceCharacteristicModel[]
            {
                new RaceCharacteristicBuilder(BuildingTagTypes.Wood)
                    .SetEffect(VillagerPerkTypes.Proficiency),
                new RaceCharacteristicBuilder(BuildingTagTypes.Farming)
                    .SetEffect(VillagerPerkTypes.Comfortable_Job)
                //todo add scarab_hearth effect
            })
            .SetDeathEffect(EffectTypes.Villager_Death_Reputation_Penalty);
            //tood add 1 free small cache break
    }

    private void LateUpdate()
    {
        GoodsManager.Tick();
        EffectManager.Tick();
        TraderManager.Tick();
        OrdersManager.Tick();
        BiomeManager.Tick();
        TextMeshProManager.Tick();
        NeedsManager.Tick();
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
        NeedsManager.Instantiate();
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

    [HarmonyPatch(typeof(VillagersService), nameof(VillagersService.SpawnVillagerAt))]
    [HarmonyPostfix]
    private static void SpawnVillagerAt(Villager __result)
    {
        ColorCustomRaces(__result);
    }

    [HarmonyPatch(typeof(GameLoader), nameof(GameLoader.CreateVillager))]
    [HarmonyPrefix]
    private static bool CreateVillager(VillagerState state)
    {
        var villager = UnityEngine.Object.Instantiate<Villager>(MB.Settings.GetRace(state.race).GetPrefabFor(state.isMale));
        villager.Restore(state);
        ColorCustomRaces(villager);
        return false;
    }

    private static void ColorCustomRaces(Villager villager)
    {
        Log.LogWarning($"SpawnVillagerAt for Villager {villager}");
        if (RaceManager.NewRaces.Any(newRace => newRace.model == villager.raceModel))
        {
            Log.LogWarning($"Villager has custom race {villager.raceModel}");
            var sphere = GameObject.CreatePrimitive(villager.raceModel.name.Contains("Scarab") ? PrimitiveType.Sphere : PrimitiveType.Cube);
            sphere.name = "[MOD] Custom Race Visual";
            sphere.transform.SetParent(villager.transform);
            sphere.transform.localPosition = new Vector3(0f, 1.5f, 0f);
            sphere.transform.localRotation = Quaternion.identity;
            sphere.transform.localScale = Vector3.one * 0.25f;
        }
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
}