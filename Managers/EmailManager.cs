using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System.IO;
using System.Threading.Tasks;

namespace Moble_Yacht_Game.Managers
{
    /// <summary>
    /// 이메일 전송과 관련된 기능을 관리하는 싱글톤 클래스입니다.
    /// </summary>
    public class EmailManager
    {
        // --- 싱글톤 패턴 구현 ---
        private static EmailManager _instance;
        public static EmailManager Instance => _instance ??= new EmailManager();
        // --- 싱글톤 패턴 구현 끝 ---

        private readonly string _smtpServer;
        private readonly int _port;
        private readonly string _username;
        private readonly string _password;

        /// <summary>
        /// 생성자에서 appsettings.json 파일로부터 이메일 서버 설정을 불러옵니다.
        /// </summary>
        private EmailManager()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfigurationRoot configuration = builder.Build();

            _smtpServer = configuration["EmailSettings:SmtpServer"];
            _port = int.Parse(configuration["EmailSettings:Port"]);
            _username = configuration["EmailSettings:Username"];
            _password = configuration["EmailSettings:Password"];
        }

        /// <summary>
        /// 지정된 수신자에게 인증 코드가 포함된 이메일을 비동기적으로 전송합니다.
        /// </summary>
        /// <param name="toEmail">수신자 이메일 주소</param>
        /// <param name="subject">이메일 제목</param>
        /// <param name="body">이메일 본문 (HTML 형식)</param>
        /// <returns>전송 성공 시 true, 실패 시 false를 반환합니다.</returns>
        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_username));
                email.To.Add(MailboxAddress.Parse(toEmail));
                email.Subject = subject;
                email.Body = new TextPart(TextFormat.Html) { Text = body };

                using var smtp = new SmtpClient();
                // SMTP 서버에 연결합니다. SSL/TLS를 사용하여 보안 연결을 설정합니다.
                await smtp.ConnectAsync(_smtpServer, _port, SecureSocketOptions.StartTls);
                // SMTP 서버에 인증(로그인)합니다.
                await smtp.AuthenticateAsync(_username, _password);
                // 이메일을 전송합니다.
                await smtp.SendAsync(email);
                // 연결을 종료합니다.
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch (System.Exception)
            {
                // 이메일 전송 중 오류 발생 시 실패를 알립니다.
                return false;
            }
        }
    }
}
