namespace AdvancedEncryptionStandard.Invoker.InvokerMembers
{
    using global::Invoker.Infrastructure;
    using System.Threading.Tasks;

    public class ComputeKeyScheduleConditional : InvokerRepeatingMemberBase<CryptoOperationDto>
    {
        protected override async Task<bool> Invoke(CryptoOperationDto param)
        {
            return param.KeyScheduleIndex < 4 * (param.KeyWords + 7);
        }
    }
}
