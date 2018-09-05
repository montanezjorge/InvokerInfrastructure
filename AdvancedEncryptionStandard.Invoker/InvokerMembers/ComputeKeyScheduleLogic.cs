namespace AdvancedEncryptionStandard.Invoker.InvokerMembers
{
    using System;
    using System.Threading.Tasks;
    using global::Invoker.Infrastructure;

    public class ComputeKeyScheduleLogic : InvokerMemberBase<CryptoOperationDto, CryptoOperationDto>
    {
        protected override async Task<CryptoOperationDto> Invoke(CryptoOperationDto param)
        {
            Array.Copy(param.KeySchedule, (param.KeyScheduleIndex - 1) * 4, param.KeySchedule, param.KeyScheduleIndex * 4, 4);

            return param;
        }
    }
}
