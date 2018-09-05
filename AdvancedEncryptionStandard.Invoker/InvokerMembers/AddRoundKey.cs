namespace AdvancedEncryptionStandard.Invoker.InvokerMembers
{
    using global::Invoker.Infrastructure;
    using System.Threading.Tasks;

    public class AddRoundKey : InvokerMemberBase<CryptoOperationDto, CryptoOperationDto>
    {
        protected override async Task<CryptoOperationDto> Invoke(CryptoOperationDto param)
        {
            for (var c = 0; c < 4; c++)
            {
                for (var r = 0; r < 4; r++)
                {
                    param.State[r, c] = (byte)(param.State[r, c] ^ param.KeySchedule[c + param.AddRoundKeyIndex, r]);
                }
            }

            return param;
        }
    }
}
