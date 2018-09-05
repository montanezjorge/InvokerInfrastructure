namespace AdvancedEncryptionStandard.Invoker.InvokerMembers
{
    using global::Invoker.Infrastructure;
    using System.Threading.Tasks;

    public class IsEven : InvokerConditionalMemberBase<CryptoOperationDto>
    {
        protected override async Task<bool> Invoke(CryptoOperationDto param)
        {
            return param.KeyScheduleIndex % param.KeyWords == 0;
        }
    }
}
