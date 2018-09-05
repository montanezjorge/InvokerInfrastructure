namespace TestProject
{
    using Invoker.Infrastructure;
    using Invoker.Infrastructure.Extensions;
    using Invoker.Infrastructure.Unity;
    using Microsoft.Practices.Unity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    using MorseCode.ITask;
    using TestProject.ClassForTesting;
    using System;
    using AdvancedEncryptionStandard.Invoker;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestAESInvoker()
        {
            var aes = Aes.Create();
            aes.KeySize = 256;
            aes.GenerateKey();
            aes.GenerateIV();

            var encryptor = aes.CreateEncryptor();

            var ciphertext = new byte[16];
            encryptor.TransformBlock(new byte[16], 0, 16, ciphertext, 0);

            var pedagogicalAES = new AES();
            
            var testCiphertext = await pedagogicalAES.EncryptAsync(new byte[16], aes.IV, aes.Key);

            Assert.AreEqual(Convert.ToBase64String(ciphertext), Convert.ToBase64String(testCiphertext));
        }

        [TestMethod]
        public async Task TestInvokerInfrastructure()
        {
            var unityContainer = new UnityContainer();
            var container = new UnityContainerWrapper(unityContainer);

            var configuration =
                new InvokerElement<Initializer>("Init")
                    .Invokes<LoopConditional>("Loop")
                        .Invokes(
                            new InvokerElement<If>("If").Invokes<IfLogic>("IfLogic"),
                            new InvokerElement<Else>("Else").Invokes<ElseLogic>("ElseLogic"))
                        .Invokes<Return>();

            container.RegisterInvoker<string>(configuration);
            var invoker = container.Resolve<IInvoker<string>>();

            await invoker.Invoke(Task.FromResult("HelloWorld!").AsITask());
        }
    }
}
