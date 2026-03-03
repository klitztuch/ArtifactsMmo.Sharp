using ArtifactsMmo.Sharp.Generated;
using ArtifactsMmo.Sharp.Services.Abstraction;

namespace ArtifactsMmo.Sharp.Services;

public class AccountService(IArtifactsClient client, ILogger<AccountService> logger) : IAccountService
{
    public async Task<MyAccountDetailsSchema> GetMyDetailsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Getting account details");
        return await client.Get_account_details_my_details_getAsync(cancellationToken);
    }

    public async Task<BankResponseSchema> GetBankAsync(CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Getting bank details");
        return await client.Get_bank_details_my_bank_getAsync(cancellationToken);
    }

    public async Task<DataPage_SimpleItemSchema_> GetBankItemsAsync(string? itemCode = null, int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_bank_items_my_bank_items_getAsync(itemCode, page, size, cancellationToken);
    }

    public async Task<DataPage_LogSchema_> GetLogsAsync(int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_all_characters_logs_my_logs_getAsync(page, size, cancellationToken);
    }

    public async Task<DataPage_LogSchema_> GetCharacterLogsAsync(string name, int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_character_logs_my_logs__name__getAsync(name, page, size, cancellationToken);
    }

    public async Task<DataPage_GEOrderSchema_> GetMyGeOrdersAsync(string? code = null, GEOrderType? type = null, int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_ge_orders_my_grandexchange_orders_getAsync(code, type, page, size, cancellationToken);
    }

    public async Task<DataPage_GeOrderHistorySchema_> GetMyGeHistoryAsync(string? id = null, string? code = null, int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_ge_history_my_grandexchange_history_getAsync(id, code, page, size, cancellationToken);
    }

    public async Task<DataPage_PendingItemSchema_> GetPendingItemsAsync(int? page = null, int? size = null, CancellationToken cancellationToken = default)
    {
        return await client.Get_pending_items_my_pending_items_getAsync(page, size, cancellationToken);
    }

    public async Task ChangePasswordAsync(string currentPassword, string newPassword, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Changing password");
        await client.Change_password_my_change_password_postAsync(
            new ChangePassword { Current_password = currentPassword, New_password = newPassword },
            cancellationToken);
    }

    public async Task<CharacterSchema> CreateCharacterAsync(string name, CharacterSkin skin, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Creating character {name}", name);
        var response = await client.Create_character_characters_create_postAsync(
            new AddCharacterSchema { Name = name, Skin = skin },
            cancellationToken);
        return response.Data;
    }

    public async Task<CharacterSchema> DeleteCharacterAsync(string name, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Deleting character {name}", name);
        var response = await client.Delete_character_characters_delete_postAsync(
            new DeleteCharacterSchema { Name = name },
            cancellationToken);
        return response.Data;
    }
}
