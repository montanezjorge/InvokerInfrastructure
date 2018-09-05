namespace AdvancedEncryptionStandard.Invoker.InvokerMembers
{
    using global::Invoker.Infrastructure;
    using System.Threading.Tasks;

    public class InputBlockToStateMatrix : InvokerMemberBase<CryptoOperationDto, CryptoOperationDto>
    {
        private const int SquareStateMatrixDimensions = 4;

        protected override async Task<CryptoOperationDto> Invoke(CryptoOperationDto param)
        {
            param.State = new byte[SquareStateMatrixDimensions, SquareStateMatrixDimensions];

            for(var row = 0; row < SquareStateMatrixDimensions; row++)
            {
                for (var col = 0; col < SquareStateMatrixDimensions; col++)
                {
                    param.State[row, col] = param.InputBlock[row + (SquareStateMatrixDimensions * col)];
                }
            }

            return param;
        }
    }
}
