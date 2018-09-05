namespace AdvancedEncryptionStandard.Invoker.InvokerMembers
{
    using System.Threading.Tasks;
    using global::Invoker.Infrastructure;

    public class Is256BitKey : InvokerConditionalMemberBase<CryptoOperationDto>
    {
        protected override async Task<bool> Invoke(CryptoOperationDto param)
        {
            return (param.KeyWords > 6) && ((param.KeyScheduleIndex % param.KeyWords) == 4);
        }
    }
}
