using ArtifactsMmo.Sharp.Generated;

namespace ArtifactsMmo.Sharp.Services.Abstraction;

public interface IAccountService
{
    Task<MyAccountDetailsSchema> GetMyDetailsAsync(CancellationToken cancellationToken = default);
    Task<BankResponseSchema> GetBankAsync(CancellationToken cancellationToken = default);
    Task<DataPage_SimpleItemSchema_> GetBankItemsAsync(string? itemCode = null, int? page = null, int? size = null, CancellationToken cancellationToken = default);
    Task<DataPage_LogSchema_> GetLogsAsync(int? page = null, int? size = null, CancellationToken cancellationToken = default);
    Task<DataPage_LogSchema_> GetCharacterLogsAsync(string name, int? page = null, int? size = null, CancellationToken cancellationToken = default);
    Task<DataPage_GEOrderSchema_> GetMyGeOrdersAsync(string? code = null, GEOrderType? type = null, int? page = null, int? size = null, CancellationToken cancellationToken = default);
    Task<DataPage_GeOrderHistorySchema_> GetMyGeHistoryAsync(string? id = null, string? code = null, int? page = null, int? size = null, CancellationToken cancellationToken = default);
    Task<DataPage_PendingItemSchema_> GetPendingItemsAsync(int? page = null, int? size = null, CancellationToken cancellationToken = default);
    Task ChangePasswordAsync(string currentPassword, string newPassword, CancellationToken cancellationToken = default);
    Task<CharacterSchema> CreateCharacterAsync(string name, CharacterSkin skin, CancellationToken cancellationToken = default);
    Task<CharacterSchema> DeleteCharacterAsync(string name, CancellationToken cancellationToken = default);
}
