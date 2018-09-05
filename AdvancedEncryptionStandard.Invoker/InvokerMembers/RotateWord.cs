namespace AdvancedEncryptionStandard.Invoker.InvokerMembers
{
    using global::Invoker.Infrastructure;
    using System.Threading.Tasks;

    public class RotateWord : InvokerMemberBase<CryptoOperationDto, CryptoOperationDto>
    {
        protected override async Task<CryptoOperationDto> Invoke(CryptoOperationDto param)
        {
            var tmp = param.KeySchedule[param.KeyScheduleIndex, 0];
            param.KeySchedule[param.KeyScheduleIndex, 0] = param.KeySchedule[param.KeyScheduleIndex, 1];
            param.KeySchedule[param.KeyScheduleIndex, 1] = param.KeySchedule[param.KeyScheduleIndex, 2];
            param.KeySchedule[param.KeyScheduleIndex, 2] = param.KeySchedule[param.KeyScheduleIndex, 3];
            param.KeySchedule[param.KeyScheduleIndex, 3] = tmp;

            return param;
        }
    }
}
