using Moble_Yacht_Game.Database.DataModels;
using Moble_Yacht_Game.Database.Handlers;
using Moble_Yacht_Game.Helpers;
using System;
using System.Windows.Forms;

namespace Moble_Yacht_Game.UserControls
{
    /// <summary>
    /// 로그인 화면 UI와 관련 로직을 담당하는 클래스입니다.
    /// </summary>
    public partial class LoginControl : UserControl
    {
        #region --- 이벤트 선언 ---

        /// <summary>
        /// 로그인 성공 시 발생하는 이벤트입니다. 성공한 유저의 정보를 함께 전달합니다.
        /// </summary>
        public event Action<UserData> LoginSuccess;

        /// <summary>
        /// '회원가입' 버튼을 눌렀을 때 발생하는 이벤트입니다.
        /// </summary>
        public event Action RegisterRequested;

        #endregion

        public LoginControl()
        {
            InitializeComponent();

            // --- 이벤트 핸들러 연결 ---
            this.Load += LoginControl_Load;
            this.Resize += LoginControl_Resize;
            btnLogin.Click += BtnLogin_Click;
            btnGoToRegister.Click += BtnGoToRegister_Click;
        }

        /// <summary>
        /// 컨트롤이 처음 로드될 때 컨트롤 위치를 조정합니다.
        /// </summary>
        private void LoginControl_Load(object? sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        /// <summary>
        /// 컨트롤의 크기가 변경될 때마다 컨트롤 위치를 다시 조정합니다.
        /// </summary>
        private void LoginControl_Resize(object? sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        /// <summary>
        /// '회원가입' 버튼 클릭 시, RegisterRequested 이벤트를 발생시켜 MainForm에게 알립니다.
        /// </summary>
        private void BtnGoToRegister_Click(object? sender, EventArgs e)
        {
            RegisterRequested?.Invoke();
        }

        /// <summary>
        /// '로그인' 버튼 클릭 시, 입력된 정보로 로그인을 시도합니다.
        /// </summary>
        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // 입력 값 검증
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("아이디와 비밀번호를 모두 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // UserDbHandler를 통해 로그인 시도
            UserData user = UserDbHandler.LoginUser(username, password);

            if (user != null)
            {
                // 로그인 성공 시, 이벤트를 발생시켜 MainForm에 유저 정보를 전달합니다.
                LoginSuccess?.Invoke(user);
            }
            else
            {
                MessageBox.Show("아이디 또는 비밀번호가 일치하지 않습니다.", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// UIHelper를 사용하여 컨트롤들의 위치를 조정합니다.
        /// </summary>
        private void UpdateControlPositions()
        {
            UIHelper.CenterHorizontally(this, picGameLogo);
            picGameLogo.Top = (this.ClientSize.Height / 2) - (picGameLogo.Height / 2) - 100;
            UIHelper.AlignToBottomRight(this, pnlLogin, 50, 50);
        }
    }
}

