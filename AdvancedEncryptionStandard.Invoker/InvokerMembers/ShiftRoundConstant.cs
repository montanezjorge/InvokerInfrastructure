namespace AdvancedEncryptionStandard.Invoker.InvokerMembers
{
    using global::Invoker.Infrastructure;
    using System.Threading.Tasks;

    public class ShiftRoundConstant : InvokerMemberBase<CryptoOperationDto, CryptoOperationDto>
    {
        protected override async Task<CryptoOperationDto> Invoke(CryptoOperationDto param)
        {
            if (param.KeyScheduleIndex % 36 == 0)
            {
                param.RoundConstant = 0x01B;
            }

            param.KeySchedule[param.KeyScheduleIndex, 0] ^= param.RoundConstant;
            param.RoundConstant <<= 1;

            return param;
        }
    }
}
