using ArtifactsMmo.Sharp.Generated;
using ArtifactsMmo.Sharp.Core.Services.Abstraction;
using Microsoft.Extensions.Logging;

namespace ArtifactsMmo.Sharp.Core.Services;

public class GameService(IArtifactsClient client, ILogger<GameService> logger) : IGameService
{
    public async Task<ICollection<CharacterSchema>> GetMyCharactersAsync(CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Getting my characters");
        var response = await client.Get_my_characters_my_characters_getAsync(cancellationToken);
        return response.Data;
    }

    public async Task<StatusResponseSchema> GetServerStatusAsync(CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Getting server status");
        return await client.Get_server_details__getAsync(cancellationToken);
    }

    public async Task<StaticDataPage_ItemSchema_> GetItemsAsync(string? name = null, int? minLevel = null, int? maxLevel = null, ItemType? type = null, CraftSkill? craftSkill = null, string? craftMaterial = null, int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_all_items_items_getAsync(name, minLevel, maxLevel, type, craftSkill, craftMaterial, page, size, cancellationToken);
    }

    public async Task<ItemResponseSchema> GetItemAsync(string code, CancellationToken cancellationToken = default)
    {
        return await client.Get_item_items__code__getAsync(code, cancellationToken);
    }

    public async Task<StaticDataPage_MonsterSchema_> GetMonstersAsync(string? name = null, int? minLevel = null, int? maxLevel = null, string? drop = null, int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_all_monsters_monsters_getAsync(name, minLevel, maxLevel, drop, page, size, cancellationToken);
    }

    public async Task<MonsterResponseSchema> GetMonsterAsync(string code, CancellationToken cancellationToken = default)
    {
        return await client.Get_monster_monsters__code__getAsync(code, cancellationToken);
    }

    public async Task<StaticDataPage_ResourceSchema_> GetResourcesAsync(int? minLevel = null, int? maxLevel = null, GatheringSkill? skill = null, string? drop = null, int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_all_resources_resources_getAsync(minLevel, maxLevel, skill, drop, page, size, cancellationToken);
    }

    public async Task<ResourceResponseSchema> GetResourceAsync(string code, CancellationToken cancellationToken = default)
    {
        return await client.Get_resource_resources__code__getAsync(code, cancellationToken);
    }

    public async Task<StaticDataPage_MapSchema_> GetMapsAsync(MapLayer? layer = null, MapContentType? contentType = null, string? contentCode = null, bool? hideBlockedMaps = null, int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_all_maps_maps_getAsync(layer, contentType, contentCode, hideBlockedMaps, page, size, cancellationToken);
    }

    public async Task<MapResponseSchema> GetMapAsync(MapLayer layer, int x, int y, CancellationToken cancellationToken = default)
    {
        return await client.Get_map_by_position_maps__layer___x___y__getAsync(layer, x, y, cancellationToken);
    }

    public async Task<StaticDataPage_ActiveEventSchema_> GetActiveEventsAsync(int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_all_active_events_events_active_getAsync(page, size, cancellationToken);
    }

    public async Task<StaticDataPage_EventSchema_> GetAllEventsAsync(MapContentType? type = null, int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_all_events_events_getAsync(type, page, size, cancellationToken);
    }

    public async Task<DataPage_GEOrderSchema_> GetGeOrdersAsync(string? code = null, string? account = null, GEOrderType? type = null, int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_ge_orders_grandexchange_orders_getAsync(code, account, type, page, size, cancellationToken);
    }

    public async Task<GEOrderResponseSchema> GetGeOrderAsync(string id, CancellationToken cancellationToken = default)
    {
        return await client.Get_ge_order_grandexchange_orders__id__getAsync(id, cancellationToken);
    }

    public async Task<DataPage_GeOrderHistorySchema_> GetGeHistoryAsync(string code, string? account = null, int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_ge_history_grandexchange_history__code__getAsync(code, account, page, size, cancellationToken);
    }

    public async Task<StaticDataPage_TaskFullSchema_> GetTasksAsync(int? minLevel = null, int? maxLevel = null, Skill? skill = null, TaskType? type = null, int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_all_tasks_tasks_list_getAsync(minLevel, maxLevel, skill, type, page, size, cancellationToken);
    }

    public async Task<TaskFullResponseSchema> GetTaskAsync(string code, CancellationToken cancellationToken = default)
    {
        return await client.Get_task_tasks_list__code__getAsync(code, cancellationToken);
    }

    public async Task<StaticDataPage_DropRateSchema_> GetTaskRewardsAsync(int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_all_tasks_rewards_tasks_rewards_getAsync(page, size, cancellationToken);
    }

    public async Task<RewardResponseSchema> GetTaskRewardAsync(string code, CancellationToken cancellationToken = default)
    {
        return await client.Get_tasks_reward_tasks_rewards__code__getAsync(code, cancellationToken);
    }

    public async Task<StaticDataPage_NPCSchema_> GetNpcsAsync(string? name = null, NPCType? type = null, int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_all_npcs_npcs_details_getAsync(name, type, page, size, cancellationToken);
    }

    public async Task<NPCResponseSchema> GetNpcAsync(string code, CancellationToken cancellationToken = default)
    {
        return await client.Get_npc_npcs_details__code__getAsync(code, cancellationToken);
    }

    public async Task<StaticDataPage_EffectSchema_> GetEffectsAsync(int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_all_effects_effects_getAsync(page, size, cancellationToken);
    }

    public async Task<EffectResponseSchema> GetEffectAsync(string code, CancellationToken cancellationToken = default)
    {
        return await client.Get_effect_effects__code__getAsync(code, cancellationToken);
    }

    public async Task<StaticDataPage_AchievementSchema_> GetAchievementsAsync(AchievementType? type = null, int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_all_achievements_achievements_getAsync(type, page, size, cancellationToken);
    }

    public async Task<AchievementResponseSchema> GetAchievementAsync(string code, CancellationToken cancellationToken = default)
    {
        return await client.Get_achievement_achievements__code__getAsync(code, cancellationToken);
    }

    public async Task<StaticDataPage_BadgeSchema_> GetBadgesAsync(int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_all_badges_badges_getAsync(page, size, cancellationToken);
    }

    public async Task<BadgeResponseSchema> GetBadgeAsync(string code, CancellationToken cancellationToken = default)
    {
        return await client.Get_badge_badges__code__getAsync(code, cancellationToken);
    }

    public async Task<DataPage_CharacterLeaderboardSchema_> GetCharactersLeaderboardAsync(CharacterLeaderboardType? sort = null, string? name = null, int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_characters_leaderboard_leaderboard_characters_getAsync(sort, name, page, size, cancellationToken);
    }

    public async Task<DataPage_AccountLeaderboardSchema_> GetAccountsLeaderboardAsync(AccountLeaderboardType? sort = null, string? name = null, int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_accounts_leaderboard_leaderboard_accounts_getAsync(sort, name, page, size, cancellationToken);
    }
}
