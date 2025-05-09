using Mail.Engine.Service.Core.Entities;
using MailKit.Net.Imap;

namespace Mail.Engine.Service.Core.Services.Mail.InboundMail
{
    public interface IEmailAuthenticator
    {
        Task AuthenticateAsync(IImapClient client, MailboxEntity mailbox);
    }
}
