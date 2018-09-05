namespace AdvancedEncryptionStandard.Invoker
{
    public class CryptoOperationDto
    {
        public byte[] Plaintext { get; set; }

        public byte[] Key { get; set; }

        public byte[] IV { get; set; }

        public byte[] Ciphertext { get; set; }

        public byte[] OutputBlock { get; set; }

        public byte[] InputBlock { get; set; }

        public byte[,] State { get; set; }

        public byte[,] KeySchedule { get; set; }

        public int BlockIteration { get; set; }

        public int KeyScheduleIndex { get; set; }

        public int KeyWords { get; set; }

        public byte RoundConstant { get; set; }

        public int RoundIndex { get; set; }

        public int AddRoundKeyIndex { get; set; }
    }
}
