namespace AdvancedEncryptionStandard.Invoker.InvokerMembers
{
    using global::Invoker.Infrastructure;
    using System.Threading.Tasks;

    public class SubBytes : InvokerMemberBase<CryptoOperationDto, CryptoOperationDto>
    {
        protected override async Task<CryptoOperationDto> Invoke(CryptoOperationDto param)
        {
            for (var r = 0; r < 4; r++)
            {
                for (var c = 0; c < 4; c++)
                {
                    param.State[r, c] = Constants.SBox[(param.State[r, c] & 0xF0) >> 4, param.State[r, c] & 0x0F];
                }
            }

            return param;
        }
    }
}
