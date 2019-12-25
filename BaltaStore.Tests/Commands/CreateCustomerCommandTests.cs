using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {

        [TestMethod]
        public void Deve_validar_quando_comando_e_valido()
        {
            var command = new CreateCustomerCommand();

            command.FirstName = "André";
            command.LastName = "Ferreira";
            command.Document = "11252529015";
            command.Email = "andre.ferreira.alves@gmail.com";
            command.Phone = "17999999999";

            Assert.IsTrue(command.Valid());
        }
    }
}