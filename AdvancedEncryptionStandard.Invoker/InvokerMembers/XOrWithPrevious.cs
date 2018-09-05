namespace AdvancedEncryptionStandard.Invoker.InvokerMembers
{
    using global::Invoker.Infrastructure;
    using System.Threading.Tasks;

    public class XOrWithPrevious : InvokerMemberBase<CryptoOperationDto, CryptoOperationDto>
    {
        protected override async Task<CryptoOperationDto> Invoke(CryptoOperationDto param)
        {
            param.KeySchedule[param.KeyScheduleIndex, 0] ^= param.KeySchedule[param.KeyScheduleIndex - param.KeyWords, 0];
            param.KeySchedule[param.KeyScheduleIndex, 1] ^= param.KeySchedule[param.KeyScheduleIndex - param.KeyWords, 1];
            param.KeySchedule[param.KeyScheduleIndex, 2] ^= param.KeySchedule[param.KeyScheduleIndex - param.KeyWords, 2];
            param.KeySchedule[param.KeyScheduleIndex, 3] ^= param.KeySchedule[param.KeyScheduleIndex - param.KeyWords, 3];

            param.KeyScheduleIndex++;

            return param;
        }
    }
}
