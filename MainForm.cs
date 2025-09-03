using Moble_Yacht_Game.Database.Core;
using Moble_Yacht_Game.Database.DataModels;
using Moble_Yacht_Game.UserControls;
using System;
using System.Windows.Forms;

namespace Moble_Yacht_Game
{
    /// <summary>
    /// 이 프로그램의 메인 창(Form)입니다.
    /// SPA 패턴의 '껍데기' 역할을 하며, 화면(UserControl) 전환 및 데이터베이스 연결과 같은 핵심 초기화 작업을 담당합니다.
    /// </summary>
    public partial class MainForm : Form
    {
        private LoginControl loginControl;

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            this.FormClosing += MainForm_FormClosing;
        }

        /// <summary>
        /// MainForm이 처음 로드될 때 실행됩니다. 데이터베이스 연결을 시도하고, 실패 시 프로그램을 종료합니다.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 프로그램 시작 시 데이터베이스 연결을 시도합니다.
                DatabaseManager.Instance.Connect();
            }
            catch (Exception ex)
            {
                // DatabaseManager에서 발생한 예외를 UI 계층에서 처리하여 사용자에게 메시지를 보여줍니다.
                MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            InitializeControls();
            ShowControl(loginControl);
        }

        /// <summary>
        /// 프로그램이 종료되기 직전에 데이터베이스 연결을 안전하게 해제합니다.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DatabaseManager.Instance.Disconnect();
        }

        /// <summary>
        /// 화면(UserControl)들을 생성하고 필요한 이벤트를 연결합니다.
        /// </summary>
        private void InitializeControls()
        {
            loginControl = new LoginControl();
            loginControl.LoginSuccess += OnLoginSuccess;
            loginControl.RegisterRequested += OnRegisterRequested;
        }

        /// <summary>
        /// LoginControl에서 '회원가입 요청' 이벤트가 발생했을 때 호출됩니다.
        /// </summary>
        private void OnRegisterRequested()
        {
            // RegisterForm을 생성하고 모달(Modal) 형태로 띄웁니다.
            // .ShowDialog()는 해당 폼이 닫히기 전까지 다른 창을 조작할 수 없게 만듭니다.
            using (RegisterForm registerForm = new RegisterForm())
            {
                registerForm.RegisterSuccess += OnRegisterSuccess;
                registerForm.ShowDialog(this);
            }
        }

        /// <summary>
        /// RegisterForm에서 '회원가입 성공' 이벤트가 발생했을 때 호출됩니다.
        /// </summary>
        private void OnRegisterSuccess()
        {
            MessageBox.Show("회원가입이 성공적으로 완료되었습니다. 로그인해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 지정된 UserControl을 메인 패널에 표시하는 범용 메서드입니다.
        /// </summary>
        private void ShowControl(UserControl controlToShow)
        {
            mainPanel.Controls.Clear();
            controlToShow.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(controlToShow);
        }

        /// <summary>
        /// LoginControl에서 로그인 성공 이벤트가 발생했을 때 호출됩니다.
        /// </summary>
        private void OnLoginSuccess(UserData userData)
        {
            MessageBox.Show($"{userData.Nickname}님, 환영합니다!");
            // TODO: (향후 구현) 이 곳에서 로비 화면(LobbyControl)으로 전환하는 코드를 작성합니다.
        }
    }
}

