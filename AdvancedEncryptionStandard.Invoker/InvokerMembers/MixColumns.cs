namespace AdvancedEncryptionStandard.Invoker.InvokerMembers
{
    using System.Threading.Tasks;
    using global::Invoker.Infrastructure;

    public class MixColumns : InvokerMemberBase<CryptoOperationDto, CryptoOperationDto>
    {
        protected override async Task<CryptoOperationDto> Invoke(CryptoOperationDto param)
        {
            var t = new byte[4];
            var s = param.State;

            for (var c = 0; c < 4; c++)
            {
                t[0] = (byte)(Dot(2, s[0, c]) ^ Dot(3, s[1, c]) ^ s[2, c] ^ s[3, c]);
                t[1] = (byte)(s[0, c] ^ Dot(2, s[1, c]) ^ Dot(3, s[2, c]) ^ s[3, c]);
                t[2] = (byte)(s[0, c] ^ s[1, c] ^ Dot(2, s[2, c]) ^ Dot(3, s[3, c]));
                t[3] = (byte)(Dot(3, s[0, c]) ^ s[1, c] ^ s[2, c] ^ Dot(2, s[3, c]));

                s[0, c] = t[0];
                s[1, c] = t[1];
                s[2, c] = t[2];
                s[3, c] = t[3];
            }

            return param;
        }

        static byte XTime(byte x)
        {
            return (byte)((x << 1) ^ (((x & 0x80) != 0) ? 0x1b : 0x00));
        }

        static byte Dot(byte x, byte y)
        {
            byte mask;
            byte product = 0;

            for (mask = 0x01; mask != 0; mask <<= 1)
            {
                if ((y & mask) != 0)
                {
                    product ^= x;
                }
                x = XTime(x);
            }

            return product;
        }
    }
}
