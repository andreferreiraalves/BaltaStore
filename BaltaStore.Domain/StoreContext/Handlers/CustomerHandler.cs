using System;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Service;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAdressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verificar se o CPF já existe na base
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            // Verificar se o E-mail já existe na base
            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este Email já está em uso");

            // Criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // Criar a entidade
            var customer = new Customer(name, document, email, command.Phone);

            // Validar entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return null;

            // Persistir o cliente
            _repository.Save(customer);

            // Enviar um e-mail de boas vindas
            _emailService.Send(email.Address, "ronaldo@ronaldo.io", "Seja bem Vindo", "Seja bem vindo");

            // Retornar o resultado para a tela

            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAdressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}