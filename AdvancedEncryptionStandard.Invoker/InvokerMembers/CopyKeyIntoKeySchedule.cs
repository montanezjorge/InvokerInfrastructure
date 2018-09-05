namespace AdvancedEncryptionStandard.Invoker.InvokerMembers
{
    using global::Invoker.Infrastructure;
    using System.Threading.Tasks;

    public class CopyKeyIntoKeySchedule : InvokerMemberBase<CryptoOperationDto, CryptoOperationDto>
    {
        protected override async Task<CryptoOperationDto> Invoke(CryptoOperationDto param)
        {
            param.RoundConstant = 0x01;
            param.KeySchedule = new byte[60, 4];

            for (var j = 0; j * 4 < param.Key.Length; j++)
            {
                for (var k = 0; k < 4; k++)
                {
                    param.KeySchedule[j, k] = param.Key[j * 4 + k];
                }
            }

            return param;
        }
    }
}
