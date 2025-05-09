using Mail.Engine.Service.Core.Entities;
using Mail.Engine.Service.Core.Results.Wati;

namespace Mail.Engine.Service.Core.Helpers
{
    public class MailMessageHelper
    {
        public static object CreateMailMessageParameters(MessageEntity message, MailboxEntity mailbox)
        {
            return new
            {
                p_mailbox_id = mailbox.MailboxId,
                p_subject = message.Subject,
                p_text_plain = message.TextPlain,
                p_text_html = message.TextHtml,
                p_format_text_html = message.FormatTextHtml,
                p_date_sent = message.DateSent,
                p_cc_field = message.CcField,
                p_bcc_field = message.BccField,
                p_sent_to = message.SentTo,
                p_sent_from = message.SentFrom,
                p_sent_from_display_name = message.SentFromDisplayName,
                p_sent_from_raw = message.SentFromRaw,
                p_imap_message_id = message.ImapMessageId,
                p_mime_version = message.MimeVersion,
                p_return_path = message.ReturnPath,
                p_logged_in_user = "Mail Service Api",
                p_new_mail_message_id = default(Guid)
            };
        }

        public static object UpdateStatusParameters(MessageLogEntity messageLog)
        {
            return new
            {
                p_mail_message_log_id = messageLog.MessageLogId,
                p_mail_message_log_status_code = messageLog.MessageLogStatusCode,
                p_mail_date_sent = messageLog.DateSent,
                p_mail_status_message = messageLog.StatusMessage,
                p_mail_from_field = messageLog.FromField,
                p_mail_from_name = messageLog.FromName
            };
        }

        public static object InsertWatiResponseParameters(Guid messageLogId, string responseJson)
        {
            return new
            {
                p_message_log_id = messageLogId,
                p_response_json = responseJson
            };
        }
    }
}
