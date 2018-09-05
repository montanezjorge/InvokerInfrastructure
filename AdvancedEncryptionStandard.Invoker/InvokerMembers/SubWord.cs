namespace AdvancedEncryptionStandard.Invoker.InvokerMembers
{
    using System.Threading.Tasks;
    using global::Invoker.Infrastructure;

    public class SubWord : InvokerMemberBase<CryptoOperationDto, CryptoOperationDto>
    {
        protected override async Task<CryptoOperationDto> Invoke(CryptoOperationDto param)
        {
            for (var i = 0; i < 4; i++)
            {
                param.KeySchedule[param.KeyScheduleIndex, i] = Constants.SBox[(param.KeySchedule[param.KeyScheduleIndex, i] & 0xF0) >> 4, param.KeySchedule[param.KeyScheduleIndex, i] & 0x0F];
            }

            return param;
        }
    }
}
