using ArtifactsMmo.Sharp.Generated;
using ArtifactsMmo.Sharp.Core.Services.Abstraction;
using Microsoft.Extensions.Logging;

namespace ArtifactsMmo.Sharp.Core.Services;

public class CharacterService(IArtifactsClient client, ILogger<CharacterService> logger) : ICharacterService
{
    private async Task WaitAsync(DateTimeOffset expiration, CancellationToken cancellationToken)
    {
        var delay = expiration - DateTimeOffset.UtcNow;
        if (delay <= TimeSpan.Zero) return;
        logger.LogInformation("Waiting {delay:g} until cooldown expires at {expiration}", delay, expiration);
        await Task.Delay(delay, cancellationToken);
    }

    public async Task<SkillDataSchema> GatherAsync(string name, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Gathering", name);
        var response = await client.Action_gathering_my__name__action_gathering_postAsync(name, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
        return response.Data;
    }

    public async Task<SkillDataSchema> CraftAsync(string name, string code, int quantity, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Crafting {code} x{quantity}", name, code, quantity);
        var response = await client.Action_crafting_my__name__action_crafting_postAsync(name,
            new CraftingSchema { Code = code, Quantity = quantity }, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
        return response.Data;
    }

    public async Task<CharacterMovementDataSchema> MoveAsync(string name, int x, int y, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Moving to ({x}, {y})", name, x, y);
        var response = await client.Action_move_my__name__action_move_postAsync(name,
            new DestinationSchema { X = x, Y = y }, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
        return response.Data;
    }

    public async Task<CharacterFightDataSchema> FightAsync(string name, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Fighting", name);
        var response = await client.Action_fight_my__name__action_fight_postAsync(name, null, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
        return response.Data;
    }

    public async Task<CharacterRestDataSchema> RestAsync(string name, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Resting", name);
        var response = await client.Action_rest_my__name__action_rest_postAsync(name, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
        return response.Data;
    }

    public async Task<RecyclingDataSchema> RecycleAsync(string name, string code, int quantity, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Recycling {code} x{quantity}", name, code, quantity);
        var response = await client.Action_recycling_my__name__action_recycling_postAsync(name,
            new RecyclingSchema { Code = code, Quantity = quantity }, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
        return response.Data;
    }

    public async Task UseItemAsync(string name, string code, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Using item {code}", name, code);
        var response = await client.Action_use_item_my__name__action_use_postAsync(name,
            new SimpleItemSchema { Code = code, Quantity = 1 }, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task EquipAsync(string name, string code, ItemSlot slot, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Equipping {code} in slot {slot}", name, code, slot);
        var response = await client.Action_equip_item_my__name__action_equip_postAsync(name,
            new EquipSchema { Code = code, Slot = slot }, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task UnequipAsync(string name, ItemSlot slot, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Unequipping slot {slot}", name, slot);
        var response = await client.Action_unequip_item_my__name__action_unequip_postAsync(name,
            new UnequipSchema { Slot = slot }, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task ChangeSkinAsync(string name, CharacterSkin skin, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Changing skin to {skin}", name, skin);
        var response = await client.Action_change_skin_my__name__action_change_skin_postAsync(name,
            new ChangeSkinCharacterSchema { Skin = skin }, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task TransitionAsync(string name, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Transitioning", name);
        var response = await client.Action_transition_my__name__action_transition_postAsync(name, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task DepositItemAsync(string name, string code, int quantity, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Depositing {code} x{quantity}", name, code, quantity);
        var response = await client.Action_deposit_bank_item_my__name__action_bank_deposit_item_postAsync(name,
            [new SimpleItemSchema { Code = code, Quantity = quantity }], cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task DepositGoldAsync(string name, int quantity, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Depositing {quantity} gold", name, quantity);
        var response = await client.Action_deposit_bank_gold_my__name__action_bank_deposit_gold_postAsync(name,
            new DepositWithdrawGoldSchema { Quantity = quantity }, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task WithdrawItemAsync(string name, string code, int quantity, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Withdrawing {code} x{quantity}", name, code, quantity);
        var response = await client.Action_withdraw_bank_item_my__name__action_bank_withdraw_item_postAsync(name,
            [new SimpleItemSchema { Code = code, Quantity = quantity }], cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task WithdrawGoldAsync(string name, int quantity, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Withdrawing {quantity} gold", name, quantity);
        var response = await client.Action_withdraw_bank_gold_my__name__action_bank_withdraw_gold_postAsync(name,
            new DepositWithdrawGoldSchema { Quantity = quantity }, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task BuyBankExpansionAsync(string name, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Buying bank expansion", name);
        var response = await client.Action_buy_bank_expansion_my__name__action_bank_buy_expansion_postAsync(name, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task GeBuyAsync(string name, string orderId, int quantity, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] GE buying order {orderId} x{quantity}", name, orderId, quantity);
        var response = await client.Action_ge_buy_item_my__name__action_grandexchange_buy_postAsync(name,
            new GEBuyOrderSchema { Id = orderId, Quantity = quantity }, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task GeCreateSellOrderAsync(string name, string code, int quantity, int price, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Creating GE sell order: {code} x{quantity} at {price}", name, code, quantity, price);
        var response = await client.Action_ge_create_sell_order_my__name__action_grandexchange_create_sell_order_postAsync(name,
            new GEOrderCreationrSchema { Code = code, Quantity = quantity, Price = price }, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task GeCreateBuyOrderAsync(string name, string code, int quantity, int price, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Creating GE buy order: {code} x{quantity} at {price}", name, code, quantity, price);
        var response = await client.Action_ge_create_buy_order_my__name__action_grandexchange_create_buy_order_postAsync(name,
            new GEBuyOrderCreationSchema { Code = code, Quantity = quantity, Price = price }, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task GeCancelOrderAsync(string name, string orderId, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Cancelling GE order {orderId}", name, orderId);
        var response = await client.Action_ge_cancel_order_my__name__action_grandexchange_cancel_postAsync(name,
            new GECancelOrderSchema { Id = orderId }, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task GeFillOrderAsync(string name, string orderId, int quantity, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Filling GE buy order {orderId} x{quantity}", name, orderId, quantity);
        var response = await client.Action_ge_fill_my__name__action_grandexchange_fill_postAsync(name,
            new GEFillBuyOrderSchema { Id = orderId, Quantity = quantity }, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task NpcBuyAsync(string name, string code, int quantity, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] NPC buying {code} x{quantity}", name, code, quantity);
        var response = await client.Action_npc_buy_item_my__name__action_npc_buy_postAsync(name,
            new NpcMerchantBuySchema { Code = code, Quantity = quantity }, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task NpcSellAsync(string name, string code, int quantity, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] NPC selling {code} x{quantity}", name, code, quantity);
        var response = await client.Action_npc_sell_item_my__name__action_npc_sell_postAsync(name,
            new NpcMerchantBuySchema { Code = code, Quantity = quantity }, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task AcceptTaskAsync(string name, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Accepting task", name);
        var response = await client.Action_accept_new_task_my__name__action_task_new_postAsync(name, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task CompleteTaskAsync(string name, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Completing task", name);
        var response = await client.Action_complete_task_my__name__action_task_complete_postAsync(name, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task TaskExchangeAsync(string name, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Exchanging task", name);
        var response = await client.Action_task_exchange_my__name__action_task_exchange_postAsync(name, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task TaskTradeAsync(string name, string code, int quantity, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Trading task item {code} x{quantity}", name, code, quantity);
        var response = await client.Action_task_trade_my__name__action_task_trade_postAsync(name,
            new SimpleItemSchema { Code = code, Quantity = quantity }, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task TaskCancelAsync(string name, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Cancelling task", name);
        var response = await client.Action_task_cancel_my__name__action_task_cancel_postAsync(name, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task DeleteItemAsync(string name, string code, int quantity, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Deleting {code} x{quantity}", name, code, quantity);
        var response = await client.Action_delete_item_my__name__action_delete_postAsync(name,
            new SimpleItemSchema { Code = code, Quantity = quantity }, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task GiveGoldAsync(string name, int quantity, string targetCharacter, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Giving {quantity} gold to {target}", name, quantity, targetCharacter);
        var response = await client.Action_give_gold_my__name__action_give_gold_postAsync(name,
            new GiveGoldSchema { Quantity = quantity, Character = targetCharacter }, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task GiveItemAsync(string name, string code, int quantity, string targetCharacter, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Giving {code} x{quantity} to {target}", name, code, quantity, targetCharacter);
        var response = await client.Action_give_items_my__name__action_give_item_postAsync(name,
            new GiveItemsSchema { Items = [new SimpleItemSchema { Code = code, Quantity = quantity }], Character = targetCharacter },
            cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }

    public async Task ClaimItemAsync(string name, string id, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{name}] Claiming pending item {id}", name, id);
        var response = await client.Action_claim_pending_item_my__name__action_claim_item__id__postAsync(name, id, cancellationToken);
        await WaitAsync(response.Data.Cooldown.Expiration, cancellationToken);
    }
}
