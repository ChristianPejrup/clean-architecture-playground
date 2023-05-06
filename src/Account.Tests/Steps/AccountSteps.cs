using Account.Client;
using Account.Domain;
using Account.Infrastructure.Sql;
using Account.IntegrationTests;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using TechTalk.SpecFlow;
using Xunit;

namespace Account.Tests.Steps
{
    [Binding]
    public class AccountSteps : BaseSteps
    {
        private static string RegisterAccountExceptionName = "register-account-exception";
        private static string EmailOfExistingAccountName = "email-of-existing-account";
        private static string IdOfExistingAccountName = "id-of-existing-account";

        public AccountSteps(CustomWebApplicationFactory<Program> applicationFactory, ScenarioContext scenarioContext)
            : base(applicationFactory, scenarioContext)
        {
            
        }

        [Given(@"I'm using the account service")]
        public void GivenImUsingTheAccountService()
        {
            
        }

        [Given(@"I don't have an account")]
        public void GivenIDontHaveAnAccount()
        {
            AccountWriterMock
                .Create(Arg.Any<Domain.Account>(), Arg.Any<CancellationToken>())
                .Returns(args => (Domain.Account)args[0]);
        }

        [Given(@"I already have an account with the email '([^']*)'")]
        public void GivenIAlreadyHaveAnAccountWithTheEmail(string email)
        {
            var id = Guid.NewGuid();
            Set(IdOfExistingAccountName, id);
            Set(EmailOfExistingAccountName, email);

            AccountWriterMock
                .Create(Arg.Is<Domain.Account>(x => x.Email.Equals(email)), Arg.Any<CancellationToken>())
                .ThrowsAsync(new Shared.Exceptions.ConflictException($"The email ({email}) is already registered"));

            var existingAccount = new Domain.Account { Email = email, Id = id };

            AccountReaderMock
                .Get(Arg.Is(email), Arg.Any<CancellationToken>())
                .Returns(existingAccount);

            AccountReaderMock
                .Get(Arg.Is(id), Arg.Any<CancellationToken>())
                .Returns(existingAccount);
        }

        [When(@"I register an account with the email '([^']*)'")]
        public async Task WhenIRegisterAnAccountWithTheEmail(string email)
        {
            try
            {
                var account = await AccountClient.Create(new CreateAccount(email));
                Set(EmailOfExistingAccountName, email);
                Set(account);
            }
            catch (ConflictException exception)
            {
                Set(RegisterAccountExceptionName, exception);
            }
            catch (Exception exception)
            {
                Set(RegisterAccountExceptionName, exception);
            }
        }


        [When(@"I update my email '([^']*)'")]
        public async Task WhenIUpdateMyEmail(string email)
        {
            try
            {
                var id = Get<Guid>(IdOfExistingAccountName);
                await AccountClient.Update(id, new UpdateAccount(email));
                Set(EmailOfExistingAccountName, email);
            }
            catch (Exception exception)
            {
                Set(RegisterAccountExceptionName, exception);
            }
        }

        [When(@"I delete the account with the email '([^']*)'")]
        public async Task WhenIDeleteTheAccountWithTheEmail(string email)
        {
            try
            {
                var id = Get<Guid>(IdOfExistingAccountName);
                await AccountClient.Delete(id);
                Set(EmailOfExistingAccountName, email);
            }
            catch (Exception exception)
            {
                Set(RegisterAccountExceptionName, exception);
            }
        }

        [Then(@"My account is created")]
        public void ThenMyAccountIsCreated()
        {
            var account = Get<AccountDto>();
            var email = Get<string>(EmailOfExistingAccountName);
            
            Assert.Equal(email, account.Email);
        }

        [Then(@"I get an error message")]
        public void ThenIGetAnErrorMessage()
        {
            var exception = Get<ConflictException>(RegisterAccountExceptionName);
            Assert.IsType<ConflictException>(exception);
        }


        [Then(@"The account email is updated")]
        public void ThenTheAccountEmailIsUpdated()
        {
            var email = Get<string>(EmailOfExistingAccountName);
            this.AccountWriterMock.Received().Update(Arg.Is<Domain.Account>(a => a.Email.Equals(email)), Arg.Any<CancellationToken>());
        }

        [Then(@"The account is deleted")]
        public void ThenTheAccountIsDeleted()
        {
            var id = Get<Guid>(IdOfExistingAccountName);
            this.AccountWriterMock.Received().Delete(Arg.Is(id), Arg.Any<CancellationToken>());
        }
    }
}
