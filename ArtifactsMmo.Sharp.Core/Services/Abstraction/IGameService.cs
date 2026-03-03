using ArtifactsMmo.Sharp.Generated;

namespace ArtifactsMmo.Sharp.Core.Services.Abstraction;

public interface IGameService
{
    Task<ICollection<CharacterSchema>> GetMyCharactersAsync(CancellationToken cancellationToken = default);
    Task<StatusResponseSchema> GetServerStatusAsync(CancellationToken cancellationToken = default);

    // Items
    Task<StaticDataPage_ItemSchema_> GetItemsAsync(string? name = null, int? minLevel = null, int? maxLevel = null, ItemType? type = null, CraftSkill? craftSkill = null, string? craftMaterial = null, int? page = null, int? size = null, CancellationToken cancellationToken = default);
    Task<ItemResponseSchema> GetItemAsync(string code, CancellationToken cancellationToken = default);

    // Monsters
    Task<StaticDataPage_MonsterSchema_> GetMonstersAsync(string? name = null, int? minLevel = null, int? maxLevel = null, string? drop = null, int? page = null, int? size = null, CancellationToken cancellationToken = default);
    Task<MonsterResponseSchema> GetMonsterAsync(string code, CancellationToken cancellationToken = default);

    // Resources
    Task<StaticDataPage_ResourceSchema_> GetResourcesAsync(int? minLevel = null, int? maxLevel = null, GatheringSkill? skill = null, string? drop = null, int? page = null, int? size = null, CancellationToken cancellationToken = default);
    Task<ResourceResponseSchema> GetResourceAsync(string code, CancellationToken cancellationToken = default);

    // Maps
    Task<StaticDataPage_MapSchema_> GetMapsAsync(MapLayer? layer = null, MapContentType? contentType = null, string? contentCode = null, bool? hideBlockedMaps = null, int? page = null, int? size = null, CancellationToken cancellationToken = default);
    Task<MapResponseSchema> GetMapAsync(MapLayer layer, int x, int y, CancellationToken cancellationToken = default);

    // Events
    Task<StaticDataPage_ActiveEventSchema_> GetActiveEventsAsync(int? page = null, int? size = null, CancellationToken cancellationToken = default);
    Task<StaticDataPage_EventSchema_> GetAllEventsAsync(MapContentType? type = null, int? page = null, int? size = null, CancellationToken cancellationToken = default);

    // Grand Exchange
    Task<DataPage_GEOrderSchema_> GetGeOrdersAsync(string? code = null, string? account = null, GEOrderType? type = null, int? page = null, int? size = null, CancellationToken cancellationToken = default);
    Task<GEOrderResponseSchema> GetGeOrderAsync(string id, CancellationToken cancellationToken = default);
    Task<DataPage_GeOrderHistorySchema_> GetGeHistoryAsync(string code, string? account = null, int? page = null, int? size = null, CancellationToken cancellationToken = default);

    // Tasks
    Task<StaticDataPage_TaskFullSchema_> GetTasksAsync(int? minLevel = null, int? maxLevel = null, Skill? skill = null, TaskType? type = null, int? page = null, int? size = null, CancellationToken cancellationToken = default);
    Task<TaskFullResponseSchema> GetTaskAsync(string code, CancellationToken cancellationToken = default);
    Task<StaticDataPage_DropRateSchema_> GetTaskRewardsAsync(int? page = null, int? size = null, CancellationToken cancellationToken = default);
    Task<RewardResponseSchema> GetTaskRewardAsync(string code, CancellationToken cancellationToken = default);

    // NPCs
    Task<StaticDataPage_NPCSchema_> GetNpcsAsync(string? name = null, NPCType? type = null, int? page = null, int? size = null, CancellationToken cancellationToken = default);
    Task<NPCResponseSchema> GetNpcAsync(string code, CancellationToken cancellationToken = default);

    // Effects
    Task<StaticDataPage_EffectSchema_> GetEffectsAsync(int? page = null, int? size = null, CancellationToken cancellationToken = default);
    Task<EffectResponseSchema> GetEffectAsync(string code, CancellationToken cancellationToken = default);

    // Achievements & Badges
    Task<StaticDataPage_AchievementSchema_> GetAchievementsAsync(AchievementType? type = null, int? page = null, int? size = null, CancellationToken cancellationToken = default);
    Task<AchievementResponseSchema> GetAchievementAsync(string code, CancellationToken cancellationToken = default);
    Task<StaticDataPage_BadgeSchema_> GetBadgesAsync(int? page = null, int? size = null, CancellationToken cancellationToken = default);
    Task<BadgeResponseSchema> GetBadgeAsync(string code, CancellationToken cancellationToken = default);

    // Leaderboard
    Task<DataPage_CharacterLeaderboardSchema_> GetCharactersLeaderboardAsync(CharacterLeaderboardType? sort = null, string? name = null, int? page = null, int? size = null, CancellationToken cancellationToken = default);
    Task<DataPage_AccountLeaderboardSchema_> GetAccountsLeaderboardAsync(AccountLeaderboardType? sort = null, string? name = null, int? page = null, int? size = null, CancellationToken cancellationToken = default);
}
