using ArtifactsMmo.Sharp.Generated;

namespace ArtifactsMmo.Sharp.Services.Abstraction;

public interface ICharacterService
{
    // Core actions
    Task<SkillDataSchema> GatherAsync(string name, CancellationToken cancellationToken = default);
    Task<SkillDataSchema> CraftAsync(string name, string code, int quantity, CancellationToken cancellationToken = default);
    Task<CharacterMovementDataSchema> MoveAsync(string name, int x, int y, CancellationToken cancellationToken = default);
    Task<CharacterFightDataSchema> FightAsync(string name, CancellationToken cancellationToken = default);
    Task<CharacterRestDataSchema> RestAsync(string name, CancellationToken cancellationToken = default);
    Task<RecyclingDataSchema> RecycleAsync(string name, string code, int quantity, CancellationToken cancellationToken = default);
    Task UseItemAsync(string name, string code, CancellationToken cancellationToken = default);

    // Equipment
    Task EquipAsync(string name, string code, ItemSlot slot, CancellationToken cancellationToken = default);
    Task UnequipAsync(string name, ItemSlot slot, CancellationToken cancellationToken = default);
    Task ChangeSkinAsync(string name, CharacterSkin skin, CancellationToken cancellationToken = default);
    Task TransitionAsync(string name, CancellationToken cancellationToken = default);

    // Bank
    Task DepositItemAsync(string name, string code, int quantity, CancellationToken cancellationToken = default);
    Task DepositGoldAsync(string name, int quantity, CancellationToken cancellationToken = default);
    Task WithdrawItemAsync(string name, string code, int quantity, CancellationToken cancellationToken = default);
    Task WithdrawGoldAsync(string name, int quantity, CancellationToken cancellationToken = default);
    Task BuyBankExpansionAsync(string name, CancellationToken cancellationToken = default);

    // Grand Exchange
    Task GeBuyAsync(string name, string orderId, int quantity, CancellationToken cancellationToken = default);
    Task GeCreateSellOrderAsync(string name, string code, int quantity, int price, CancellationToken cancellationToken = default);
    Task GeCreateBuyOrderAsync(string name, string code, int quantity, int price, CancellationToken cancellationToken = default);
    Task GeCancelOrderAsync(string name, string orderId, CancellationToken cancellationToken = default);
    Task GeFillOrderAsync(string name, string orderId, int quantity, CancellationToken cancellationToken = default);

    // NPC
    Task NpcBuyAsync(string name, string code, int quantity, CancellationToken cancellationToken = default);
    Task NpcSellAsync(string name, string code, int quantity, CancellationToken cancellationToken = default);

    // Tasks
    Task AcceptTaskAsync(string name, CancellationToken cancellationToken = default);
    Task CompleteTaskAsync(string name, CancellationToken cancellationToken = default);
    Task TaskExchangeAsync(string name, CancellationToken cancellationToken = default);
    Task TaskTradeAsync(string name, string code, int quantity, CancellationToken cancellationToken = default);
    Task TaskCancelAsync(string name, CancellationToken cancellationToken = default);

    // Items
    Task DeleteItemAsync(string name, string code, int quantity, CancellationToken cancellationToken = default);
    Task GiveGoldAsync(string name, int quantity, string targetCharacter, CancellationToken cancellationToken = default);
    Task GiveItemAsync(string name, string code, int quantity, string targetCharacter, CancellationToken cancellationToken = default);
    Task ClaimItemAsync(string name, string id, CancellationToken cancellationToken = default);
}
