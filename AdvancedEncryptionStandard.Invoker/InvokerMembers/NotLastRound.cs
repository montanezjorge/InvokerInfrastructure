namespace AdvancedEncryptionStandard.Invoker.InvokerMembers
{
    using System.Threading.Tasks;
    using global::Invoker.Infrastructure;

    public class IfNotLastRound : InvokerConditionalMemberBase<CryptoOperationDto>
    {
        protected override async Task<bool> Invoke(CryptoOperationDto param)
        {
            return param.RoundIndex < param.KeyWords + 5;
        }
    }
}
